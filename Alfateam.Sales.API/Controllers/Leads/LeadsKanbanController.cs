using Alfateam.Core.Exceptions;
using Alfateam.Core;
using Alfateam.Sales.API.Abstractions;
using Alfateam.Sales.API.Models;
using Alfateam.Sales.API.Models.DTO.Leads.Kanban;
using Alfateam.Sales.API.Models.DTO.Leads;
using Alfateam.Sales.API.Models.Kanban;
using Alfateam.Sales.Models.Leads.Kanban;
using Alfateam.Sales.Models.Leads;
using Alfateam.Sales.Models.Enums.Statuses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Sales.API.Controllers.Leads
{
    [Route("Leads/[controller]")]
    public class LeadsKanbanController : AbsController
    {
        public LeadsKanbanController(ControllerParams @params) : base(@params)
        {
        }

        #region Канбаны

        [HttpGet, Route("GetKanbans")]
        public async Task<ItemsWithTotalCount<LeadsKanbanDTO>> GetKanbans(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<LeadsKanban, LeadsKanbanDTO>(GetAvailableKanbans(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetKanban")]
        public async Task<LeadsKanbanDTO> GetKanban(int id)
        {
            return (LeadsKanbanDTO)DBService.TryGetOne(GetAvailableKanbans(), id, new LeadsKanbanDTO());
        }

        [HttpPost, Route("CreateKanban")]
        public async Task<LeadsKanbanDTO> CreateKanban(LeadsKanbanDTO model)
        {
            return (LeadsKanbanDTO)DBService.TryCreateEntity(DB.LeadsKanbans, model, (entity) =>
            {
                entity.BusinessCompanyId = (int)this.CompanyId;
                AddDefaultKanbanStages(entity);
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление канбана для КП", $"Добавлен канбан для КП {entity.Title}");
            });
        }

        [HttpPut, Route("UpdateKanban")]
        public async Task<LeadsKanbanDTO> UpdateKanban(LeadsKanbanDTO model)
        {
            var item = GetAvailableKanbans().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (LeadsKanbanDTO)DBService.TryUpdateEntity(DB.LeadsKanbans, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование канбана для КП", $"Отредактирован канбан для КП с id={entity.Id}");
            });
        }




        [HttpDelete, Route("DeleteKanban")]
        public async Task DeleteKanban(int id)
        {
            var item = GetAvailableKanbans().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.LeadsKanbans, item);

            this.AddHistoryAction("Удаление канбана для КП", $"Удален канбан для КП {item.Title} с id={id}");
        }

        #endregion

        #region Этапы (колонки) канбанов

        [HttpPost, Route("CreateKanbanStage")]
        public async Task<LeadsKanbanStageDTO> CreateKanbanStage(int kanbanId, int stageAfterId, LeadsKanbanStageDTO model)
        {
            var kanban = TryGetKanban(kanbanId);
            if (TryGetKanbanStage(stageAfterId).LeadsKanbanId != kanbanId)
            {
                throw new Exception403("Этап не принадлежит текущему канбану");
            }
            if (!model.IsValid())
            {
                throw new Exception400("Проверьте корректность заполнения полей");
            }

            var stageEntity = model.CreateDBModelFromDTO();
            kanban.InsertStage(stageAfterId, stageEntity);
            DBService.UpdateEntity(DB.LeadsKanbans, kanban);

            this.AddHistoryAction("Добавление этапа (колонки) для канбана", $"Добавлен этап (колонка) для канбана {stageEntity.Title}");
            return (LeadsKanbanStageDTO)new LeadsKanbanStageDTO().CreateDTO(stageEntity);
        }

        [HttpPut, Route("UpdateKanbanStage")]
        public async Task<LeadsKanbanStageDTO> UpdateKanbanStage(LeadsKanbanStageDTO model)
        {
            var item = TryGetKanbanStage(model.Id);
            return (LeadsKanbanStageDTO)DBService.TryUpdateEntity(DB.LeadsKanbanStages, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование этапа (колонки) для канбана", $"Отредактирован этап (колонка) для канбана с id={entity.Id}");
            });
        }

        [HttpDelete, Route("DeleteKanbanStage")]
        public async Task DeleteKanbanStage(int id)
        {
            var item = TryGetKanbanStage(id);

            if (item.IsSystemStage)
            {
                throw new Exception403("Невозможно удалить системную стадию");
            }
            else if (GetAvailableLeads(item.LeadsKanbanId).Where(o => o.KanbanData.StageId == id).Any())
            {
                throw new Exception400("Этап (колонка) для КП не пустой");
            }


            DBService.TryDeleteEntity(DB.LeadsKanbanStages, item);
            this.AddHistoryAction("Удаление этапа (колонки) для канбана", $"Удален этап (колонка) для канбана {item.Title} с id={id}");
        }

        #endregion

        #region Карточки в канбане

        [HttpGet, Route("GetKanbanItems")]
        public async Task<KanbanClientModel<LeadDTO>> GetKanbanItems(int kanbanId)
        {
            var kanban = DBService.TryGetOne(GetAvailableKanbans(), kanbanId);
            var invoices = GetAvailableLeads(kanbanId);


            var clientModel = new KanbanClientModel<LeadDTO>();

            foreach (var stage in kanban.Stages)
            {
                var items = invoices.Where(o => o.KanbanData.StageId == stage.Id);

                clientModel.Stages.Add(new KanbanStageClientModel<LeadDTO>
                {
                    StageId = stage.Id,
                    Items = new LeadDTO().CreateDTOs(items).Cast<LeadDTO>()
                });
            }

            return clientModel;
        }

        [HttpPut, Route("SetKanbanItemStage")]
        public async Task SetKanbanItemStage(int leadId, int stageId)
        {
            var lead = DBService.TryGetOne(GetAvailableLeads(), leadId);
            if(lead.KanbanData.Stage.Status == LeadsKanbanStageStatus.ConvertedLead)
            {
                throw new Exception403("Сконвертированный лид нельзя перенести на другую стадию воронки");
            }

            var kanbanStage = TryGetKanbanStage(stageId);
            if(kanbanStage.Status == LeadsKanbanStageStatus.ConvertedLead)
            {
                throw new Exception403("Лид нельзя перенести просто так на эту стадию. " +
                                       "Воспользуйтесь методом конвертации лида TransformLead(LeadTransformationModel model)");
            }

            lead.KanbanData.StageId = stageId;
            DBService.UpdateEntity(DB.Leads, lead);
        }

        #endregion










        #region Private kanban methods
        private IEnumerable<LeadsKanban> GetAvailableKanbans()
        {
            return DB.LeadsKanbans.Include(o => o.Stages)
                                              .Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }


        private void AddDefaultKanbanStages(LeadsKanban entity)
        {
            entity.Stages.Add(new LeadsKanbanStage
            {
                Status = LeadsKanbanStageStatus.NewLead,
                Title = "Новый",
                TextHexColor = "#07141C",
                BGHexColor = "#39A8EF",
                IsSystemStage = true,
            });
            entity.Stages.Add(new LeadsKanbanStage
            {
                Status = LeadsKanbanStageStatus.InWork,
                Title = "В работе",
                TextHexColor = "#07141C",
                BGHexColor = "#2FC6F6",
                IsSystemStage = false,
            });
            entity.Stages.Add(new LeadsKanbanStage
            {
                Status = LeadsKanbanStageStatus.InWork,
                Title = "Обработан",
                TextHexColor = "#07141C",
                BGHexColor = "#2FC6F6",
                IsSystemStage = false,
            });




            entity.Stages.Add(new LeadsKanbanStage
            {
                Status = LeadsKanbanStageStatus.RejectedLead,
                Title = "Некачественный лид",
                TextHexColor = "#FFFFFF",
                BGHexColor = "#FF5752",
                IsSystemStage = true,
            });
            entity.Stages.Add(new LeadsKanbanStage
            {
                Status = LeadsKanbanStageStatus.ConvertedLead,
                Title = "Качественный лид",
                TextHexColor = "#07141C",
                BGHexColor = "#7BD500",
                IsSystemStage = true,
            });
        }



        private LeadsKanban TryGetKanban(int kanbanId)
        {
            return DBService.TryGetOne(GetAvailableKanbans(), kanbanId);
        }
        private void ThrowIfKanbanDontExist(int kanbanId)
        {
            DBService.TryGetOne(GetAvailableKanbans(), kanbanId);
        }
        private LeadsKanbanStage TryGetKanbanStage(int stageId)
        {
            var stage = DBService.TryGetOne(DB.LeadsKanbanStages, stageId);
            if (!GetAvailableKanbans().Any(o => o.Id == stage.LeadsKanbanId))
            {
                throw new Exception403("Нет доступа к данной сущности");
            }
            return stage;
        }

        #endregion

        #region Private business Leads methods

        private IEnumerable<Lead> GetAvailableLeads()
        {
            return DB.Leads.Include(o => o.PersonContact)
                           .Include(o => o.Company)
                           .Include(o => o.KanbanData).ThenInclude(o => o.Kanban)
                           .Include(o => o.KanbanData).ThenInclude(o => o.Stage)
                           .Include(o => o.UTMMark)
                           .Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }

        private IEnumerable<Lead> GetAvailableLeads(int kanbanId)
        {
            return GetAvailableLeads().Where(o => o.KanbanData.KanbanId == kanbanId);
        }


        #endregion

    }
}

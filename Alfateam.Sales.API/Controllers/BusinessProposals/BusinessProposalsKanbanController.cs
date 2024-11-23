using Alfateam.Core;
using Alfateam.Core.Exceptions;
using Alfateam.Sales.API.Abstractions;
using Alfateam.Sales.API.Models;
using Alfateam.Sales.API.Models.DTO.BusinessProposals;
using Alfateam.Sales.API.Models.DTO.BusinessProposals.Kanban;
using Alfateam.Sales.API.Models.DTO.Funnel;
using Alfateam.Sales.API.Models.DTO.Invoices;
using Alfateam.Sales.API.Models.Kanban;
using Alfateam.Sales.Models.BusinessProposals;
using Alfateam.Sales.Models.BusinessProposals.Kanban;
using Alfateam.Sales.Models.Enums.Statuses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Sales.API.Controllers.BusinessProposals
{
    [Route("BP/[controller]")]
    public class BusinessProposalsKanbanController : AbsController
    {
        public BusinessProposalsKanbanController(ControllerParams @params) : base(@params)
        {
        }

        #region Канбаны

        [HttpGet, Route("GetKanbans")]
        public async Task<ItemsWithTotalCount<BusinessProposalsKanbanDTO>> GetKanbans(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<BusinessProposalsKanban, BusinessProposalsKanbanDTO>(GetAvailableKanbans(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetKanban")]
        public async Task<BusinessProposalsKanbanDTO> GetKanban(int id)
        {
            return (BusinessProposalsKanbanDTO)DBService.TryGetOne(GetAvailableKanbans(), id, new BusinessProposalsKanbanDTO());
        }

        [HttpPost, Route("CreateKanban")]
        public async Task<BusinessProposalsKanbanDTO> CreateKanban(BusinessProposalsKanbanDTO model)
        {
            return (BusinessProposalsKanbanDTO)DBService.TryCreateEntity(DB.BusinessProposalsKanbans, model, (entity) =>
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
        public async Task<BusinessProposalsKanbanDTO> UpdateKanban(BusinessProposalsKanbanDTO model)
        {
            var item = GetAvailableKanbans().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (BusinessProposalsKanbanDTO)DBService.TryUpdateEntity(DB.BusinessProposalsKanbans, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование канбана для КП", $"Отредактирован канбан для КП с id={entity.Id}");
            });
        }




        [HttpDelete, Route("DeleteKanban")]
        public async Task DeleteKanban(int id)
        {
            var item = GetAvailableKanbans().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.BusinessProposalsKanbans, item);

            this.AddHistoryAction("Удаление канбана для КП", $"Удален канбан для КП {item.Title} с id={id}");
        }

        #endregion

        #region Этапы (колонки) канбанов

        [HttpPost, Route("CreateKanbanStage")]
        public async Task<BusinessProposalsKanbanStageDTO> CreateKanbanStage(int kanbanId, int stageAfterId, BusinessProposalsKanbanStageDTO model)
        {
            var kanban = TryGetKanban(kanbanId);
            if (TryGetKanbanStage(stageAfterId).BusinessProposalsKanbanId != kanbanId)
            {
                throw new Exception403("Этап не принадлежит текущему канбану");
            }
            if (!model.IsValid())
            {
                throw new Exception400("Проверьте корректность заполнения полей");
            }

            var stageEntity = model.CreateDBModelFromDTO();
            kanban.InsertStage(stageAfterId, stageEntity);
            DBService.UpdateEntity(DB.BusinessProposalsKanbans, kanban);

            this.AddHistoryAction("Добавление этапа (колонки) для канбана", $"Добавлен этап (колонка) для канбана {stageEntity.Title}");
            return (BusinessProposalsKanbanStageDTO)new BusinessProposalsKanbanStageDTO().CreateDTO(stageEntity);
        }

        [HttpPut, Route("UpdateKanbanStage")]
        public async Task<BusinessProposalsKanbanStageDTO> UpdateKanbanStage(BusinessProposalsKanbanStageDTO model)
        {
            var item = TryGetKanbanStage(model.Id);
            return (BusinessProposalsKanbanStageDTO)DBService.TryUpdateEntity(DB.BusinessProposalsKanbanStages, model, item, afterSuccessCallback: (entity) =>
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
            else if (GetAvailableProposals(item.BusinessProposalsKanbanId).Where(o => o.KanbanData.StageId == id).Any())
            {
                throw new Exception400("Этап (колонка) для КП не пустой");
            }


            DBService.TryDeleteEntity(DB.BusinessProposalsKanbanStages, item);
            this.AddHistoryAction("Удаление этапа (колонки) для канбана", $"Удален этап (колонка) для канбана {item.Title} с id={id}");
        }

        #endregion

        #region Карточки в канбане

        [HttpGet, Route("GetKanbanItems")]
        public async Task<KanbanClientModel<BusinessProposalDTO>> GetKanbanItems(int kanbanId)
        {
            var kanban = DBService.TryGetOne(GetAvailableKanbans(), kanbanId);
            var invoices = GetAvailableProposals(kanbanId);


            var clientModel = new KanbanClientModel<BusinessProposalDTO>();

            foreach (var stage in kanban.Stages)
            {
                var items = invoices.Where(o => o.KanbanData.StageId == stage.Id);

                clientModel.Stages.Add(new KanbanStageClientModel<BusinessProposalDTO>
                {
                    StageId = stage.Id,
                    Items = new BusinessProposalDTO().CreateDTOs(items).Cast<BusinessProposalDTO>()
                });
            }

            return clientModel;
        }

        [HttpPut, Route("SetKanbanItemStage")]
        public async Task SetKanbanItemStage(int businessProposalId, int stageId)
        {
            var proposal = DBService.TryGetOne(GetAvailableProposals(), businessProposalId);
            TryGetKanbanStage(stageId);

            proposal.KanbanData.StageId = stageId;
            DBService.UpdateEntity(DB.BusinessProposals, proposal);
        }

        #endregion










        #region Private kanban methods
        private IEnumerable<BusinessProposalsKanban> GetAvailableKanbans()
        {
            return DB.BusinessProposalsKanbans.Include(o => o.Stages)
                                              .Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }


        private void AddDefaultKanbanStages(BusinessProposalsKanban entity)
        {
            entity.Stages.Add(new BusinessProposalsKanbanStage
            {
                Status = BPKanbanStageStatus.NewBP,
                Title = "Новое",
                TextHexColor = "#07141C",
                BGHexColor = "#39A8EF",
                IsSystemStage = true,
            });
            entity.Stages.Add(new BusinessProposalsKanbanStage
            {
                Status = BPKanbanStageStatus.InWork,
                Title = "Отправлено клиенту",
                TextHexColor = "#07141C",
                BGHexColor = "#2FC6F6",
                IsSystemStage = false,
            });





            entity.Stages.Add(new BusinessProposalsKanbanStage
            {
                Status = BPKanbanStageStatus.Rejected,
                Title = "Отклонено",
                TextHexColor = "#FFFFFF",
                BGHexColor = "#FF5752",
                IsSystemStage = true,
            });
            entity.Stages.Add(new BusinessProposalsKanbanStage
            {
                Status = BPKanbanStageStatus.Rejected,
                Title = "Анализ причины отклонения",
                TextHexColor = "#FFFFFF",
                BGHexColor = "#FF5752",
                IsSystemStage = false,
            });
            entity.Stages.Add(new BusinessProposalsKanbanStage
            {
                Status = BPKanbanStageStatus.Approved,
                Title = "Принято",
                TextHexColor = "#07141C",
                BGHexColor = "#7BD500",
                IsSystemStage = true,
            });
        }



        private BusinessProposalsKanban TryGetKanban(int kanbanId)
        {
            return DBService.TryGetOne(GetAvailableKanbans(), kanbanId);
        }
        private void ThrowIfKanbanDontExist(int kanbanId)
        {
            DBService.TryGetOne(GetAvailableKanbans(), kanbanId);
        }
        private BusinessProposalsKanbanStage TryGetKanbanStage(int stageId)
        {
            var stage = DBService.TryGetOne(DB.BusinessProposalsKanbanStages, stageId);
            if (!GetAvailableKanbans().Any(o => o.Id == stage.BusinessProposalsKanbanId))
            {
                throw new Exception403("Нет доступа к данной сущности");
            }
            return stage;
        }

        #endregion

        #region Private business proposals methods

        private IEnumerable<BusinessProposal> GetAvailableProposals()
        {
            return DB.BusinessProposals.Include(o => o.PersonContact)
                                       .Include(o => o.Company)
                                       .Include(o => o.Sum).ThenInclude(o => o.Currency)
                                       .Include(o => o.KanbanData).ThenInclude(o => o.Kanban)
                                       .Include(o => o.KanbanData).ThenInclude(o => o.Stage)
                                       .Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }

        private IEnumerable<BusinessProposal> GetAvailableProposals(int kanbanId)
        {
            return GetAvailableProposals().Where(o => o.KanbanData?.KanbanId == kanbanId);
        }


        #endregion
    }
}

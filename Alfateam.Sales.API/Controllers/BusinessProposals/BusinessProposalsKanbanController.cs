using Alfateam.Core;
using Alfateam.Core.Exceptions;
using Alfateam.Sales.API.Abstractions;
using Alfateam.Sales.API.Models;
using Alfateam.Sales.API.Models.DTO.BusinessProposals.Kanban;
using Alfateam.Sales.API.Models.DTO.Funnel;
using Alfateam.Sales.Models.BusinessProposals.Kanban;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Sales.API.Controllers.BusinessProposals
{
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
        public async Task<BusinessProposalsKanbanStageDTO> CreateKanbanStage(int kanbanId, BusinessProposalsKanbanStageDTO model)
        {
            ThrowIfKanbanDontExist(kanbanId);
            return (BusinessProposalsKanbanStageDTO)DBService.TryCreateEntity(DB.BusinessProposalsKanbanStages, model, (entity) =>
            {
                entity.BusinessProposalsKanbanId = kanbanId;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление этапа (колонки) для канбана", $"Добавлен этап (колонка) для канбана {entity.Title}");
            });
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
            DBService.TryDeleteEntity(DB.BusinessProposalsKanbanStages, item);

            this.AddHistoryAction("Удаление этапа (колонки) для канбана", $"Удален этап (колонка) для канбана {item.Title} с id={id}");
        }

        #endregion






        #region Private methods
        private IEnumerable<BusinessProposalsKanban> GetAvailableKanbans()
        {
            return DB.BusinessProposalsKanbans.Include(o => o.Stages)
                                              .Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
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
    }
}

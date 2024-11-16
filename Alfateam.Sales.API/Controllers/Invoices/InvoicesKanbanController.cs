using Alfateam.Core.Exceptions;
using Alfateam.Core;
using Alfateam.Sales.API.Abstractions;
using Alfateam.Sales.API.Models;
using Alfateam.Sales.API.Models.DTO.Invoices.Kanban;
using Alfateam.Sales.Models.Invoices.Kanban;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Sales.API.Controllers.Invoices
{
    public class InvoicesKanbanController : AbsController
    {
        public InvoicesKanbanController(ControllerParams @params) : base(@params)
        {
        }

        #region Канбаны

        [HttpGet, Route("GetKanbans")]
        public async Task<ItemsWithTotalCount<InvoicesKanbanDTO>> GetKanbans(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<InvoicesKanban, InvoicesKanbanDTO>(GetAvailableKanbans(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetKanban")]
        public async Task<InvoicesKanbanDTO> GetKanban(int id)
        {
            return (InvoicesKanbanDTO)DBService.TryGetOne(GetAvailableKanbans(), id, new InvoicesKanbanDTO());
        }

        [HttpPost, Route("CreateKanban")]
        public async Task<InvoicesKanbanDTO> CreateKanban(InvoicesKanbanDTO model)
        {
            return (InvoicesKanbanDTO)DBService.TryCreateEntity(DB.InvoicesKanbans, model, (entity) =>
            {
                entity.BusinessCompanyId = (int)this.CompanyId;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление канбана для КП", $"Добавлен канбан для КП {entity.Title}");
            });
        }

        [HttpPut, Route("UpdateKanban")]
        public async Task<InvoicesKanbanDTO> UpdateKanban(InvoicesKanbanDTO model)
        {
            var item = GetAvailableKanbans().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (InvoicesKanbanDTO)DBService.TryUpdateEntity(DB.InvoicesKanbans, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование канбана для КП", $"Отредактирован канбан для КП с id={entity.Id}");
            });
        }




        [HttpDelete, Route("DeleteKanban")]
        public async Task DeleteKanban(int id)
        {
            var item = GetAvailableKanbans().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.InvoicesKanbans, item);

            this.AddHistoryAction("Удаление канбана для КП", $"Удален канбан для КП {item.Title} с id={id}");
        }

        #endregion

        #region Этапы (колонки) канбанов

        [HttpPost, Route("CreateKanbanStage")]
        public async Task<InvoicesKanbanStageDTO> CreateKanbanStage(int kanbanId, InvoicesKanbanStageDTO model)
        {
            ThrowIfKanbanDontExist(kanbanId);
            return (InvoicesKanbanStageDTO)DBService.TryCreateEntity(DB.InvoicesKanbanStages, model, (entity) =>
            {
                entity.InvoicesKanbanId = kanbanId;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление этапа (колонки) для канбана", $"Добавлен этап (колонка) для канбана {entity.Title}");
            });
        }

        [HttpPut, Route("UpdateKanbanStage")]
        public async Task<InvoicesKanbanStageDTO> UpdateKanbanStage(InvoicesKanbanStageDTO model)
        {
            var item = TryGetKanbanStage(model.Id);
            return (InvoicesKanbanStageDTO)DBService.TryUpdateEntity(DB.InvoicesKanbanStages, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование этапа (колонки) для канбана", $"Отредактирован этап (колонка) для канбана с id={entity.Id}");
            });
        }

        [HttpDelete, Route("DeleteKanbanStage")]
        public async Task DeleteKanbanStage(int id)
        {
            var item = TryGetKanbanStage(id);
            DBService.TryDeleteEntity(DB.InvoicesKanbanStages, item);

            this.AddHistoryAction("Удаление этапа (колонки) для канбана", $"Удален этап (колонка) для канбана {item.Title} с id={id}");
        }

        #endregion






        #region Private methods
        private IEnumerable<InvoicesKanban> GetAvailableKanbans()
        {
            return DB.InvoicesKanbans.Include(o => o.Stages)
                                              .Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }




        private void ThrowIfKanbanDontExist(int kanbanId)
        {
            DBService.TryGetOne(GetAvailableKanbans(), kanbanId);
        }
        private InvoicesKanbanStage TryGetKanbanStage(int stageId)
        {
            var stage = DBService.TryGetOne(DB.InvoicesKanbanStages, stageId);
            if (!GetAvailableKanbans().Any(o => o.Id == stage.InvoicesKanbanId))
            {
                throw new Exception403("Нет доступа к данной сущности");
            }
            return stage;
        }

        #endregion
    }
}

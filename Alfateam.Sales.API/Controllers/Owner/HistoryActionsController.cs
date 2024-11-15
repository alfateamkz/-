using Alfateam.Core;
using Alfateam.Sales.API.Abstractions;
using Alfateam.Sales.API.Models;
using Alfateam.Sales.API.Models.DTO.General.Security;
using Alfateam.Sales.API.Models.DTO.Orders;
using Alfateam.Sales.API.Models.SearchFilters;
using Alfateam.Sales.Models.General.Security;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.Sales.API.Controllers.Owner
{
    public class HistoryActionsController : AbsController
    {
        public HistoryActionsController(ControllerParams @params) : base(@params)
        {
        }
         
        #region Получение истории действий

        [HttpGet, Route("GetHistoryActions")]
        public async Task<ItemsWithTotalCount<HistoryActionDTO>> GetHistoryActions(HistoryActionsSearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<HistoryAction, HistoryActionDTO>(GetAvailableHistoryActions(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition &= entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                if (filter.UserId != null)
                {
                    condition &= entity.CreatedById == filter.UserId;
                }
                return condition;
            });
        }

        [HttpGet, Route("GetHistoryAction")]
        public async Task<HistoryActionDTO> GetHistoryAction(int id)
        {
            return (HistoryActionDTO)DBService.TryGetOne(GetAvailableHistoryActions(), id, new HistoryActionDTO());
        }

        [HttpGet, Route("GetMyHistoryActions")]
        public async Task<ItemsWithTotalCount<HistoryActionDTO>> GetHistoryActions(SearchFilter filter)
        {
            var myActions = GetAvailableHistoryActions().Where(o => o.CreatedById == this.AuthorizedUser.Id);
            return DBService.GetManyWithTotalCount<HistoryAction, HistoryActionDTO>(myActions, filter.Offset, filter.Count);
        }

        #endregion









        #region Private methods
        private IEnumerable<HistoryAction> GetAvailableHistoryActions()
        {
            return DB.HistoryActions.Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }

        #endregion
    }
}

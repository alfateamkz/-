using Alfateam.Administration.Models.General.Security;
using Alfateam.AdminPanelGeneral.API.Abstractions;
using Alfateam.AdminPanelGeneral.API.Models;
using Alfateam.Administration.Models.DTO.General.Security;
using Alfateam.AdminPanelGeneral.API.Models.Filters;
using Alfateam.Core;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.AdminPanelGeneral.API.Controllers
{
    public class UserActionsController : AbsController
    {
        public UserActionsController(ControllerParams @params) : base(@params)
        {
        }

        #region Получение истории действий

        [HttpGet, Route("GetUserActions")]
        public async Task<ItemsWithTotalCount<UserActionDTO>> GetUserActions(UserActionsSearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<UserAction, UserActionDTO>(GetAvailableUserActions(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition &= entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                if (filter.UserId != null)
                {
                    condition &= entity.UserId == filter.UserId;
                }
                return condition;
            });
        }

        [HttpGet, Route("GetUserAction")]
        public async Task<UserActionDTO> GetUserAction(int id)
        {
            return (UserActionDTO)DBService.TryGetOne(GetAvailableUserActions(), id, new UserActionDTO());
        }

        [HttpGet, Route("GetMyUserActions")]
        public async Task<ItemsWithTotalCount<UserActionDTO>> GetUserActions(SearchFilter filter)
        {
            var myActions = GetAvailableUserActions().Where(o => o.UserId == this.AuthorizedUser.Id);
            return DBService.GetManyWithTotalCount<UserAction, UserActionDTO>(myActions, filter.Offset, filter.Count);
        }

        #endregion









        #region Private methods
        private IEnumerable<UserAction> GetAvailableUserActions()
        {
            return AdmininstrationDb.UserActions.Where(o => !o.IsDeleted);
        }

        #endregion
    }
}

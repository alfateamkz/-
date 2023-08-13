using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models.Core;
using Alfateam2._0.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Alfateam.Website.API.Filters
{
    public class AdminActionsFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var adminController = context.Controller as AbsAdminController;

            var session = adminController.GetSessionWithRoleInclude();
            var sessionCheckResult = adminController.CheckSession(session);
            if (!sessionCheckResult.Success)
            {
                context.Result = new JsonResult(sessionCheckResult);
                return;
            }
            var banCheckResult = adminController.CheckForBan(session.User, BanType.AdminPanel);
            if(!banCheckResult.Success)
            {
                context.Result = new JsonResult(banCheckResult);
                return;
            }
            if(session.User.RoleModel.Role == UserRole.User)
            {
                var res = RequestResult.AsError(403, "У пользователя нет доступа в администраторскую панель");
                context.Result = new JsonResult(res);
                return;
            }

        }
    }
}

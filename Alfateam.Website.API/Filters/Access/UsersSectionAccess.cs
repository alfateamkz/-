using Alfateam.CRM2_0.Models.Gamification.General;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Core;
using Alfateam2._0.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Alfateam.Website.API.Filters.Access
{
    public class UsersSectionAccess : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var adminController = context.Controller as AbsAdminController;
            var session = adminController.GetSessionWithRoleInclude();

            if (session.User.RoleModel.Role != UserRole.Owner && session.User.RoleModel.Role != UserRole.LocalDirector)
            {
                context.Result = new JsonResult(RequestResult.AsError(403, "У данного пользователя нет прав на выполнение данного действия"));
                return;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
         
        }
    }
}

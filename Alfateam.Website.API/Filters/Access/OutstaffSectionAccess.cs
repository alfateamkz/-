using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Core;
using Alfateam.Website.API.Exceptions;
using Alfateam2._0.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Alfateam.Website.API.Filters.Access
{
    public class OutstaffSectionAccess : Attribute, IActionFilter
    {
        public readonly int Level;  
        public OutstaffSectionAccess(int level)
        {
            this.Level = level;
        }


        public void OnActionExecuted(ActionExecutedContext context)
        {
            var adminController = context.Controller as AbsAdminController;
            var session = adminController.GetSessionWithRoleInclude();

            if(session.User.RoleModel.OutstaffAccess.AccessLevel < Level && session.User.RoleModel.Role != UserRole.Owner)
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

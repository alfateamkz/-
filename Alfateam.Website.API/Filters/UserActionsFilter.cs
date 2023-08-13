using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models.Core;
using Alfateam2._0.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Alfateam.Website.API.Filters
{
    public class UserActionsFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.Controller as AbsController;

            var session = controller.GetUserSession();
            var sessionCheckResult = controller.CheckSession(session);
            if (!sessionCheckResult.Success)
            {
                context.Result = new JsonResult(sessionCheckResult);
                return;
            }

            var banCheckResult = controller.CheckForBan(session.User, BanType.All);
            if (!banCheckResult.Success)
            {
                context.Result = new JsonResult(banCheckResult);
                return;
            }

        }
    }
}

using Alfateam.Core.Results.StatusCodes;
using Alfateam.EDM.API.Abstractions;
using Alfateam.EDM.Models.Enums;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Alfateam.EDM.API.Filters
{
    public class CheckCompanyAccessAndTrustedIP : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
          
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.Controller as AbsAuthorizedController;

            if (controller.AuthorizedUser.IsBlocked)
            {
                context.Result = new Result403("Доступ к данной компании запрещен");
                return;
            }
            if(controller.AuthorizedUser.TrustedUserIPs.Any(o => !o.IsDeleted)
                && !controller.AuthorizedUser.TrustedUserIPs.Any(o => o.IPAddress == controller.HttpContext.Connection.RemoteIpAddress?.ToString())
                && controller.AuthorizedUser.Role != UserRole.Owner)
            {
                context.Result = new Result403("Данный IP адрес не находится в списке разрешенных");
                return;
            }

                
        }
    }
}

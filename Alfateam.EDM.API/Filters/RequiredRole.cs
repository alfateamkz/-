using Alfateam.Core.Results.StatusCodes;
using Alfateam.EDM.API.Abstractions;
using Alfateam.EDM.Models.Enums;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Alfateam.EDM.API.Filters
{
    public class RequiredRole : Attribute, IActionFilter
    {
        public readonly UserRole Role;
        public RequiredRole(UserRole role)
        {
            Role = role;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
      
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.Controller as AbsAuthorizedController;

            if ((int)controller.AuthorizedUser.Role < (int)Role)
            {
                context.Result = new Result403("Ваша роль не позволяет выполнить данное действие");
            }
        }
    }
}

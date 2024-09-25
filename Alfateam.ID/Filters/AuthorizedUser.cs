using Alfateam.Core.Exceptions;
using Alfateam.Core.Results.StatusCodes;
using Alfateam.ID.Abstractions;
using Alfateam2._0.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Alfateam.ID.API.Filters
{
    public class AuthorizedUser : Attribute, IActionFilter
    {
        public readonly bool MustBeVerified;
        public AuthorizedUser()
        {

        }
        public AuthorizedUser(bool mustBeVerified)
        {
            MustBeVerified = mustBeVerified;
        }


        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.Controller as AbsController;

            var session = controller.Session;
            if (session == null)
            {
                context.Result = new Result404("Сессия не найдена"); 
            }
            else if (session.IsExpired)
            {
                context.Result = new Result401("Сессия истекла");
            }
            else if (session.IsDeactivated)
            {
                context.Result = new Result403("Сессия дективирована");
            }
            else if(MustBeVerified && !session.User.IsVerified)
            {
                context.Result = new Result403("Необходимо подтвердить email и телефон для доступа в данный раздел");
            }
        }
    }
}

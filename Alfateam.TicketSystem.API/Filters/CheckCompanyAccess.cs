﻿using Alfateam.Core.Results.StatusCodes;
using Alfateam.TicketSystem.API.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Alfateam.TicketSystem.API.Filters
{
    public class CheckCompanyAccess : Attribute, IActionFilter
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
            }


        }
    }
}

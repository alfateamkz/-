using Alfateam.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Alfateam.Core.Filters
{
    public class APIExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if(context.Exception is Exception400 badRequest)
            {
                context.Result = new JsonResult(RequestResult.AsError(400, badRequest.Error));
            }
            else if (context.Exception is Exception401 unauthorized)
            {
                context.Result = new JsonResult(RequestResult.AsError(401, unauthorized.Error));
            }
            else if (context.Exception is Exception402 noPayment)
            {
                context.Result = new JsonResult(RequestResult.AsError(402, noPayment.Error));
            }
            else if (context.Exception is Exception403 forbidden)
            {
                context.Result = new JsonResult(RequestResult.AsError(403, forbidden.Error));
            }
            else if (context.Exception is Exception404 notFound)
            {
                context.Result = new JsonResult(RequestResult.AsError(404, notFound.Error));
            }
            else if (context.Exception is Exception500 serverError)
            {
                context.Result = new JsonResult(RequestResult.AsError(500, serverError.Error));
            }
            else
            {
                context.Result = new JsonResult(RequestResult.AsError(500, $"Произошла ошибка сервера. {context.Exception.ToString()}"));
            }
        }

        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            if (context.Exception is Exception400 badRequest)
            {
                context.Result = new JsonResult(RequestResult.AsError(400, badRequest.Error));
            }
            else if (context.Exception is Exception401 unauthorized)
            {
                context.Result = new JsonResult(RequestResult.AsError(401, unauthorized.Error));
            }
            else if (context.Exception is Exception402 noPayment)
            {
                context.Result = new JsonResult(RequestResult.AsError(402, noPayment.Error));
            }
            else if (context.Exception is Exception403 forbidden)
            {
                context.Result = new JsonResult(RequestResult.AsError(403, forbidden.Error));
            }
            else if (context.Exception is Exception404 notFound)
            {
                context.Result = new JsonResult(RequestResult.AsError(404, notFound.Error));
            }
            else if (context.Exception is Exception500 serverError)
            {
                context.Result = new JsonResult(RequestResult.AsError(500, serverError.Error));
            }
            else
            {
                context.Result = new JsonResult(RequestResult.AsError(500, $"Произошла ошибка сервера. {context.Exception.ToString()}"));
            }
        }
    }
}

using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Core;
using Alfateam.Website.API.Results.StatusCodes;
using Alfateam2._0.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Alfateam.Website.API.Filters
{
    public class ErrorsFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if(context.Result is Result403 forbid)
            {
                context.Result = new JsonResult(RequestResult.AsError(403, forbid.Error));
            }
            else if (context.Result is Result404 notFound)
            {
                context.Result = new JsonResult(RequestResult.AsError(404, notFound.Error));
            }
            else if (context.Result is Result401 unauthorized)
            {
                context.Result = new JsonResult(RequestResult.AsError(401, unauthorized.Error));
            }
            else if (context.Result is Result400 badRequest)
            {
                context.Result = new JsonResult(RequestResult.AsError(400, badRequest.Error));
            }
            else if (context.Result is Result500 serverError)
            {
                context.Result = new JsonResult(RequestResult.AsError(500, serverError.Error));
            }
            else if(context.Result is ObjectResult result)
            {
                if(result.Value is not RequestResult)
                {
                    context.Result = new JsonResult(RequestResult.AsSuccess(result.Value));
                }  
            }
            else if(context.Result is EmptyResult empty)
            {
                context.Result = new JsonResult(RequestResult.AsSuccess("Успех"));
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }
}

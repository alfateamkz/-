using Alfateam.Core.Results.StatusCodes;
using Alfateam.EDM.API.Abstractions;
using Alfateam.EDM.Models.General.Subjects;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Alfateam.EDM.API.Filters
{
    public class MustBeCompany : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.Controller as AbsController;
            if(controller.EDMSubject is not Company)
            {
                context.Result = new Result403("Этот раздел доступен только для бизнеса. Физ.лица\\самозанятые не имеют доступа к данному разделу");
            }
        }
    }
}

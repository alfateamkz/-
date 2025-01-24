using Microsoft.AspNetCore.Mvc.Filters;

namespace Alfateam.AdminPanelGeneral.API.Filters
{
    public class BlogsAccessFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
         
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //TODO: implement BlogsAccessFilter
        }
    }
}

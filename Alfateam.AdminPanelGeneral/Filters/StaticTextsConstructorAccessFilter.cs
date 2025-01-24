using Microsoft.AspNetCore.Mvc.Filters;

namespace Alfateam.AdminPanelGeneral.API.Filters
{
    public class StaticTextsConstructorAccessFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //TODO: implement StaticTextsConstructorAccessFilter
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}

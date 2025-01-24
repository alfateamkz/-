using Microsoft.AspNetCore.Mvc.Filters;

namespace Alfateam.ForPubilcWebsites.API.Filters
{
    public class AuthorizedUserFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
           
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //TODO: implement AuthorizedUserFilter
        }
    }
}

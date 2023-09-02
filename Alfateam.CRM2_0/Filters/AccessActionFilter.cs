using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.General;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Alfateam.CRM2_0.Filters
{
    public class AccessActionFilter : Attribute, IActionFilter
    {
        private List<UserRole> Roles = new List<UserRole>();
        public AccessActionFilter(List<UserRole> roles)
        {
            Roles = roles;
        }
        public AccessActionFilter(params UserRole[] roles)
        {
            Roles = roles.ToList();
        }


        public void OnActionExecuted(ActionExecutedContext context)
        {
         
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.Controller as AbsController;
            var user = controller.GetAuthorizedUser();

            if (user == null || !IsInRole(user))
            {
                context.Result = null; //TODO: результат
            }
        }



        private bool IsInRole(User user)
        {
            if (user.RoleModel.GivenRoles.Any(o => o.Role == UserRole.President)) return true;
            else if (user.RoleModel.GivenRoles.Select(o => o.Role).Intersect(Roles).Count() > 0) return true;

            //TODO: проработать проверку роли

            return false;
        }
    }
}

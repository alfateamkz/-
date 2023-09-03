using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.General;
using Alfateam.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Alfateam.CRM2_0.Filters
{
    public class AccessActionFilter : Attribute, IActionFilter
    {
        private List<UserRole> Roles = new List<UserRole>();
        private AccessActionFilterType Type = AccessActionFilterType.Allowed;


        public AccessActionFilter(List<UserRole> roles, AccessActionFilterType type = AccessActionFilterType.Allowed)
        {
            Roles = roles;
            Type = type;
        }
        public AccessActionFilter(AccessActionFilterType type = AccessActionFilterType.Allowed, params UserRole[] roles)
        {
            Roles = roles.ToList();
            Type = type;
        }


        public void OnActionExecuted(ActionExecutedContext context)
        {
         
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.Controller as AbsController;

            var session = controller.GetCurrentSession();
            var sessionCheckResult = controller.CheckSessionAsRequestResult(session);
            if (!sessionCheckResult.Success)
            {
                context.Result = new JsonResult(sessionCheckResult);
                return;
            }

            var user = controller.GetAuthorizedUser();
            if (user == null)
            {
                context.Result = new JsonResult(RequestResult.AsError(404, "Пользователь с таким id не существует"));
                return;
            }


            if (user.RoleModel.HasRole(UserRole.President)
                || user.RoleModel.HasRole(UserRole.TopManager))
            {
                return;
            }

          


            if (!IsInRole(controller,user))
            {
                context.Result = new JsonResult(RequestResult.AsError(403, "Данный пользователь не имеет прав доступа к данному разделу"));
                return;
            }
            else if(controller.BusinessId == null)
            {
                context.Result = new JsonResult(RequestResult.AsError(400, "Не был передан BusinessId"));
                return;
            }
            else if (!controller.IsInThisBusiness((int)controller.BusinessId, user.Id))
            {
                context.Result = new JsonResult(RequestResult.AsError(403, "Данный пользователь не принадлежит данному бизнесу"));
                return;
            }


            if (!user.RoleModel.HasRole(UserRole.PartnerOrganigationDirector))
            {
                if (controller.OfficeId == null)
                {
                    context.Result = new JsonResult(RequestResult.AsError(400, "Не был передан OfficeId"));
                    return;
                }
                else if (!controller.IsInThisOffice((int)controller.BusinessId, (int)controller.OfficeId, user.Id))
                {
                    context.Result = new JsonResult(RequestResult.AsError(403, "Данный пользователь не принадлежит данному офису"));
                    return;
                }
            }
        }



        private bool IsInRole(AbsController controller,User user)
        {
            foreach(var role in Roles)
            {
                var isInRole = controller.IsInRole(user, role);

                if (Type == AccessActionFilterType.Allowed && isInRole) return true;
                if (Type == AccessActionFilterType.Forbidden && isInRole) return false;


                //TODO: отладить?
            }

            if (Type == AccessActionFilterType.Allowed) return false;
            else if (Type == AccessActionFilterType.Forbidden) return true;

            return false;
        }

      
    }


    public enum AccessActionFilterType
    {
        Allowed = 1,
        Forbidden = 2,
    }
}

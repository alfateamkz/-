using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Core;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Alfateam.Website.API.Filters.Access
{
    public class CheckContentAreaRights : Attribute, IActionFilter
    {
        public ContentAccessModelType Type { get; private set; }
        public int RequiredLevel { get; private set; }
        public CheckContentAreaRights(ContentAccessModelType type, int requiredLevel)
        {
            Type = type;
            RequiredLevel = requiredLevel;
        }



        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var adminController = context.Controller as AbsAdminController;
            var session = adminController.GetSessionWithRoleInclude();


            var sessionCheckResult = SetCheckContentAreaRights(session, Type, RequiredLevel);
            if (!sessionCheckResult.Success)
            {
                context.Result = new JsonResult(sessionCheckResult);
                return;
            }
        }


        private RequestResult SetCheckContentAreaRights(Session session, ContentAccessModelType type, int requiredLevel)
        {
            var res = new RequestResult();

            if (session.User.RoleModel.Role == UserRole.User)
            {
                return res.SetError(403, "У пользователя нет доступа в администраторскую часть");
            }
            if (session.User.RoleModel.Role == UserRole.Owner
                || session.User.RoleModel.Role == UserRole.LocalDirector)
            {
                return res.SetSuccess();
            }


            var userAccess = session.User.RoleModel.GetContentAccess(type);
            if (userAccess == null)
            {
                userAccess = session.User.RoleModel.GetContentAccess(ContentAccessModelType.All);
                if (userAccess == null)
                {
                    return res.SetError(403, "У пользователя нет прав на данный раздел");
                }
            }


            if (userAccess.AccessLevel < requiredLevel)
            {
                switch (requiredLevel)
                {
                    case 1:
                        return res.SetError(403, "У пользователя нет прав на просмотр записей");
                    case 2:
                        return res.SetError(403, "У пользователя нет прав на редактирование записей");
                    case 3:
                        return res.SetError(403, "У пользователя нет прав на редактирование локализаций записей");
                    case 4:
                        return res.SetError(403, "У пользователя нет прав на создание новых записей");
                    case 5:
                        return res.SetError(403, "У пользователя нет прав на удаление записей");
                }
            }

            return res.SetSuccess();
        }
    }
}

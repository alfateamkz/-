using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Departments;
using Alfateam.CRM2_0.Models.General;
using Alfateam.DB;
using Alfateam.Website.API.Controllers.Website;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Alfateam.CRM2_0.Filters
{
    public class DepartmentFilter : Attribute, IActionFilter
    {
        private const string HEADER = "DepartmentId";
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
                context.Result = new JsonResult(RequestResult.AsError(401, "Не авторизован - прочее"));
                return;
            }

            if (!controller.Request.Headers.ContainsKey(HEADER))
            {
                context.Result = new JsonResult(RequestResult.AsError(400, $"Не передан Header {HEADER}"));
                return;
            }

            int departmentId = 0;
            string hrDepartmentIdStr = controller.Request.Headers[HEADER];    
            if(!int.TryParse(hrDepartmentIdStr,out departmentId))
            {
                context.Result = new JsonResult(RequestResult.AsError(400, $"Некорректное значение в Header {HEADER}"));
                return;
            }

            var department = controller.DB.Departments.FirstOrDefault(o => o.Id == departmentId);
            if(department == null)
            {
                context.Result = new JsonResult(RequestResult.AsError(404, "Департамент с таким id не найден"));
                return;
            }

            if (controller.DB.DepartmentsMethods.HasAccessToDepartment(user,departmentId))
            {
                context.Result = new JsonResult(RequestResult.AsError(403, "Нет доступа к данному департаменту"));
                return;
            }

        }

       

    }
}

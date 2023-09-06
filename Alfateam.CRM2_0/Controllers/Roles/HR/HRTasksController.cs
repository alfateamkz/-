using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.Enums;

namespace Alfateam.CRM2_0.Controllers.Roles.HR
{
    [DepartmentFilter]
    [AccessActionFilter(roles: UserRole.HR)]
    public class HRTasksController : AbsController
    {
        public HRTasksController(ControllerParams @params) : base(@params)
        {
        }

        //TODO: Задачи HR менеджерам
    }
}

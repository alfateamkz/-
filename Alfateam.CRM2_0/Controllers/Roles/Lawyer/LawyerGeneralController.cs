using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.Enums;

namespace Alfateam.CRM2_0.Controllers.Roles.Lawyer
{
    [DepartmentFilter]
    [AccessActionFilter(roles: UserRole.Lawyer)]
    public class LawyerGeneralController : AbsController
    {
        public LawyerGeneralController(ControllerParams @params) : base(@params)
        {
        }
    }
}

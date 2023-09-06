using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.Enums;

namespace Alfateam.CRM2_0.Controllers.Roles.Accountance
{
    [AccessActionFilter(roles: UserRole.Accountant)]
    [DepartmentFilter]
    public class TransactionsController : AbsController
    {
        public TransactionsController(ControllerParams @params) : base(@params)
        {
        }
    }
}

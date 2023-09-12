using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;

using Alfateam.CRM2_0.Models.Enums;
namespace Alfateam.CRM2_0.Controllers.Roles.Compliance
{
	[DepartmentFilter]
	[AccessActionFilter(roles: UserRole.Compliance)]
	public class ComplianceLawController : AbsController
	{
		public ComplianceLawController(ControllerParams @params) : base(@params)
		{
		}
	}
}

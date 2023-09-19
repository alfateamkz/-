using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.ClientModels.General;
using Alfateam.CRM2_0.Models.CreateModels.General;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Sales
{
	public class CustomerCreateModel : UserCreateModel
	{
		public int FormId { get; set; }
		public int? CompanyId { get; set; }
	}
}

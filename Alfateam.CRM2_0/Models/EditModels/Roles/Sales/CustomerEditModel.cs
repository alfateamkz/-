using Alfateam.CRM2_0.Models.EditModels.General;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.Sales
{
	public class CustomerEditModel : UserEditModel
	{
		public int FormId { get; set; }
		public int? CompanyId { get; set; }
	}
}

using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Sales.Plan;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Sales.Plan
{
	public class SalesPlanClientModel : ClientModel<SalesPlan>
	{
		public string Title { get; set; }
		public string? Description { get; set; }
	}
}

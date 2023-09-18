using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Sales.Plan;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.Sales.Plan
{
	public class SalesPlanEditModel : EditModel<SalesPlan>
	{
		public string Title { get; set; }
		public string? Description { get; set; }
	}
}

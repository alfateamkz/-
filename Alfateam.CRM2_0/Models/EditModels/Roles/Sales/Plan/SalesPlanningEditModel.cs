using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Sales.Plan;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.Sales.Plan
{
	public class SalesPlanningEditModel : EditModel<SalesPlanning>
	{
		public string Title { get; set; }
		public string? Description { get; set; }

	}
}

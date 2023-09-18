using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Sales.Plan;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Sales.Plan
{
	public class SalesPlanningCreateModel : CreateModel<SalesPlanning>
	{
		public string Title { get; set; }
		public string? Description { get; set; }


		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
	}
}

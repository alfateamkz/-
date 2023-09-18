using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Sales.Plan;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Sales.Plan
{
	public class SalesPlanItemCreateModel : CreateModel<SalesPlanItem>
	{
		public string Title { get; set; }
		public string? Description { get; set; }


		public int SalesCount { get; set; }
		public double SumOfSales { get; set; }
		public double AverageCheque { get; set; }
	}
}

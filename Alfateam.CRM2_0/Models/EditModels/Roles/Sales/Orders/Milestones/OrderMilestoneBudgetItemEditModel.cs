using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Sales.Orders.Milestones;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.Sales.Orders.Milestones
{
	public class OrderMilestoneBudgetItemEditModel : EditModel<OrderMilestoneBudgetItem>
	{
		public string Title { get; set; }
		public double Sum { get; set; }
	}
}

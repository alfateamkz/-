using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Sales.Orders.Milestones;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Sales.Orders.Milestones
{
	public class OrderMilestoneBudgetItemClientModel : ClientModel<OrderMilestoneBudgetItem>
	{
		public string Title { get; set; }
		public double Sum { get; set; }
	}
}

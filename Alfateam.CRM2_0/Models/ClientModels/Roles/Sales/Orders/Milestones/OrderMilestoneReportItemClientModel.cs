using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Sales.Orders;
using Alfateam.CRM2_0.Models.Roles.Sales.Orders.Milestones;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Sales.Orders.Milestones
{
	public class OrderMilestoneReportItemClientModel : ClientModel<OrderMilestoneReportItem>
	{
		public OrderTaskClientModel Task { get; set; }


		public string Comment { get; set; }
	}
}

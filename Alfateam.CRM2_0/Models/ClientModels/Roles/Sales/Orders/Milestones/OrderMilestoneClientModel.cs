using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Sales.Orders;
using Alfateam.CRM2_0.Models.Roles.Sales.Orders.Milestones;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Sales.Orders.Milestones
{
	public class OrderMilestoneClientModel : ClientModel<OrderMilestone>
	{
		public string Title { get; set; }
		public string? Description { get; set; }
		public double Price { get; set; }

		public DateTime StartDate { get; set; }
		public DateTime Deadline { get; set; }


		public OrderMilestoneStatus Status { get; set; }
	}
}

using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Sales.Orders.Milestones;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.Sales.Orders.Milestones
{
	public class OrderMilestoneEditModel : EditModel<OrderMilestone>
	{
		public string Title { get; set; }
		public string? Description { get; set; }
		public double Price { get; set; }

		public DateTime StartDate { get; set; }
		public DateTime Deadline { get; set; }
	}
}

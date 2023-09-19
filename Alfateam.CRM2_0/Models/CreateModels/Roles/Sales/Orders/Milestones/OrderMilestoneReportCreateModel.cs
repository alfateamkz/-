using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Sales.Orders.Milestones;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Sales.Orders.Milestones
{
	public class OrderMilestoneReportCreateModel : CreateModel<OrderMilestoneReport>
	{
		public string Title { get; set; }
		public string? Description { get; set; }
	}
}

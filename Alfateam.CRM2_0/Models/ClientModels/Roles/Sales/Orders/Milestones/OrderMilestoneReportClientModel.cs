using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.ClientModels.General;
using Alfateam.CRM2_0.Models.Roles.Sales.Orders.Milestones;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Sales.Orders.Milestones
{
	public class OrderMilestoneReportClientModel : ClientModel<OrderMilestoneReport>
	{
		public string Title { get; set; }
		public string? Description { get; set; }

		public UserClientModel CreatedBy { get; set; }
	}
}

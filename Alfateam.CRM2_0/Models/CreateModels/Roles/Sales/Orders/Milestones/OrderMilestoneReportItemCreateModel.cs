using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Sales.Orders.Milestones;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Sales.Orders.Milestones
{
	public class OrderMilestoneReportItemCreateModel : CreateModel<OrderMilestoneReportItem>
	{
		public int TaskId { get; set; }


		public string Comment { get; set; }
	}
}

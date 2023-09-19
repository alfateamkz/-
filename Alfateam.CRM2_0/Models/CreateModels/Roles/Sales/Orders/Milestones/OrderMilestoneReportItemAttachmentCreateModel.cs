using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Sales.Orders.Milestones;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Sales.Orders.Milestones
{
	public class OrderMilestoneReportItemAttachmentCreateModel : CreateModel<OrderMilestoneReportItemAttachment>
	{
		public string? Comment { get; set; }
	}
}

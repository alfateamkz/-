using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Sales.Orders.Milestones;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Sales.Orders.Milestones
{
	public class OrderMilestoneReportItemAttachmentClientModel : ClientModel<OrderMilestoneReportItemAttachment>
	{
		public string? Comment { get; set; }
		public string AttachmentPath { get; set; }
	}
}

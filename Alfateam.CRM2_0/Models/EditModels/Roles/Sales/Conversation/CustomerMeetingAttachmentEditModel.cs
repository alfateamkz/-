using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Sales.Conversation;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.Sales.Conversation
{
	public class CustomerMeetingAttachmentEditModel : EditModel<CustomerMeetingAttachment>
	{
		public string? Comment { get; set; }
	}
}

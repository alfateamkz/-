using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Sales.Conversation;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Sales.Conversation
{
	public class CustomerMeetingAttachmentCreateModel : CreateModel<CustomerMeetingAttachment>
	{
		public string? Comment { get; set; }
	}
}

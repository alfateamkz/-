using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Sales.Conversation;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Sales.Conversation
{
	public class CustomerMeetingAttachmentClientModel : ClientModel<CustomerMeetingAttachment>
	{
		public string Filepath { get; set; }
		public string? Comment { get; set; }
	}
}

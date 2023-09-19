using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Communication.Messenger;

namespace Alfateam.CRM2_0.Models.ClientModels.Communication.Messenger
{
	public class ChatMessageAttachmentClientModel : ClientModel<ChatMessageAttachment>
	{
		public string AttachmentPath { get; set; }
	}
}

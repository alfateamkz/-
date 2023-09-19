using Alfateam.CRM2_0.Models.CreateModels.Abstractions.Communication.Messenger;

namespace Alfateam.CRM2_0.Models.CreateModels.Communication.Messenger.Messages
{
	public class VoiceMessageCreateModel : MessageCreateModel
	{
		public byte[] Data { get; set; }
	}
}

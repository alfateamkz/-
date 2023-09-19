using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.ClientModels.Abstractions.Communication.Messenger;
using Alfateam.CRM2_0.Models.Communication.Messenger.Messages;

namespace Alfateam.CRM2_0.Models.ClientModels.Communication.Messenger.Messages
{
	public class CommonMessageClientModel : MessageClientModel
	{
		public string Message { get; set; }
	}
}

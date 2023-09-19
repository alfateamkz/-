using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.ClientModels.Abstractions.Communication.Messenger;
using Alfateam.CRM2_0.Models.ClientModels.General;
using Alfateam.CRM2_0.Models.Communication.Messenger;
using Alfateam.CRM2_0.Models.Communication.Messenger.Chats;

namespace Alfateam.CRM2_0.Models.ClientModels.Communication.Messenger.Chats
{
    public class GroupChatClientModel : ChatClientModel
	{
		public string Title { get; set; }
		public UserClientModel CreatedBy { get; set; }

        public List<GroupChatUserInfoClientModel> Members { get; set; } = new List<GroupChatUserInfoClientModel>();
    }
}

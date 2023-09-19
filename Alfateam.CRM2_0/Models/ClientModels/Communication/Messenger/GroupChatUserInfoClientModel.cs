using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.ClientModels.General;
using Alfateam.CRM2_0.Models.Communication.Messenger;
using Alfateam.CRM2_0.Models.Enums.Communication.Messenger;

namespace Alfateam.CRM2_0.Models.ClientModels.Communication.Messenger
{
	public class GroupChatUserInfoClientModel : ClientModel<GroupChatUserInfo>
	{
		public UserClientModel User { get; set; }
		public GroupChatUserRole Role { get; set; } = GroupChatUserRole.User;
	}
}

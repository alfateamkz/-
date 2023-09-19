using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Communication.Messenger;
using Alfateam.CRM2_0.Models.Enums.Communication.Messenger;

namespace Alfateam.CRM2_0.Models.CreateModels.Communication.Messenger
{
	public class GroupChatUserInfoCreateModel : CreateModel<GroupChatUserInfo>
	{
		public int UserId { get; set; }
		public GroupChatUserRole Role { get; set; } = GroupChatUserRole.User;
	}
}

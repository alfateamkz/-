using Alfateam.CRM2_0.Models.Abstractions.Communication.Messenger;
using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Communication.Messenger.Chats
{
	/// <summary>
	/// Модель группового чата
	/// </summary>
	public class GroupChat : Chat
    {
        public string Title { get; set; }


        public User CreatedBy { get; set; }
		public int CreatedById { get; set; }

		public List<GroupChatUserInfo> Members { get; set; } = new List<GroupChatUserInfo>();






        /// <summary>
        /// Автоматическое поле. Чат может быть связан с заказом
        /// </summary>
        public int? OrderId { get; set; }

		public override bool HasUserAccess(int userId)
		{
			if (CreatedById == userId)
			{
				return true;
			}

			var member = Members.FirstOrDefault(o => o.UserId == userId);
			if (member == null)
			{
				return false;
			}

			return member.IsInChat && !member.IsKicked;
		}
	}
}

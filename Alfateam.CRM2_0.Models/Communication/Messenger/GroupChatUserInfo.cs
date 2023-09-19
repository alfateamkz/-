using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Communication.Messenger;
using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Communication.Messenger
{
    /// <summary>
    /// Модель члена группового чата
    /// </summary>
    public class GroupChatUserInfo : AbsModel
    {
        public User User { get; set; }
		public int UserId { get; set; }


		public GroupChatUserRole Role { get; set; } = GroupChatUserRole.User;

        public bool IsInChat { get; set; }


        public bool IsKicked { get; set; }
        public DateTime? KickedAt { get; set; }



        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int GroupChatId { get; set; }

	}
}

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
        public User CreatedBy { get; set; }

        public List<GroupChatUserInfo> Members { get; set; } = new List<GroupChatUserInfo>();
    }
}

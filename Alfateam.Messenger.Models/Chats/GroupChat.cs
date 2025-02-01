using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.General.GroupChats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Chats
{
    public class GroupChat : ChatBase
    {
        public string Title { get; set; }
        public string? ImagePath { get; set; }

        public List<GroupChatMemberBase> Members { get; set; } = new List<GroupChatMemberBase>();
    }
}

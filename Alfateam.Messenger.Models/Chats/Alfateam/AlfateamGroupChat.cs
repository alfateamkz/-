using Alfateam.Messenger.Models.Abstractions.Chats;
using Alfateam.Messenger.Models.General.GroupChats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Chats.Alfateam
{
    public class AlfateamGroupChat : AlfateamMessengerChat
    {
        public string Title { get; set; }
        public string? ImagePath { get; set; }



        public List<GroupChatMember> Members { get; set; } = new List<GroupChatMember>();
    }
}

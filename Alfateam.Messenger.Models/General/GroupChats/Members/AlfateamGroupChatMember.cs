using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.Accounts;
using Alfateam.Messenger.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.General.GroupChats.Members
{
    public class AlfateamGroupChatMember : GroupChatMemberBase
    {
        public Peer Peer { get; set; }
        public int PeerId { get; set; }


        public GroupChatMemberRole Role { get; set; }
        public GroupChatMemberPermissions Permissions { get; set; }
        public bool IsKicked { get; set; }
    }
}

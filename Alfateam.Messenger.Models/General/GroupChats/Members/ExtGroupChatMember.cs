using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.Peers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.General.GroupChats.Members
{
    public class ExtGroupChatMember : GroupChatMemberBase
    {
        public ExtMessengerPeer Peer { get; set; }
        public int PeerId { get; set; }


        public string Role { get; set; }
    }
}

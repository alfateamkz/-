using Alfateam.Messenger.Models.DTO.Abstractions;
using Alfateam.Messenger.Models.DTO.Peers;
using Alfateam.Messenger.Models.Peers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.General.GroupChats.Members
{
    public class ExtGroupChatMemberDTO : GroupChatMemberBaseDTO
    {
        public ExtMessengerPeerDTO Peer { get; set; }
        public int PeerId { get; set; }


        public string Role { get; set; }
    }
}

using Alfateam.Messenger.Models.DTO.Abstractions;
using Alfateam.Messenger.Models.Enums;
using Alfateam.Messenger.Models.General.GroupChats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.General.GroupChats.Members
{
    public class AlfateamGroupChatMemberDTO : GroupChatMemberBaseDTO
    {
        public PeerDTO Peer { get; set; }
        public int PeerId { get; set; }


        public GroupChatMemberRole Role { get; set; }
        public GroupChatMemberPermissionsDTO Permissions { get; set; }
        public bool IsKicked { get; set; }
    }
}

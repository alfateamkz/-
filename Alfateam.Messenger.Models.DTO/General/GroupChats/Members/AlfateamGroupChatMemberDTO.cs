using Alfateam.Core.Attributes.DTO;
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
        [DTOFieldFor(DTOFieldForType.CreationOnly)]
        public PeerDTO Peer { get; set; }



        public GroupChatMemberRole Role { get; set; }
        public GroupChatMemberPermissionsDTO Permissions { get; set; }
    }
}

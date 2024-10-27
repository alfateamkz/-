using Alfateam.Core.Attributes.DTO;
using Alfateam.Messenger.Models.Enums;
using Alfateam.Messenger.Models.General.GroupChats;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.General.GroupChats
{
    public class GroupChatMemberDTO : DTOModelAbs<GroupChatMember>
    {
        [ForClientOnly]
        public UserDTO User { get; set; }


        public GroupChatMemberRole Role { get; set; }
        public GroupChatMemberPermissionsDTO Permissions { get; set; }


        [ForClientOnly]
        public bool IsKicked { get; set; }
    }
}

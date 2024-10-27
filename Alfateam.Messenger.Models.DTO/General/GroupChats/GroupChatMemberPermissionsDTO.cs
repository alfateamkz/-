using Alfateam.Messenger.Models.General.GroupChats;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.General.GroupChats
{
    public class GroupChatMemberPermissionsDTO : DTOModelAbs<GroupChatMemberPermissions>
    {
        public bool CanSendMessages { get; set; }
        public bool CanSendFilesAndAttachments { get; set; }
        public bool CanAddMembers { get; set; }
        public bool CanKickMembers { get; set; }
        public bool CanPinMessages { get; set; }
        public bool CanEditChatInfo { get; set; }
    }
}

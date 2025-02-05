using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.General.GroupChats
{
    //TODO: check GroupChatMemberPermissions in project
    public class GroupChatMemberPermissions : AbsModel
    {
        public bool CanSendMessages { get; set; } = true;
        public bool CanSendFilesAndAttachments { get; set; } = true;
        public bool CanAddMembers { get; set; } = true;
        public bool CanKickMembers { get; set; } = true;
        public bool CanPinMessages { get; set; } = true;
        public bool CanEditChatInfo { get; set; } = true;
    }
}

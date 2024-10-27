using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.General.GroupChats
{
    public class GroupChatMemberPermissions : AbsModel
    {
        public bool CanSendMessages { get; set; }
        public bool CanSendFilesAndAttachments { get; set; }
        public bool CanAddMembers { get; set; }
        public bool CanKickMembers { get; set; }
        public bool CanPinMessages { get; set; }
        public bool CanEditChatInfo { get; set; }
    }
}

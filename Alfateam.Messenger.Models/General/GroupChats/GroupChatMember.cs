using Alfateam.Core;
using Alfateam.Messenger.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.General.GroupChats
{
    public class GroupChatMember : AbsModel
    {
        public User User { get; set; }
        public int UserId { get; set; }


        public GroupChatMemberRole Role { get; set; }
        public GroupChatMemberPermissions Permissions { get; set; }
        public bool IsKicked { get; set; }
    }
}

using Alfateam.Messenger.Models.Abstractions.Messages;
using Alfateam.Messenger.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Messages.SystemMessages
{
    public class GroupChatCreatedMessage : SystemMessage
    {
        public User CreatedBy { get; set; }
        public int CreatedById { get; set; }



        public string GroupTitle { get; set; }
    }
}

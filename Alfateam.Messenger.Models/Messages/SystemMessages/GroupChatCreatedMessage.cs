using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.Abstractions.Messages;
using Alfateam.Messenger.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Messages.SystemMessages
{
    public class GroupChatCreatedMessage : SystemMessage
    {
        public Peer? CreatedBy { get; set; }
        public int? CreatedById { get; set; }



        public string? GroupTitle { get; set; }
    }
}

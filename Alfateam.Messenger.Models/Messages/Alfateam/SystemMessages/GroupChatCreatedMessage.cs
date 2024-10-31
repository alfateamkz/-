using Alfateam.Messenger.Models.Abstractions.Messages.Alfateam;
using Alfateam.Messenger.Models.Accounts;
using Alfateam.Messenger.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Messages.Alfateam.SystemMessages
{
    public class GroupChatCreatedMessage : AlfateamMessengerSystemMessage
    {
        public AlfateamMessengerAccount CreatedBy { get; set; }
        public int CreatedById { get; set; }



        public string GroupTitle { get; set; }
    }
}

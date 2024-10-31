using Alfateam.Messenger.Models.Abstractions.Messages.External;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Messages.External.SystemMessages
{
    public class ExtGroupChatCreatedMessage : ExternalMessengerSystemMessage
    {
        public string? CreatedById { get; set; }
        public string GroupTitle { get; set; }
    }
}

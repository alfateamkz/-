using Alfateam.Messenger.Models.Abstractions.Messages.External;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Messages.External.SystemMessages
{
    public class ExtJoinedUserMessage : ExternalMessengerSystemMessage
    {
        public string? UserId { get; set; }
    }
}

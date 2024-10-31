using Alfateam.Messenger.Models.Abstractions.Messages.External;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Messages.External.SystemMessages
{
    public class ExtKickedUserMessage : ExternalMessengerSystemMessage
    {
        public string? KickedUserId { get; set; }
        public string? KickedById { get; set; }
    }
}

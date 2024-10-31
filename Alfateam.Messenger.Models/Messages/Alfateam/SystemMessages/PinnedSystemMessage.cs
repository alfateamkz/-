using Alfateam.Messenger.Models.Abstractions.Messages.Alfateam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Messages.Alfateam.SystemMessages
{
    public class PinnedSystemMessage : AlfateamMessengerSystemMessage
    {
        public AlfateamMessengerUserMessage Message { get; set; }
        public int MessageId { get; set; }
    }
}

using Alfateam.Messenger.Models.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Messages.SystemMessages
{
    public class PinnedSystemMessage : SystemMessage
    {
        public MessageBase Message { get; set; }
        public int MessageId { get; set; }
    }
}

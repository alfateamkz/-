using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Abstractions.Messages
{
    public class UserMessage : MessageBase
    {
        public Peer SentBy { get; set; }
        public int SentById { get; set; }

        public List<MessageBase> ForwardedMessages { get; set; } = new List<MessageBase>();
    }
}

using Alfateam.Messenger.Models.Accounts;
using Alfateam.Messenger.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Abstractions.Messages.Alfateam
{
    public class AlfateamMessengerUserMessage : Message
    {
        public AlfateamMessengerAccount SentBy { get; set; }
        public int SentById { get; set; }


        public List<Message> Forwarded { get; set; } = new List<Message>();
    }
}

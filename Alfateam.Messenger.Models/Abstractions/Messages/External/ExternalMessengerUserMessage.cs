using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Abstractions.Messages.External
{
    public class ExternalMessengerUserMessage : ExternalMessengerMessage
    {
        public string SentById { get; set; }
        public List<ExternalMessengerMessage> Forwarded { get; set; } = new List<ExternalMessengerMessage>();
    }
}

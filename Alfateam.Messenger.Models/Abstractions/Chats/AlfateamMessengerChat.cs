using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Messenger.Models.Abstractions.Messages;
using Alfateam.Messenger.Models.Abstractions.Messages.Alfateam;

namespace Alfateam.Messenger.Models.Abstractions.Chats
{
    public class AlfateamMessengerChat : Chat
    {
        public List<AlfateamMessengerMessage> Messages { get; set; } = new List<AlfateamMessengerMessage>();
    }
}

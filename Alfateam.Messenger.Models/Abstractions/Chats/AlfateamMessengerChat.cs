using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Messenger.Models.Abstractions.Messages;

namespace Alfateam.Messenger.Models.Abstractions.Chats
{
    public class AlfateamMessengerChat : Chat
    {
        public List<Message> Messages { get; set; } = new List<Message>();
    }
}

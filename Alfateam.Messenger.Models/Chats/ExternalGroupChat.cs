using Alfateam.Messenger.Models.Abstractions.Chats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Chats
{
    public class ExternalGroupChat : ExternalMessengerChat
    {
        public string? AdminId { get; set; }
        public int ParticipantsCount { get; set; }
    }
}

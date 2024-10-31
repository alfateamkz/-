using Alfateam.Messenger.Models.Abstractions.Messages.Alfateam;
using Alfateam.Messenger.Models.Accounts;
using Alfateam.Messenger.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Messages.Alfateam.SystemMessages
{
    public class JoinedUserMessage : AlfateamMessengerSystemMessage
    {
        public AlfateamMessengerAccount User { get; set; }
        public int UserId { get; set; }
    }
}

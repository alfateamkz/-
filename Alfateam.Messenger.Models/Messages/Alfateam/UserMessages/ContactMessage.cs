using Alfateam.Messenger.Models.Abstractions.Messages.Alfateam;
using Alfateam.Messenger.Models.Accounts;
using Alfateam.Messenger.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Messages.Alfateam.UserMessages
{
    public class ContactMessage : AlfateamMessengerUserMessage
    {
        public AlfateamMessengerAccount ContactOf { get; set; }
        public int ContactOfId { get; set; }
    }
}

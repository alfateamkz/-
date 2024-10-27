using Alfateam.Messenger.Models.Abstractions.Messages;
using Alfateam.Messenger.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Messages.UserMessages
{
    public class ContactMessage : UserMessage
    {
        public User ContactOf { get; set; }
        public int ContactOfId { get; set; }
    }
}

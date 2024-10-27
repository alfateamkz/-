using Alfateam.Messenger.Models.Abstractions.Messages;
using Alfateam.Messenger.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Messages.SystemMessages
{
    public class JoinedUserMessage : SystemMessage
    {
        public User User { get; set; }
        public int UserId { get; set; }
    }
}

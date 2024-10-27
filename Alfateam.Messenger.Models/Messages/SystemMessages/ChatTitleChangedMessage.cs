using Alfateam.Messenger.Models.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Messages.SystemMessages
{
    public class ChatTitleChangedMessage : SystemMessage
    {
        public string NewTitle { get; set; }
    }
}

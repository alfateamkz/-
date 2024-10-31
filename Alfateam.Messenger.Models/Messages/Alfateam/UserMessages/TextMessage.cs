using Alfateam.Messenger.Models.Abstractions.Attachments;
using Alfateam.Messenger.Models.Abstractions.Messages.Alfateam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Messages.Alfateam.UserMessages
{
    public class TextMessage : AlfateamMessengerUserMessage
    {
        public string Text { get; set; }
        public List<AlfateamMessageAttachment> Attachments { get; set; } = new List<AlfateamMessageAttachment>();
    }
}

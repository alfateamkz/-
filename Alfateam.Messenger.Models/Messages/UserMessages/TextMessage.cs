using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Messages.UserMessages
{
    public class TextMessage : UserMessage
    {
        public string Text { get; set; }
        public List<MessageAttachmentBase> Attachments { get; set; } = new List<MessageAttachmentBase>();
    }
}

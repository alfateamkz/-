using Alfateam.Messenger.Models.Abstractions.Attachments;
using Alfateam.Messenger.Models.Abstractions.Messages.External;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Messages.External.UserMessages
{
    public class ExtTextMessage : ExternalMessengerUserMessage
    {
        public string Text { get; set; }
        public List<ExternalMessageAttachment> Attachments { get; set; } = new List<ExternalMessageAttachment>();
    }
}

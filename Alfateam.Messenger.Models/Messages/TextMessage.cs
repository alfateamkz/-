using Alfateam.Messenger.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Messages
{
    public class TextMessage : Message
    {
        public string Text { get; set; }
        public List<AbsMessageAttachment> Attachments { get; set; } = new List<AbsMessageAttachment>();
    }
}

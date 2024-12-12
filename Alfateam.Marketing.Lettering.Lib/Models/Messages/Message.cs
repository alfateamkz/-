using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Lettering.Lib.Models.Messages
{
    public class Message
    {
        public string? Text { get; set; }
        public List<MessageAttachment> Attachments { get; set; } = new List<MessageAttachment>();
    }
}

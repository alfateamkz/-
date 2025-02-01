using Alfateam.Messenger.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.MessageAttachments
{
    public class URLMessageAttachment : MessageAttachmentBase
    {
        public string URL { get; set; }
    }
}

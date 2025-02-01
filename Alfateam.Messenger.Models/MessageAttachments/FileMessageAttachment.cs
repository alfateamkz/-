using Alfateam.Messenger.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.MessageAttachments
{
    public class FileMessageAttachment : MessageAttachmentBase
    {
        public string File { get; set; }
    }
}

using Alfateam.Core;
using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Attachments
{
    public class FileMessageAttachment : MessageAttachment
    {
        public string DisplayedFilename { get; set; }
        public FileAttachmentType Type { get; set; }
        public string Filepath { get; set; }
    }
}

using Alfateam.Messenger.Models.DTO.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.MessageAttachments
{
    public class FileMessageAttachmentDTO : MessageAttachmentBaseDTO
    {
        public string File { get; set; }
    }
}

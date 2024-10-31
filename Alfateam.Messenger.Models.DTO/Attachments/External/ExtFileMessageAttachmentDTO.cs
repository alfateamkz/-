using Alfateam.Core.Attributes.DTO;
using Alfateam.Messenger.Models.DTO.Abstractions.Attachments;
using Alfateam.Messenger.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Attachments.External
{
    public class ExtFileMessageAttachmentDTO : ExternalMessageAttachmentDTO
    {
        [ForClientOnly]
        public string DisplayedFilename { get; set; }

        public FileAttachmentType Type { get; set; }


        [ForClientOnly]
        public string Filepath { get; set; }
    }
}

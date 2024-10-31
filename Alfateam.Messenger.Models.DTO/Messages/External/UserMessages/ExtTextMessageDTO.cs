using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.DTO.Abstractions.Attachments;
using Alfateam.Messenger.Models.DTO.Abstractions.Messages.External;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Messages.External.UserMessages
{
    public class ExtTextMessageDTO : ExternalMessengerUserMessageDTO
    {
        public string Text { get; set; }
        public List<ExternalMessageAttachmentDTO> Attachments { get; set; } = new List<ExternalMessageAttachmentDTO>();
    }
}

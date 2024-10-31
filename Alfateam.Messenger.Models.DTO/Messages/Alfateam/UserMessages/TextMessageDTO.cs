using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.DTO.Abstractions.Attachments;
using Alfateam.Messenger.Models.DTO.Abstractions.Messages.Alfateam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Messages.Alfateam.UserMessages
{
    public class TextMessageDTO : AlfateamMessengerUserMessageDTO
    {
        public string Text { get; set; }
        public List<AlfateamMessageAttachmentDTO> Attachments { get; set; } = new List<AlfateamMessageAttachmentDTO>();
    }
}

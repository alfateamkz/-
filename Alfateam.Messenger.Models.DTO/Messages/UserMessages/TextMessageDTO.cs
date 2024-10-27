using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.DTO.Abstractions;
using Alfateam.Messenger.Models.DTO.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Messages.UserMessages
{
    public class TextMessageDTO : UserMessageDTO
    {
        public string Text { get; set; }
        public List<MessageAttachmentDTO> Attachments { get; set; } = new List<MessageAttachmentDTO>();
    }
}

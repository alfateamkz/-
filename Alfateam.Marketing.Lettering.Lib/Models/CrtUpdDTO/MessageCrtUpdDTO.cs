using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Lettering.Lib.Models.CrtUpdDTO
{
    public class MessageCrtUpdDTO
    {
        public string? Text { get; set; }
        public List<MessageAttachmentCrtUpdDTO> Attachments { get; set; } = new List<MessageAttachmentCrtUpdDTO>();
    }
}

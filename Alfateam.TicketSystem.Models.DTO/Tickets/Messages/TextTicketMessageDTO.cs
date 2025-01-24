using Alfateam.TicketSystem.Models.DTO.Abstractions;
using Alfateam.TicketSystem.Models.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models.DTO.Tickets.Messages
{
    public class TextTicketMessageDTO : TicketMessageDTO
    {
        public string Text { get; set; }
        public List<TicketMessageAttachmentDTO> Attachments { get; set; } = new List<TicketMessageAttachmentDTO>();


        public override bool IsValid()
        {
            return !string.IsNullOrEmpty(Text)
                || string.IsNullOrEmpty(Text) && Attachments.Any();
        }
    }
}

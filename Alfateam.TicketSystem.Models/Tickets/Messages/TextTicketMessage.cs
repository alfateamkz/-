using Alfateam.TicketSystem.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models.Tickets.Messages
{

    public class TextTicketMessage : TicketMessage
    {
        public string Text { get; set; }
        public List<TicketMessageAttachment> Attachments { get; set; } = new List<TicketMessageAttachment>();
    }
}

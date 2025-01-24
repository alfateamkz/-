using Alfateam.TicketSystem.Models.DTO.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models.DTO.Tickets.Senders
{
    public class TicketMessageAnonymSenderDTO : TicketMessageSenderDTO
    {
        public string IP { get; set; }
        public string UserAgent { get; set; }
        public string Fingerprint { get; set; }
    }
}

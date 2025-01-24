using Alfateam.TicketSystem.Models.DTO.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models.DTO.Tickets.Senders
{
    public class TicketMessageCustomerSenderDTO : TicketMessageSenderDTO
    {
        public string Identifier { get; set; }
    }
}

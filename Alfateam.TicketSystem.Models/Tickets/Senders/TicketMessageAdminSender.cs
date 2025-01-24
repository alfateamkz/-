using Alfateam.TicketSystem.Models.Abstractions;
using Alfateam.TicketSystem.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models.Tickets.Senders
{
    public class TicketMessageAdminSender : TicketMessageSender
    {
        public User User { get; set; }
        public int UserId { get; set; }
    }
}

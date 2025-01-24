using Alfateam.TicketSystem.Models.Abstractions;
using Alfateam.TicketSystem.Models.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models.General.Notifications
{
    public class NewTicketUserNotification : UserNotification
    {
        public Ticket Ticket { get; set; }
        public int TicketId { get; set; }
    }
}

using Alfateam.Core.Attributes.DTO;
using Alfateam.TicketSystem.Models.DTO.Abstractions;
using Alfateam.TicketSystem.Models.DTO.Tickets;
using Alfateam.TicketSystem.Models.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models.DTO.General.Notifications
{
    public class NewTicketUserNotificationDTO : UserNotificationDTO
    {
        [ForClientOnly]
        public TicketDTO Ticket { get; set; }
    }
}

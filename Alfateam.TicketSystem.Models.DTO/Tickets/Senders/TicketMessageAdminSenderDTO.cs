using Alfateam.Core.Attributes.DTO;
using Alfateam.TicketSystem.Models.DTO.Abstractions;
using Alfateam.TicketSystem.Models.DTO.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models.DTO.Tickets.Senders
{
    public class TicketMessageAdminSenderDTO : TicketMessageSenderDTO
    {
        [ForClientOnly]
        public UserDTO User { get; set; }
    }
}

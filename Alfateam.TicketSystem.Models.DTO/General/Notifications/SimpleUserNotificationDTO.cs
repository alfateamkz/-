using Alfateam.Core.Attributes.DTO;
using Alfateam.TicketSystem.Models.DTO.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models.DTO.General.Notifications
{
    public class SimpleUserNotificationDTO : UserNotificationDTO
    {
        [ForClientOnly]
        public string Text { get; set; }
    }
}

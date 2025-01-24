using Alfateam.TicketSystem.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models.General.Notifications
{
    public class SimpleUserNotification : UserNotification
    {
        public string Text { get; set; }
    }
}

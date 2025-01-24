using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models.Enums
{
    public enum TicketStatus
    {
        New = 1,
        Answered = 2,
        Open = 3,
        Postponed = 4,

        Closed = 999
    }
}

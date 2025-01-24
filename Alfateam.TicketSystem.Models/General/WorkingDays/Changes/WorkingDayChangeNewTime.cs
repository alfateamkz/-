using Alfateam.TicketSystem.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models.General.WorkingDays.Changes
{
    public class WorkingDayChangeNewTime : WorkingDayChange
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}

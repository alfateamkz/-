using Alfateam.TicketSystem.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models.General.WorkingDays.Changes
{
    public class WorkingDayChangeDayOff : WorkingDayChange
    {
        public string? DayOffName { get; set; }
    }
}

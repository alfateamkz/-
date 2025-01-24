using Alfateam.TicketSystem.Models.DTO.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models.DTO.General.WorkingDays.Changes
{
    public class WorkingDayChangeNewTimeDTO : WorkingDayChangeDTO
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}

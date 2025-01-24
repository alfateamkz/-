using Alfateam.TicketSystem.Models.General.WorkingDays;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models.DTO.General.WorkingDays
{
    public class CompanyWorkingDayDTO : DTOModelAbs<CompanyWorkingDay>
    {
        public bool IsWorkingDay { get; set; }
        public TimeSpan From { get; set; }
        public TimeSpan To { get; set; }
    }
}

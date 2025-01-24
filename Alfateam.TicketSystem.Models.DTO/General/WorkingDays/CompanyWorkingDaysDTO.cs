using Alfateam.TicketSystem.Models.General.WorkingDays;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models.DTO.General.WorkingDays
{
    public class CompanyWorkingDaysDTO : DTOModelAbs<CompanyWorkingDays>
    {
        public TimeSpan Timezone { get; set; }


        public CompanyWorkingDayDTO Monday { get; set; }
        public CompanyWorkingDayDTO Tuesday { get; set; }
        public CompanyWorkingDayDTO Wednesday { get; set; }
        public CompanyWorkingDayDTO Thursday { get; set; }
        public CompanyWorkingDayDTO Friday { get; set; }
        public CompanyWorkingDayDTO Saturday { get; set; }
        public CompanyWorkingDayDTO Sunday { get; set; }
    }
}

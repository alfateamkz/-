using Alfateam.Core;
using Alfateam.TicketSystem.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models.General.WorkingDays
{
    public class CompanyWorkingDays : AbsModel
    {
        public TimeSpan Timezone { get; set; }


        public CompanyWorkingDay Monday { get; set; }
        public CompanyWorkingDay Tuesday { get; set; }
        public CompanyWorkingDay Wednesday { get; set; }
        public CompanyWorkingDay Thursday { get; set; }
        public CompanyWorkingDay Friday { get; set; }
        public CompanyWorkingDay Saturday { get; set; }
        public CompanyWorkingDay Sunday { get; set; }



        public List<WorkingDayChange> WorkingDayChanges { get; set; } = new List<WorkingDayChange>();
    }
}

using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.General.WorkingDays
{
    public class WorkingDay : AbsModel
    {
        public DayOfWeek DayOfWeek { get; set; }
        public bool IsWorkingDay { get; set; }
        public TimeOnly From { get; set; }
        public TimeOnly To { get; set; } = new TimeOnly(23,59,59);
    }
}

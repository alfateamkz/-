using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models.General.WorkingDays
{
    public class CompanyWorkingDay : AbsModel
    {
        public CompanyWorkingDay()
        {

        }

        public CompanyWorkingDay(bool isWorkingDay)
        {
           IsWorkingDay = isWorkingDay;
        }
        public CompanyWorkingDay(TimeSpan from, TimeSpan to)
        {
            IsWorkingDay = true;
            From = from;
            To = to;
        }



        public bool IsWorkingDay { get; set; }
        public TimeSpan From { get; set; }
        public TimeSpan To { get; set; }
    }
}

using Alfateam.Marketing.Models.Abstractions;
using Alfateam.Marketing.Models.SalesGenerators.StartOptions.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.SalesGenerators.StartOptions
{
    public class StartEveryDaySGStartOptions : SalesGeneratorStartOptions
    {
        public TimeOnly Time { get; set; }


        public List<StartEveryDayDayItem> Days { get; set; } = new List<StartEveryDayDayItem>();
        public List<StartEveryDayDayOfWeekItem> DaysOfWeek { get; set; } = new List<StartEveryDayDayOfWeekItem>();
        public List<StartEveryDayMonthItem> Months { get; set; } = new List<StartEveryDayMonthItem>();
    }
}

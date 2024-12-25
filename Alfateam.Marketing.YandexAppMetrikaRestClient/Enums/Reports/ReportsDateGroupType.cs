using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Enums.Reports
{
    public enum ReportsDateGroupType
    {
        [Description("all")]
        All = 1,
        [Description("hours")]
        Hours = 2,
        [Description("auto")]
        Auto = 3,
        [Description("week")]
        Week = 4,
        [Description("month")]
        Month = 5,
        [Description("hour")]
        Hour = 6,
        [Description("year")]
        Year = 7,
        [Description("minutes")]
        Minutes = 8,
        [Description("day")]
        Day = 9,
        [Description("dekaminute")]
        Dekaminute = 10,
        [Description("quarter")]
        Quarter = 11,
        [Description("minute")]
        Minute = 12
    }
}

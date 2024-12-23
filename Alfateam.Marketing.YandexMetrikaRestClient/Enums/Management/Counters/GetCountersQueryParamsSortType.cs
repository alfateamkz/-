using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Enums.Management.Counters
{
    public enum GetCountersQueryParamsSortType
    {
        [Description("None")]
        None = 1,
        [Description("Default")]
        Default = 2,
        [Description("Visits")]
        Visits = 3,
        [Description("Hits")]
        Hits = 4,
        [Description("Uniques")]
        Uniques = 5,
        [Description("Name")]
        Name = 6
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Enums.Management.Filters
{
    public enum FilterType
    {
        [Description("equal")]
        Equal = 1,
        [Description("start")]
        Start = 2,
        [Description("contain")]
        Contain = 3,
        [Description("interval")]
        Interval = 4,
        [Description("me")]
        Me = 5,
        [Description("only_mirrors")]
        OnlyMirrors = 6,
        [Description("regexp")]
        RegExp = 7
    }
}

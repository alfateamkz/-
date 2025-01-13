using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Strategies
{
    public enum AttributionModelEnum
    {
        [Description("LC")]
        LC = 1,
        [Description("LSC")]
        LSC = 2,
        [Description("FC")]
        FC = 3,
        [Description("LYDC")]
        LYDC = 4,
        [Description("LSCCD")]
        LSCCD = 5,
        [Description("FCCD")]
        FCCD = 6,
        [Description("LYDCCD")]
        LYDCCD = 7,
    }
}

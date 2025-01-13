using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums
{
    public enum TargetCarrier
    {
        [Description("WI_FI_ONLY")]
        WiFiOnly = 1,
        [Description("WI_FI_AND_CELLULAR")]
        WiFiAndCellular = 2,
    }
}

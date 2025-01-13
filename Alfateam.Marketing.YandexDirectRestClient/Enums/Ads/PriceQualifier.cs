using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Ads
{
    public enum PriceQualifier
    {
        [Description("FROM")]
        From = 1,
        [Description("UP_TO")]
        UpTo = 2,
        [Description("NONE")]
        None = 3,
    }
}

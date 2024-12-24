using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Enums
{
    public enum AdType
    {
        [Description("native")]
        Native = 1,
        [Description("banner")]
        Banner = 2,
        [Description("rewarded")]
        Rewarded = 3,
        [Description("interstitial")]
        Interstitial = 4,
        [Description("mrec")]
        MREC = 5,
        [Description("other")]
        Other = 6,
    }
}

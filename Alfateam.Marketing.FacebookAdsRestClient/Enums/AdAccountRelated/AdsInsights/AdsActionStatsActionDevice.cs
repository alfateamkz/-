using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated.AdsInsights
{
    public enum AdsActionStatsActionDevice
    {
        [Description("Other")]
        Other = 1,
        [Description("Desktop")]
        Desktop = 2,
        [Description("iPhone")]
        iPhone = 3,
        [Description("iPad")]
        iPad = 4,
        [Description("iPod")]
        iPod = 5,
        [Description("Android Smartphone")]
        AndroidSmartphone = 6,
        [Description("Android Tablet")]
        AndroidTablet = 7,
        [Description("Offline")]
        Offline = 8,
        [Description("N/A")]
        NotApplicable = 9,
    }
}

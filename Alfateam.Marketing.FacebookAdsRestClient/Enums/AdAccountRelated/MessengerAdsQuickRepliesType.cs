using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated
{
    public enum MessengerAdsQuickRepliesType
    {
        [Description("UNKNOWN")]
        Unknown = 1,
        [Description("PAGE_SHOP")]
        PageShop = 2,
        [Description("RETAIL")]
        Retail = 3,
    }
}

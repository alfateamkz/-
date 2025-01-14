using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated
{
    public enum DeliveryCheckName
    {
        [Description("page_status")]
        PageStatus = 1,
        [Description("mobile_eligible")]
        MobileEligible = 2,
        [Description("blocked_url")]
        BlockedURL = 3,
        [Description("invalid_custom_audiences")]
        InvalidCustomAudiences = 4,
        [Description("logged_out_ads")]
        LoggedOutAds = 5,
    }
}

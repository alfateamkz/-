using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Enums.ROI
{
    public enum AdRevenueAccountIntegrationProductNameType
    {
        [Description("attribution_app_level")]
        AttributionAppLevel = 1,
        [Description("attribution_user_level")]
        AttributionUserLevel = 2,
        [Description("attribution_sdk_level")]
        AttributionSDKLevel = 3,
        [Description("attribution_ad_impression")]
        AttributionAdImpression = 4,
        [Description("attribution_sdk_and_user_level")]
        AttributionSDKAndUserLevel = 5,
    }
}

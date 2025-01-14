using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated
{
    public enum AllowedCouponCodeSource
    {
        [Description("AD_CREATIVE_PRIMARY_TEXT")]
        AdCreativePrimaryText = 1,
        [Description("AD_CREATIVE_MANUAL_COUPON_CODES")]
        AdCreativeManualCouponCodes = 2,
        [Description("DETECTED_FROM_MERCHANT_ADS")]
        DetectedFromMerchantAds = 3,
        [Description("PROVIDED_BY_MERCHANT")]
        ProvidedByMerchant = 4,
        [Description("DETECTED_FROM_MERCHANT_WEBSITE")]
        DetectedFromMerchantWebsite = 5,
    }
}

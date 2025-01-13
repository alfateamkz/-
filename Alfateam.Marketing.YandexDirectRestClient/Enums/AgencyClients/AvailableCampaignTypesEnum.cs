using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.AgencyClients
{
    public enum AvailableCampaignTypesEnum
    {
        [Description("TEXT_CAMPAIGN")]
        TextCampaign = 1,
        [Description("MOBILE_APP_CAMAIGN")]
        MobileAppCamaign = 2,
        [Description("DYNAMIC_TEXT_CAMPAIGN")]
        DynamicTextCampaign = 3,
        [Description("CPM_BANNER_CAMPAIGN")]
        CPMBannerCampaign = 4,
        [Description("SMART_CAMPAIGN")]
        SmartCampaign = 5,
        [Description("CONTENT_PROMOTION")]
        ContentPromotion = 6,
        [Description("BILLING_AGGREGATE")]
        BillingAggregate = 7,
        [Description("UNIFIED_CAMPAIGN")]
        UnifiedCampaign = 8,
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.AdGroups
{
    public enum AdGroupTypesEnum
    {
        [Description("TEXT_AD_GROUP")]
        TextAdGroup = 1,
        [Description("MOBILE_APP_AD_GROUP")]
        MobileAppAdGroup = 2,
        [Description("DYNAMIC_TEXT_AD_GROUP")]
        DynamicTetAdGroup = 3,
        [Description("CPM_BANNER_AD_GROUP")]
        CPMBannedAdGroup = 4,
        [Description("CPM_VIDEO_AD_GROUP")]
        CRMVideoAdGroup = 5,
        [Description("SMART_AD_GROUP")]
        SmartAdGroup = 6,
        [Description("UNIFIED_AD_GROUP")]
        UnifiedAdGroup = 7
    }
}

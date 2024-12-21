using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Enums.RawDataReport.Master
{
    public enum MasterReportGroupingType
    {
        [Description("app_id")]
        AppId = 1,
        [Description("pid")]
        Pid = 2,
        [Description("af_prt")]
        AFPrt = 3,
        [Description("c")]
        C = 4,
        [Description("af_adset")]
        AFAdset = 5,
        [Description("af_ad")]
        AFAd = 5,
        [Description("af_channel")]
        AFChannel = 6,
        [Description("af_siteid")]
        AFSiteid = 7,
        [Description("af_keywords")]
        AFKeywords = 8,
        [Description("is_primary")]
        IsPrimary = 9,
        [Description("af_c_id")]
        AFCId = 10,
        [Description("af_adset_id")]
        AFAdsetId = 11,
        [Description("af_ad_id")]
        AFAdId = 12,
        [Description("install_time")]
        InstallTime = 13,
        [Description("attributed_touch_type")]
        AttributedTouchType = 14,
        [Description("geo")]
        Geo = 15,
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Enums.Analytics.Cohort
{
    public enum CohortGroupingsType
    {
        [Description("af_ad")]
        AfAd = 1,
        [Description("af_ad_id")]
        AfAdId = 2,
        [Description("c")]
        C = 3,
        [Description("af_c_id")]
        AfCId = 4,
        [Description("af_channel")]
        AfChannel = 5,
        [Description("pid")]
        Pid = 6,
        [Description("af_sub1")]
        AfSub1 = 7,
        [Description("af_keywords")]
        AfKeywords = 8,
        [Description("af_prt")]
        AfPrt = 9,
        [Description("cohort_type")]
        CohortType = 10,
        [Description("site_id")]
        SiteId = 11,
        [Description("attributed_touch_type")]
        AttributedTouchType = 12,
        [Description("af_adset")]
        AfAdset = 13,
        [Description("af_adset_id")]
        AfAdsetId = 14,
        [Description("geo")]
        Geo = 15,
        [Description("date")]
        Date = 16,
    }
}

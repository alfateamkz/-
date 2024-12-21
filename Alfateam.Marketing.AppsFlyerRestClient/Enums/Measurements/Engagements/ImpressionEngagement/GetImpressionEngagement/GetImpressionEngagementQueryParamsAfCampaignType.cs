using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Enums.Measurements.Engagements.GetClickEngagement
{
    public enum GetImpressionEngagementQueryParamsAfCampaignType
    {
        [Description("user_acquisition")]
        UserAcquisition = 1,
        [Description("retargeting")]
        Retargeting = 2
    }
}

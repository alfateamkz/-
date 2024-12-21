using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Enums.Measurements.Engagements.GetImpressionEngagement
{
    public enum GetImpressionEngagementQueryParamsAfAdType
    {
        [Description("text")]
        Text = 1,
        [Description("banner")]
        Banner = 2,
        [Description("interstitial")]
        Interstitial = 3,
        [Description("video")]
        Video = 4,
        [Description("rewarded_video")]
        RewardedVideo = 5,
        [Description("playable")]
        Playable = 6,
        [Description("audio")]
        Audio = 7
    }
}

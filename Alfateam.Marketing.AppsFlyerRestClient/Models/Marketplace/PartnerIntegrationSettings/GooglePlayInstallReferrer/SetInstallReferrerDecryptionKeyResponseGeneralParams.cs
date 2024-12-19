using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Marketplace.PartnerIntegrationSettings.GooglePlayInstallReferrer
{
    public class SetInstallReferrerDecryptionKeyResponseGeneralParams
    {
        [JsonProperty("click_attribution_lookback_window")]
        public string ClickAttributionLookbackWindow { get; set; }

        [JsonProperty("enable_advanced_privacy")]
        public string EnableAdvancedPrivacy { get; set; }

        [JsonProperty("ignore_active_users_for_retargeting")]
        public string IgnoreActiveUsersForRetargeting { get; set; }

        [JsonProperty("install_re_engagement_click_lookback_window")]
        public string InstallReEngagementClickLookbackWindow { get; set; }

        [JsonProperty("re_engagement_attribution_enabled")]
        public string ReEngagementAttributionEnabled { get; set; }

        [JsonProperty("re_engagement_click_through_lookback_window")]
        public string ReEngagementClickThroughLookbackWindow { get; set; }

        [JsonProperty("re_engagement_view_through_attribution")]
        public string ReEngagementViewThroughAttribution { get; set; }

        [JsonProperty("re_engagement_window")]
        public string ReEngagementWindow { get; set; }

        [JsonProperty("time_window_for_users_to_be_considered_inactive")]
        public string TimeWindowForUsersToBeConsideredInactive { get; set; }

        [JsonProperty("view_through_attribution_lookback_window")]
        public string ViewThroughAttributionLookbackWindow { get; set; }
    }
}

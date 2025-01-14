using Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated.Ads;
using Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdCreatives;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.Ads
{
    public class Ad
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("account_id")]
        public long AccountId { get; set; }

        [JsonProperty("ad_active_time")]
        public long AdActiveTime { get; set; }

        [JsonProperty("ad_review_feedback")]
        public AdgroupReviewFeedback AdReviewFeedback { get; set; }

        [JsonProperty("ad_schedule_end_time")]
        public DateTime AdScheduleEndTime { get; set; }

        [JsonProperty("ad_schedule_start_time")]
        public DateTime AdScheduleStartTime { get; set; }

        [JsonProperty("adlabels")]
        public List<AdLabel> AdLabels { get; set; } = new List<AdLabel>();

        [JsonProperty("adset")]
        public AdSet AdSet { get; set; }

        [JsonProperty("adset_id")]
        public long AdSetId { get; set; }

        [JsonProperty("bid_amount")]
        public int BidAmount { get; set; }

        [JsonProperty("campaign")]
        public Campaign Campaign { get; set; }

        [JsonProperty("campaign_id")]
        public long CampaignId { get; set; }

        [JsonProperty("configured_status")]
        public AdConfiguredStatus ConfiguredStatus { get; set; }

        [JsonProperty("conversion_domain")]
        public string ConversionDomain { get; set; }

        [JsonProperty("created_time")]
        public DateTime CreatedTime { get; set; }

        [JsonProperty("creative")]
        public AdCreative Creative { get; set; }

        [JsonProperty("creative_asset_groups_spec")]
        public AdCreativeAssetGroupsSpec CreativeAssetGroupsSpec { get; set; }

        [JsonProperty("effective_status")]
        public AdEffectiveStatus EffectiveStatus { get; set; }

        [JsonProperty("issues_info")]
        public List<AdgroupIssuesInfo> IssuesInfo { get; set; } = new List<AdgroupIssuesInfo>();

        [JsonProperty("last_updated_by_app_id")]
        public long LastUpdatedByAppId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("preview_shareable_link")]
        public string PreviewShareableLink { get; set; }

        [JsonProperty("recommendations")]
        public List<AdRecommendation> Recommendations { get; set; } = new List<AdRecommendation>();

        [JsonProperty("source_ad")]
        public Ad SourceAd { get; set; }

        [JsonProperty("source_ad_id")]
        public long SourceAdId { get; set; }

        [JsonProperty("status")]
        public AdStatus Status { get; set; }

        [JsonProperty("tracking_specs")]
        public List<ConversionActionQuery> TrackingSpecs { get; set; } = new List<ConversionActionQuery>();

        [JsonProperty("updated_time")]
        public DateTime UpdatedTime { get; set; }
    }
}

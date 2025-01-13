using Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated
{
    public class Campaign
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("account_id")]
        public long AccountId { get; set; }

        [JsonProperty("adlabels")]
        public List<AdLabel> AdLabels { get; set; } = new List<AdLabel>();

        [JsonProperty("bid_strategy")]
        public BidStrategy BidStrategy { get; set; }

        [JsonProperty("boosted_object_id")]
        public long BoostedObjectId { get; set; }

        [JsonProperty("brand_lift_studies")]
        public List<AdStudy> BrandLiftStudies { get; set; } = new List<AdStudy>();

        [JsonProperty("budget_rebalance_flag")]
        public bool BudgetRebalanceFlag { get; set; }

        [JsonProperty("budget_remaining")]
        public double BudgetRemaining { get; set; }

        [JsonProperty("buying_type")]
        public BuyingType BuyingType { get; set; }

        [JsonProperty("campaign_group_active_time")]
        public double CampaignGroupActiveTime { get; set; }

        [JsonProperty("can_create_brand_lift_study")]
        public bool CanCreateBrandLiftStudy { get; set; }

        [JsonProperty("can_use_spend_cap")]
        public bool CanUseSpendCap { get; set; }

        [JsonProperty("configured_status")]
        public CampaignConfiguredStatus ConfiguredStatus { get; set; }

        [JsonProperty("created_time")]
        public DateTime CreatedTime { get; set; }

        [JsonProperty("daily_budget")]
        public double DailyBudget { get; set; }

        [JsonProperty("effective_status")]
        public EffectiveStatus EffectiveStatus { get; set; }

        [JsonProperty("has_secondary_skadnetwork_reporting")]
        public bool HasSecondarySKAdNetworkReporting { get; set; }

        [JsonProperty("is_budget_schedule_enabled")]
        public bool IsBudgetScheduleEnabled { get; set; }

        [JsonProperty("is_skadnetwork_attribution")]
        public bool IsSKAdNetworkAttribution { get; set; }

        [JsonProperty("issues_info")]
        public List<AdCampaignIssuesInfo> IssuesInfo { get; set; } = new List<AdCampaignIssuesInfo>();

        [JsonProperty("last_budget_toggling_time")]
        public DateTime LastBudgetTogglingTime { get; set; }

        [JsonProperty("lifetime_budget")]
        public double LifetimeBudget { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("objective")]
        public string Objective { get; set; }

        [JsonProperty("pacing_type")]
        public List<string> PacingType { get; set; } = new List<string>();

        [JsonProperty("primary_attribution")]
        public PrimaryAttributionEnum PrimaryAttribution { get; set; }

        [JsonProperty("promoted_object")]
        public AdPromotedObject PromotedObject { get; set; }

        [JsonProperty("smart_promotion_type")]
        public SmartPromotionType SmartPromotionType { get; set; }

        [JsonProperty("source_campaign")]
        public Campaign SourceCampaign { get; set; }

        [JsonProperty("source_campaign_id")]
        public long SourceCampaignId { get; set; }

        [JsonProperty("special_ad_categories")]
        public List<SpecialAdCategory> SpecialAdCategories { get; set; } = new List<SpecialAdCategory>();

        [JsonProperty("special_ad_category")]
        public SpecialAdCategory SpecialAdCategory { get; set; }

        [JsonProperty("special_ad_category_country")]
        public List<string> SpecialAdCategoryCountry { get; set; } = new List<string>();

        [JsonProperty("spend_cap")]
        public long SpendCap { get; set; }

        [JsonProperty("start_time")]
        public DateTime StartTime { get; set; }

        [JsonProperty("status")]
        public CampaignStatus Status { get; set; }

        [JsonProperty("stop_time")]
        public DateTime StopTime { get; set; }

        [JsonProperty("topline_id")]
        public long ToplineId { get; set; }

        [JsonProperty("updated_time")]
        public DateTime UpdatedTime { get; set; }
    }
}

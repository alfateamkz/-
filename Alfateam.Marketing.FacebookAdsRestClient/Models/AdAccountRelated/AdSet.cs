using Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated;
using Alfateam.Marketing.FacebookAdsRestClient.Models.General;
using FacebookAds.Object;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated
{
    public class AdSet
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("account_id")]
        public long AccountId { get; set; }

        [JsonProperty("adlabels")]
        public List<AdLabel> AdLabels { get; set; } = new List<AdLabel>();

        [JsonProperty("adset_schedule")]
        public List<DayPart> AdSetSchedule { get; set; } = new List<DayPart>();

        [JsonProperty("asset_feed_id")]
        public long AssetFeedId { get; set; }

        [JsonProperty("attribution_spec")]
        public List<AttributionSpec> AttributionSpec { get; set; } = new List<AttributionSpec>();

        [JsonProperty("bid_adjustments")]
        public AdBidAdjustments BidAdjustments { get; set; }

        [JsonProperty("bid_amount")]
        public uint BidAmount { get; set; }

        [JsonProperty("bid_constraints")]
        public AdCampaignBidConstraint BidConstraints { get; set; }

        [JsonProperty("bid_info")]
        public Dictionary<string, uint> BidInfo { get; set; } = new Dictionary<string, uint>();

        [JsonProperty("bid_strategy")]
        public BidStrategy BidStrategy { get; set; }

        [JsonProperty("billing_event")]
        public BillingEvent BillingEvent { get; set; }

        [JsonProperty("brand_safety_config")]
        public BrandSafetyCampaignConfig BrandSafetyConfig { get; set; }

        [JsonProperty("budget_remaining")]
        public double BudgetRemaining { get; set; }

        [JsonProperty("campaign")]
        public Campaign Campaign { get; set; }

        [JsonProperty("campaign_active_time")]
        public long CampaignActiveTime { get; set; }

        [JsonProperty("campaign_attribution")]
        public CampaignAttribution CampaignAttribution { get; set; }

        [JsonProperty("campaign_id")]
        public long CampaignId { get; set; }

        [JsonProperty("configured_status")]
        public AdSetConfiguredStatus ConfiguredStatus { get; set; }

        [JsonProperty("contextual_bundling_spec")]
        public ContextualBundlingSpec ContextualBundlingSpec { get; set; }

        [JsonProperty("created_time")]
        public DateTime CreatedTime { get; set; }

        [JsonProperty("creative_sequence")]
        public List<string> CreativeSequence { get; set; } = new List<string>();

        [JsonProperty("daily_budget")]
        public double DailyBudget { get; set; }

        [JsonProperty("daily_min_spend_target")]
        public double DailyMinSpendTarget { get; set; }

        [JsonProperty("daily_spend_cap")]
        public double DailySpendCap { get; set; }

        [JsonProperty("destination_type")]
        public AdSetDestinationType DestinationType { get; set; }

        [JsonProperty("dsa_beneficiary")]
        public string DSABeneficiary { get; set; }

        [JsonProperty("dsa_payor")]
        public string DSAPayor { get; set; }

        [JsonProperty("effective_status")]
        public EffectiveStatus EffectiveStatus { get; set; }

        [JsonProperty("end_time")]
        public DateTime EndTime { get; set; }

        [JsonProperty("frequency_control_specs")]
        public List<AdCampaignFrequencyControlSpecs> FrequencyControlSpecs { get; set; } = new List<AdCampaignFrequencyControlSpecs>();

        [JsonProperty("instagram_actor_id")]
        public long InstagramActorId { get; set; }

        [JsonProperty("is_dynamic_creative")]
        public bool IsDynamicCreative { get; set; }

        [JsonProperty("issues_info")]
        public List<AdCampaignIssuesInfo> IssuesInfo { get; set; } = new List<AdCampaignIssuesInfo>();

        [JsonProperty("learning_stage_info")]
        public AdCampaignLearningStageInfo LearningStageInfo { get; set; }

        [JsonProperty("lifetime_budget")]
        public double LifetimeBudget { get; set; }

        [JsonProperty("lifetime_imps")]
        public int LifetimeImps { get; set; }

        [JsonProperty("lifetime_min_spend_target")]
        public double LifetimeMinSpendTarget { get; set; }

        [JsonProperty("lifetime_spend_cap")]
        public double LifetimeSpendCap { get; set; }

        [JsonProperty("min_budget_spend_percentage")]
        public double MinBudgetSpendPercentage { get; set; }

        [JsonProperty("multi_optimization_goal_weight")]
        public string MultiOptimizationGoalWeight { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("optimization_goal")]
        public OptimizationGoal OptimizationGoal { get; set; }

        [JsonProperty("optimization_sub_event")]
        public string OptimizationSubEvent { get; set; }

        [JsonProperty("pacing_type")]
        public List<string> PacingType { get; set; } = new List<string>();

        [JsonProperty("promoted_object")]
        public AdPromotedObject PromotedObject { get; set; }

        [JsonProperty("recommendations")]
        public List<AdRecommendation> Recommendations { get; set; } = new List<AdRecommendation>();

        [JsonProperty("recurring_budget_semantics")]
        public bool RecurringBudgetSemantics { get; set; }

        [JsonProperty("regional_regulated_categories")]
        public RegionalRegulatedCategory? RegionalRegulatedCategories { get; set; }

        [JsonProperty("regional_regulation_identities")]
        public RegionalRegulationIdentities RegionalRegulationIdentities { get; set; }

        [JsonProperty("review_feedback")]
        public string ReviewFeedback { get; set; }

        [JsonProperty("rf_prediction_id")]
        public string RFPredictionId { get; set; }

        [JsonProperty("source_adset")]
        public AdSet SourceAdSet { get; set; }

        [JsonProperty("source_adset_id")]
        public long SourceAdSetId { get; set; }

        [JsonProperty("start_time")]
        public DateTime StartTime { get; set; }

        [JsonProperty("status")]
        public AdSetStatus Status { get; set; }

        [JsonProperty("targeting")]
        public Targeting Targeting { get; set; }

        [JsonProperty("targeting_optimization_types")]
        public Dictionary<string, int> TargetingOptimizationTypes { get; set; } = new Dictionary<string, int>();

        [JsonProperty("time_based_ad_rotation_id_blocks")]
        public List<List<int>> TimeBasedAdRotationIdBlocks { get; set; } = new List<List<int>>();

        [JsonProperty("time_based_ad_rotation_intervals")]
        public List<uint> TimeBasedAdRotationIntervals { get; set; } = new List<uint>();

        [JsonProperty("updated_time")]
        public DateTime UpdatedTime { get; set; }

        [JsonProperty("use_new_app_click")]
        public bool UseNewAppClick { get; set; }
    }
}

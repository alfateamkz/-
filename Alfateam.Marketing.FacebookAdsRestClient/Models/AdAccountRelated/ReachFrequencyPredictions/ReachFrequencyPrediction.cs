using Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated.ReachFrequencyPredictions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.ReachFrequencyPredictions
{
    public class ReachFrequencyPrediction
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("account_id")]
        public long AccountId { get; set; }

        [JsonProperty("audience_size_lower_bound")]
        public uint AudienceSizeLowerBound { get; set; }

        [JsonProperty("audience_size_upper_bound")]
        public uint AudienceSizeUpperBound { get; set; }

        [JsonProperty("campaign_group_id")]
        public int CampaignGroupId { get; set; }

        [JsonProperty("campaign_id")]
        public long CampaignId { get; set; }

        [JsonProperty("campaign_time_start")]
        public DateTime CampaignTimeStart { get; set; }

        [JsonProperty("campaign_time_stop")]
        public DateTime CampaignTimeStop { get; set; }

        [JsonProperty("curve_budget_reach")]
        public ReachFrequencyEstimatesCurve CurveBudgetReach { get; set; }

        [JsonProperty("daily_impression_curve")]
        public List<float> DailyImpressionCurve { get; set; } = new List<float>();

        [JsonProperty("destination_id")]
        public long DestinationId { get; set; }

        [JsonProperty("expiration_time")]
        public DateTime ExpirationTime { get; set; }

        [JsonProperty("external_budget")]
        public int ExternalBudget { get; set; }

        [JsonProperty("external_impression")]
        public uint ExternalImpression { get; set; }

        [JsonProperty("external_maximum_budget")]
        public int ExternalMaximumBudget { get; set; }

        [JsonProperty("external_maximum_impression")]
        public int ExternalMaximumImpression { get; set; }

        [JsonProperty("external_maximum_reach")]
        public uint ExternalMaximumReach { get; set; }

        [JsonProperty("external_minimum_budget")]
        public int ExternalMinimumBudget { get; set; }

        [JsonProperty("external_minimum_impression")]
        public uint ExternalMinimumImpression { get; set; }

        [JsonProperty("external_minimum_reach")]
        public uint ExternalMinimumReach { get; set; }

        [JsonProperty("external_reach")]
        public uint ExternalReach { get; set; }

        [JsonProperty("frequency_cap")]
        public uint FrequencyCap { get; set; }

        [JsonProperty("frequency_distribution_map")]
        public Dictionary<uint, List<float>> FrequencyDistributionMap { get; set; } = new Dictionary<uint, List<float>>();

        [JsonProperty("frequency_distribution_map_agg")]
        public Dictionary<uint, List<uint>> FrequencyDistributionMapAgg { get; set; } = new Dictionary<uint, List<uint>>();

        [JsonProperty("grp_dmas_audience_size")]
        public float GRPDMASAudienceSize { get; set; }

        [JsonProperty("holdout_percentage")]
        public uint HoldoutPercentage { get; set; }

        [JsonProperty("instagram_destination_id")]
        public long InstagramDestinationId { get; set; }

        [JsonProperty("interval_frequency_cap")]
        public uint IntervalFrequencyCap { get; set; }

        [JsonProperty("interval_frequency_cap_reset_period")]
        public uint IntervalFrequencyCapResetPeriod { get; set; }

        [JsonProperty("is_io")]
        public bool IsIO { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("pause_periods")]
        public List<ReachFrequencyPredictionPausePeriod> PausePeriods { get; set; } = new List<ReachFrequencyPredictionPausePeriod>();

        [JsonProperty("placement_breakdown")]
        public ReachFrequencyEstimatesPlacementBreakdown PlacementBreakdown { get; set; }

        [JsonProperty("prediction_mode")]
        public ReachFrequencyPredictionMode PredictionMode { get; set; }

        [JsonProperty("prediction_progress")]
        public uint PredictionProgress { get; set; }

        [JsonProperty("reservation_status")]
        public ReachFrequencyPredictionReservationStatus ReservationStatus { get; set; }

        [JsonProperty("status")]
        public uint Status { get; set; }

        [JsonProperty("story_event_type")]
        public uint StoryEventType { get; set; }

        [JsonProperty("target_spec")]
        public Targeting TargetSpec { get; set; }

        [JsonProperty("time_created")]
        public DateTime TimeCreated { get; set; }

        [JsonProperty("time_updated")]
        public DateTime TimeUpdated { get; set; }
    }
}

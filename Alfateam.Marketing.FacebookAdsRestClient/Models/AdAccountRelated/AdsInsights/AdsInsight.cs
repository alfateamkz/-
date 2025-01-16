using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdsInsights
{
    public class AdsInsight
    {
        [JsonProperty("account_currency")]
        public string AccountCurrency { get; set; }

        [JsonProperty("account_id")]
        public long AccountId { get; set; }

        [JsonProperty("account_name")]
        public string AccountName { get; set; }

        [JsonProperty("action_values")]
        public List<AdsActionStats> ActionValues { get; set; } = new List<AdsActionStats>();

        [JsonProperty("actions")]
        public List<AdsActionStats> Actions { get; set; } = new List<AdsActionStats>();

        [JsonProperty("activity_recency")]
        public string ActivityRecency { get; set; }

        [JsonProperty("ad_click_actions")]
        public List<AdsActionStats> AdClickActions { get; set; } = new List<AdsActionStats>();

        [JsonProperty("ad_format_asset")]
        public string AdFormatAsset { get; set; }

        [JsonProperty("ad_id")]
        public long AdId { get; set; }

        [JsonProperty("ad_impression_actions")]
        public List<AdsActionStats> AdImpressionActions { get; set; } = new List<AdsActionStats>();

        [JsonProperty("ad_name")]
        public string AdName { get; set; }

        [JsonProperty("adset_id")]
        public long AdSetId { get; set; }

        [JsonProperty("adset_name")]
        public string AdSetName { get; set; }

        [JsonProperty("age_targeting")]
        public string AgeTargeting { get; set; }

        [JsonProperty("attribution_setting")]
        public string AttributionSetting { get; set; }

        [JsonProperty("auction_bid")]
        public double AuctionBid { get; set; }

        [JsonProperty("auction_competitiveness")]
        public double AuctionCompetitiveness { get; set; }

        [JsonProperty("auction_max_competitor_bid")]
        public double AuctionMaxCompetitorBid { get; set; }

        [JsonProperty("body_asset")]
        public AdAssetBody BodyAsset { get; set; }

        [JsonProperty("buying_type")]
        public string BuyingType { get; set; }

        [JsonProperty("campaign_id")]
        public long CampaignId { get; set; }

        [JsonProperty("campaign_name")]
        public string CampaignName { get; set; }

        [JsonProperty("canvas_avg_view_percent")]
        public double CanvasAvgViewPercent { get; set; }

        [JsonProperty("canvas_avg_view_time")]
        public long CanvasAvgViewTime { get; set; }

        [JsonProperty("catalog_segment_actions")]
        public List<AdsActionStats> CatalogSegmentActions { get; set; } = new List<AdsActionStats>();

        [JsonProperty("catalog_segment_value")]
        public List<AdsActionStats> CatalogSegmentValue { get; set; } = new List<AdsActionStats>();

        [JsonProperty("catalog_segment_value_mobile_purchase_roas")]
        public List<AdsActionStats> CatalogSegmentValueMobilePurchaseROAS { get; set; } = new List<AdsActionStats>();

        [JsonProperty("catalog_segment_value_omni_purchase_roas")]
        public List<AdsActionStats> CatalogSegmentValueOmniPurchaseROAS { get; set; } = new List<AdsActionStats>();

        [JsonProperty("catalog_segment_value_website_purchase_roas")]
        public List<AdsActionStats> CatalogSegmentValueWebsitePurchaseROAS { get; set; } = new List<AdsActionStats>();

        [JsonProperty("clicks")]
        public long Clicks { get; set; }

        [JsonProperty("coarse_conversion_value")]
        public string CoarseConversionValue { get; set; }

        [JsonProperty("comparison_node")]
        public AdsInsightsComparison ComparisonNode { get; set; }

        [JsonProperty("conversion_values")]
        public List<AdsActionStats> ConversionValues { get; set; } = new List<AdsActionStats>();

        [JsonProperty("conversions")]
        public List<AdsActionStats> Conversions { get; set; } = new List<AdsActionStats>();

        [JsonProperty("converted_product_quantity")]
        public List<AdsActionStats> ConvertedProductQuantity { get; set; } = new List<AdsActionStats>();

        [JsonProperty("converted_product_value")]
        public List<AdsActionStats> ConvertedProductValue { get; set; } = new List<AdsActionStats>();

        [JsonProperty("cost_per_15_sec_video_view")]
        public List<AdsActionStats> CostPer15SecVideoView { get; set; } = new List<AdsActionStats>();

        [JsonProperty("cost_per_2_sec_continuous_video_view")]
        public List<AdsActionStats> CostPer2SecContinuousVideoView { get; set; } = new List<AdsActionStats>();

        [JsonProperty("cost_per_action_type")]
        public List<AdsActionStats> CostPerActionType { get; set; } = new List<AdsActionStats>();

        [JsonProperty("cost_per_ad_click")]
        public List<AdsActionStats> CostPerAdClick { get; set; } = new List<AdsActionStats>();

        [JsonProperty("cost_per_conversion")]
        public List<AdsActionStats> CostPerConversion { get; set; } = new List<AdsActionStats>();

        [JsonProperty("cost_per_dda_countby_convs")]
        public double CostPerDDACountByConvs { get; set; }

        [JsonProperty("cost_per_inline_link_click")]
        public double CostPerInlineLinkClick { get; set; }

        [JsonProperty("cost_per_inline_post_engagement")]
        public double CostPerInlinePostEngagement { get; set; }

        [JsonProperty("cost_per_one_thousand_ad_impression")]
        public List<AdsActionStats> CostPerOneThousandAdImpression { get; set; } = new List<AdsActionStats>();

        [JsonProperty("cost_per_outbound_click")]
        public List<AdsActionStats> CostPerOutboundClick { get; set; } = new List<AdsActionStats>();

        [JsonProperty("cost_per_thruplay")]
        public List<AdsActionStats> CostPerThruplay { get; set; } = new List<AdsActionStats>();

        [JsonProperty("cost_per_unique_action_type")]
        public List<AdsActionStats> CostPerUniqueActionType { get; set; } = new List<AdsActionStats>();

        [JsonProperty("cost_per_unique_click")]
        public double CostPerUniqueClick { get; set; }

        [JsonProperty("cost_per_unique_conversion")]
        public List<AdsActionStats> CostPerUniqueConversion { get; set; } = new List<AdsActionStats>();

        [JsonProperty("cost_per_unique_inline_link_click")]
        public double CostPerUniqueInlineLinkClick { get; set; }

        [JsonProperty("cost_per_unique_outbound_click")]
        public List<AdsActionStats> CostPerUniqueOutboundClick { get; set; } = new List<AdsActionStats>();

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("cpc")]
        public double CPC { get; set; }

        [JsonProperty("cpm")]
        public double CPM { get; set; }

        [JsonProperty("cpp")]
        public double CPP { get; set; }

        [JsonProperty("created_time")]
        public DateTime CreatedTime { get; set; }

        [JsonProperty("ctr")]
        public double CTR { get; set; }

        [JsonProperty("date_start")]
        public DateTime DateStart { get; set; }

        [JsonProperty("date_stop")]
        public DateTime DateStop { get; set; }

        [JsonProperty("dda_countby_convs")]
        public double DDACountByConvs { get; set; }

        [JsonProperty("dda_results")]
        public List<AdsInsightsDdaResult> DDAResults { get; set; } = new List<AdsInsightsDdaResult>();

        [JsonProperty("description_asset")]
        public AdAssetDescription DescriptionAsset { get; set; }

        [JsonProperty("device_platform")]
        public string DevicePlatform { get; set; }

        [JsonProperty("dma")]
        public string DMA { get; set; }

        [JsonProperty("estimated_ad_recall_rate_lower_bound")]
        public double EstimatedAdRecallRateLowerBound { get; set; }

        [JsonProperty("estimated_ad_recall_rate_upper_bound")]
        public double EstimatedAdRecallRateUpperBound { get; set; }

        [JsonProperty("estimated_ad_recallers_lower_bound")]
        public double EstimatedAdRecallersLowerBound { get; set; }

        [JsonProperty("estimated_ad_recallers_upper_bound")]
        public double EstimatedAdRecallersUpperBound { get; set; }

        [JsonProperty("fidelity_type")]
        public string FidelityType { get; set; }

        [JsonProperty("frequency")]
        public double Frequency { get; set; }

        [JsonProperty("frequency_value")]
        public string FrequencyValue { get; set; }

        [JsonProperty("full_view_impressions")]
        public double FullViewImpressions { get; set; }

        [JsonProperty("full_view_reach")]
        public double FullViewReach { get; set; }

        [JsonProperty("gender_targeting")]
        public string GenderTargeting { get; set; }

        [JsonProperty("hourly_stats_aggregated_by_advertiser_time_zone")]
        public string HourlyStatsAggregatedByAdvertiserTimeZone { get; set; }

        [JsonProperty("hourly_stats_aggregated_by_audience_time_zone")]
        public string HourlyStatsAggregatedByAudienceTimeZone { get; set; }

        [JsonProperty("hsid")]
        public string HSID { get; set; }

        [JsonProperty("image_asset")]
        public AdAssetImage ImageAsset { get; set; }

        [JsonProperty("impression_device")]
        public string ImpressionDevice { get; set; }

        [JsonProperty("impressions")]
        public long Impressions { get; set; }

        [JsonProperty("inline_link_click_ctr")]
        public double InlineLinkClickCTR { get; set; }

        [JsonProperty("inline_link_clicks")]
        public double InlineLinkClicks { get; set; }

        [JsonProperty("inline_post_engagement")]
        public double InlinePostEngagement { get; set; }

        [JsonProperty("instagram_upcoming_event_reminders_set")]
        public double InstagramUpcomingEventRemindersSet { get; set; }

        [JsonProperty("instant_experience_clicks_to_open")]
        public double InstantExperienceClicksToOpen { get; set; }

        [JsonProperty("instant_experience_clicks_to_start")]
        public double InstantExperienceClicksToStart { get; set; }

        [JsonProperty("instant_experience_outbound_clicks")]
        public List<AdsActionStats> InstantExperienceOutboundClicks { get; set; } = new List<AdsActionStats>();

        [JsonProperty("interactive_component_tap")]
        public List<AdsActionStats> InteractiveComponentTap { get; set; } = new List<AdsActionStats>();

        [JsonProperty("labels")]
        public string Labels { get; set; }

        [JsonProperty("landing_destination")]
        public string LandingDestination { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("marketing_messages_delivery_rate")]
        public double MarketingMessagesDeliveryRate { get; set; }

        [JsonProperty("media_asset")]
        public AdAssetMedia MediaAsset { get; set; }

        [JsonProperty("mobile_app_purchase_roas")]
        public List<AdsActionStats> MobileAppPurchaseROAS { get; set; } = new List<AdsActionStats>();

        [JsonProperty("objective")]
        public string Objective { get; set; }

        [JsonProperty("optimization_goal")]
        public string OptimizationGoal { get; set; }

        [JsonProperty("outbound_clicks")]
        public List<AdsActionStats> OutboundClicks { get; set; } = new List<AdsActionStats>();

        [JsonProperty("outbound_clicks_ctr")]
        public List<AdsActionStats> OutboundClicksCTR { get; set; } = new List<AdsActionStats>();

        [JsonProperty("place_page_id")]
        public string PlacePageId { get; set; }

        [JsonProperty("place_page_name")]
        public string PlacePageName { get; set; }

        [JsonProperty("platform_position")]
        public string PlatformPosition { get; set; }

        [JsonProperty("postback_sequence_index")]
        public string PostbackSequenceIndex { get; set; }

        [JsonProperty("product_id")]
        public string ProductId { get; set; }

        [JsonProperty("publisher_platform")]
        public string PublisherPlatform { get; set; }

        [JsonProperty("purchase_roas")]
        public List<AdsActionStats> PurchaseROAS { get; set; } = new List<AdsActionStats>();

        [JsonProperty("qualifying_question_qualify_answer_rate")]
        public double QualifyingQuestionQualifyAnswerRate { get; set; }

        [JsonProperty("reach")]
        public double Reach { get; set; }

        [JsonProperty("redownload")]
        public string Redownload { get; set; }

        [JsonProperty("result_values_performance_indicator")]
        public string ResultValuesPerformanceIndicator { get; set; }

        [JsonProperty("rule_asset")]
        public AdAssetRule RuleAsset { get; set; }

        [JsonProperty("shops_assisted_purchases")]
        public string ShopsAssistedPurchases { get; set; }

        [JsonProperty("skan_version")]
        public string SKANVersion { get; set; }

        [JsonProperty("social_spend")]
        public double SocialSpend { get; set; }

        [JsonProperty("spend")]
        public double Spend { get; set; }

        [JsonProperty("title_asset")]
        public AdAssetTitle TitleAsset { get; set; }

        [JsonProperty("updated_time")]
        public DateTime UpdatedTime { get; set; }

        [JsonProperty("user_segment_key")]
        public string UserSegmentKey { get; set; }

        [JsonProperty("video_30_sec_watched_actions")]
        public List<AdsActionStats>Video30SecWatchedActions { get; set; } = new List<AdsActionStats>();

        [JsonProperty("video_asset")]
        public AdAssetVideo VideoAsset { get; set; }

        [JsonProperty("video_avg_time_watched_actions")]
        public List<AdsActionStats> VideoAvgTimeWatchedActions { get; set; } = new List<AdsActionStats>();

        [JsonProperty("video_continuous_2_sec_watched_actions")]
        public List<AdsActionStats> VideoContinuous2SecWatchedActions { get; set; } = new List<AdsActionStats>();

        [JsonProperty("video_p100_watched_actions")]
        public List<AdsActionStats> VideoP100WatchedActions { get; set; } = new List<AdsActionStats>();

        [JsonProperty("video_p25_watched_actions")]
        public List<AdsActionStats> VideoP25WatchedActions { get; set; } = new List<AdsActionStats>();

        [JsonProperty("video_p50_watched_actions")]
        public List<AdsActionStats> VideoP50WatchedActions { get; set; } = new List<AdsActionStats>();

        [JsonProperty("video_p75_watched_actions")]
        public List<AdsActionStats> VideoP75WatchedActions { get; set; } = new List<AdsActionStats>();

        [JsonProperty("video_p95_watched_actions")]
        public List<AdsActionStats> VideoP95WatchedActions { get; set; } = new List<AdsActionStats>();

        [JsonProperty("video_play_actions")]
        public List<AdsActionStats> VideoPlayActions { get; set; } = new List<AdsActionStats>();

        [JsonProperty("video_play_curve_actions")]
        public List<AdsHistogramStats> VideoPlayCurveActions { get; set; } = new List<AdsHistogramStats>();

        [JsonProperty("video_play_retention_0_to_15s_actions")]
        public List<AdsHistogramStats> VideoPlayRetention0To15sActions { get; set; } = new List<AdsHistogramStats>();

        [JsonProperty("video_play_retention_20_to_60s_actions")]
        public List<AdsHistogramStats> VideoPlayRetention20To60sActions { get; set; } = new List<AdsHistogramStats>();

        [JsonProperty("video_play_retention_graph_actions")]
        public List<AdsHistogramStats> VideoPlayRetentionGraphActions { get; set; } = new List<AdsHistogramStats>();

        [JsonProperty("video_time_watched_actions")]
        public List<AdsActionStats> VideoTimeWatchedActions { get; set; } = new List<AdsActionStats>();

        [JsonProperty("website_ctr")]
        public List<AdsActionStats> WebsiteCTR { get; set; } = new List<AdsActionStats>();

        [JsonProperty("website_purchase_roas")]
        public List<AdsActionStats> WebsitePurchaseROAS { get; set; } = new List<AdsActionStats>();

        [JsonProperty("wish_bid")]
        public double WishBid { get; set; }
    }
}

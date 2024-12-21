using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Enums.RawDataReport
{
    public enum RawDataReportAdditionalFieldType
    {
        [Description("blocked_reason_rule")]
        BlockedReasonRule = 1,
        [Description("store_reinstall")]
        StoreReinstall = 2,
        [Description("impressions")]
        Impressions = 3,
        [Description("contributor3_match_type")]
        Contributor3MatchType = 4,
        [Description("custom_dimension")]
        CustomDimension = 5,
        [Description("conversion_type")]
        ConversionType = 6,
        [Description("gp_click_time")]
        GPClickTime = 7,
        [Description("match_type")]
        MatchType = 8,
        [Description("mediation_network")]
        MediationNetwork = 9,
        [Description("oaid")]
        OAID = 10,
        [Description("deeplink_url")]
        DeeplinkURL = 11,
        [Description("blocked_reason")]
        BlockedReason = 12,
        [Description("blocked_sub_reason")]
        BlockedSubReason = 13,
        [Description("gp_broadcast_referrer")]
        GPBroadcastReferrer = 14,
        [Description("gp_install_begin")]
        GPInstallBegin = 15,
        [Description("campaign_type")]
        CampaignType = 16,
        [Description("custom_data")]
        CustomData = 17,
        [Description("rejected_reason")]
        RejectedReason = 18,
        [Description("device_download_time")]
        DeviceDownloadTime = 19,
        [Description("keyword_match_type")]
        KeywordMatchType = 20,
        [Description("contributor1_match_type")]
        Contributor1MatchType = 21,
        [Description("contributor2_match_type")]
        Contributor2MatchType = 22,
        [Description("device_model")]
        DeviceModel = 23,
        [Description("monetization_network")]
        MonetizationNetwork = 24,
        [Description("segment")]
        Segment = 25,
        [Description("is_lat")]
        IsLat = 26,
        [Description("gp_referrer")]
        GPReferrer = 27,
        [Description("blocked_reason_value")]
        BlockedReasonValue = 28,
        [Description("store_product_page")]
        StoreProductPage = 29,
        [Description("device_category")]
        DeviceCategory = 30,
        [Description("app_type")]
        AppType = 31,
        [Description("rejected_reason_value")]
        RejectedReasonValue = 32,
        [Description("ad_unit")]
        AdUnit = 33,
        [Description("keyword_id")]
        KeywordId = 34,
        [Description("placement")]
        Placement = 35,
        [Description("network_account_id")]
        NetworkAccountId = 36,
        [Description("install_app_store")]
        InstallAppStore = 37,
        [Description("amazon_aid")]
        AmazonAId = 38,
        [Description("att")]
        Att = 39,
        [Description("engagement_type")]
        EngagementType = 40,
        [Description("contributor1_engagement_type")]
        Contributor1EngagementType = 41,
        [Description("contributor2_engagement_type")]
        Contributor2EngagementType = 42,
        [Description("contributor3_engagement_type")]
        Contributor3EngagementType = 43,
        [Description("gdpr_applies")]
        GDPRApplies = 44,
        [Description("ad_user_data_enabled")]
        AdUserDataEnabled = 45,
        [Description("ad_personalization_enabled")]
        AdPersonalizationEnabled = 46,
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated
{
    public enum AdActivityEventType
    {
        [Description("ad_account_update_spend_limit")]
        AdAccountUpdateSpendLimit = 1,
        [Description("ad_account_reset_spend_limit")]
        AdAccountResetSpendLimit = 2,
        [Description("ad_account_remove_spend_limit")]
        AdAccountRemoveSpendLimit = 3,
        [Description("ad_account_set_business_information")]
        AdAccountSetBusinessInformation = 4,
        [Description("ad_account_update_status")]
        AdAccountUpdateStatus = 5,
        [Description("ad_account_add_user_to_role")]
        AdAccountAddUserToRole = 6,
        [Description("ad_account_remove_user_from_role")]
        AdAccountRemoveUserFromRole = 7,
        [Description("add_images")]
        AddImages = 8,
        [Description("edit_images")]
        EditImages = 9,
        [Description("delete_images")]
        DeleteImages = 10,
        [Description("ad_account_update_audience_type_url_parameter")]
        AdAccountUpdateAudienceTypeURLParameter = 11,
        [Description("adaccount_update_audience_segment")]
        AdAccountUpdateAudienceSegment = 12,
        [Description("ad_account_billing_charge")]
        AdAccountBillingCharge = 13,
        [Description("ad_account_billing_charge_failed")]
        AdAccountBillingChargeFailed = 14,
        [Description("ad_account_billing_chargeback")]
        AdAccountBillingChargeback = 15,
        [Description("ad_account_billing_chargeback_reversal")]
        AdAccountBillingChargebackReversal = 16,
        [Description("ad_account_billing_decline")]
        AdAccountBillingDecline = 17,
        [Description("ad_account_billing_refund")]
        AdAccountBillingRefund = 18,
        [Description("billing_event")]
        BillingEvent = 19,
        [Description("add_funding_source")]
        AddFundingSource = 20,
        [Description("remove_funding_source")]
        RemoveFundingSource = 21,
        [Description("create_campaign_group")]
        CreateCampaignGroup = 22,
        [Description("update_campaign_name")]
        UpdateCampaignName = 23,
        [Description("update_campaign_run_status")]
        UpdateCampaignRunStatus = 24,
        [Description("update_campaign_group_spend_cap")]
        UpdateCampaignGroupSpendCap = 25,
        [Description("create_campaign_legacy")]
        CreateCampaignLegacy = 26,
        [Description("update_campaign_budget")]
        UpdateCampaignBudget = 27,
        [Description("campaign_ended")]
        CampaignEnded = 28,
        [Description("update_campaign_group_ad_scheduling")]
        UpdateCampaignGroupAdScheduling = 29,
        [Description("update_campaign_group_delivery_type")]
        UpdateCampaignGroupDeliveryType = 30,
        [Description("update_campaign_budget_optimization_toggling_status")]
        UpdateCampaignBudgetOptimizationTogglingStatus = 31,
        [Description("update_delivery_type_cross_level_shift")]
        UpdateDeliveryTypeCrossLevelShift = 32,
        [Description("update_campaign_group_high_demand_periods")]
        UpdateCampaignGroupHighDemandPeriods = 33,
        [Description("update_campaign_group_budget_scheduling_state")]
        UpdateCampaignGroupBudgetSchedulingState = 34,
        [Description("create_ad_set")]
        UpdateAdSet = 35,
        [Description("update_ad_set_bidding")]
        UpdateAdSetBidding = 36,
        [Description("update_ad_set_bid_strategy")]
        UpdateAdSetBidStrategy = 37,
        [Description("update_ad_set_budget")]
        UpdateAdSetBudget = 38,
        [Description("update_ad_set_duration")]
        UpdateAdSetDuration = 39,
        [Description("update_ad_set_run_status")]
        UpdateAdSetRunStatus = 40,
        [Description("update_ad_set_name")]
        UpdateAdSetName = 41,
        [Description("update_ad_set_optimization_goal")]
        UpdateAdSetOptimizationGoal = 42,
        [Description("update_ad_set_target_spec")]
        UpdateAdSetTargetSpec = 43,
        [Description("update_ad_set_ad_keywords")]
        UpdateAdSetAdKeywords = 44,
        [Description("update_ad_set_bid_adjustments")]
        UpdateAdSetBidAdjustments = 45,
        [Description("update_campaign_ad_scheduling")]
        UpdateCampaignAdScheduling = 46,
        [Description("update_campaign_delivery_destination")]
        UpdateCampaignDeliveryDestination = 47,
        [Description("update_campaign_delivery_type")]
        UpdateCampaignDeliveryType = 48,
        [Description("update_campaign_schedule")]
        UpdateCampaignSchedule = 49,
        [Description("update_ad_set_spend_cap")]
        UpdateAdSetSpendCap = 50,
        [Description("update_ad_set_min_spend_target")]
        UpdateAdSetMinSpendTarget = 51,
        [Description("update_ad_set_learning_stage_status")]
        UpdateAdSetLearningStageStatus = 52,
        [Description("update_campaign_high_demand_periods")]
        UpdateCampaignHighDemandPeriods = 53,
        [Description("update_campaign_budget_scheduling_state")]
        UpdateCampaignBudgetSchedulingState = 54,
        [Description("update_campaign_conversion_goal")]
        UpdateCampaignConversionGoal = 55,
        [Description("update_campaign_value_adjustment_rule")]
        UpdateCampaignValueAdjustmentRule = 56,
        [Description("merge_campaigns")]
        MergeCampaigns = 57,
        [Description("create_ad")]
        CreateAd = 58,
        [Description("ad_review_approved")]
        AdReviewApproved = 59,
        [Description("ad_review_declined")]
        AdReviewDeclined = 60,
        [Description("update_ad_creative")]
        UpdateAdCreative = 61,
        [Description("edit_and_update_ad_creative")]
        EditAndUpdateAdCreative = 62,
        [Description("update_ad_bid_info")]
        UpdateAdBidInfo = 63,
        [Description("update_ad_bid_type")]
        UpdateAdBidType = 64,
        [Description("update_ad_run_status")]
        UpdateAdRunStatus = 65,
        [Description("update_ad_run_status_to_be_set_after_review")]
        UpdateAdRunStatusToBeSetAfterReview = 66,
        [Description("update_ad_friendly_name")]
        UpdateAdFriendlyName = 67,
        [Description("update_ad_targets_spec")]
        UpdateAdTargetsSpec = 68,
        [Description("update_adgroup_stop_delivery")]
        UpdateAdgroupStopDelivery = 69,
        [Description("first_delivery_event")]
        FirstDeliveryEvent = 70,
        [Description("create_audience")]
        CreateAudience = 71,
        [Description("update_audience")]
        UpdateAudience = 72,
        [Description("delete_audience")]
        DeleteAudience = 73,
        [Description("share_audience")]
        ShareAudience = 74,
        [Description("receive_audience")]
        ReceiveAudience = 75,
        [Description("unshare_audience")]
        UnshareAudience = 76,
        [Description("remove_shared_audience")]
        RemoveSharedAudience = 77,
        [Description("unknown")]
        Unknown = 78,
        [Description("account_spending_limit_reached")]
        AccountSpendingLimitReached = 79,
        [Description("campaign_spending_limit_reached")]
        CampaignSpendingLimitReached = 80,
        [Description("lifetime_budget_spent")]
        LifetimeBudgetSpent = 81,
        [Description("conversion_event_updated")]
        ConversionEventUpdated = 82,
        [Description("funding_event_initiated")]
        FundingEventInitiated = 83,
        [Description("funding_event_successful")]
        FundingEventSuccessful = 84,
        [Description("update_ad_labels")]
        UpdateAdLabels = 84,
        [Description("di_ad_set_learning_stage_exit")]
        DIAdSetLearningStageExit = 85,
    }
}

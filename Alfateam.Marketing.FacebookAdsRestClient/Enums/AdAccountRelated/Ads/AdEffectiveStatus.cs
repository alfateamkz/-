using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated.Ads
{
    public enum AdEffectiveStatus
    {
        [Description("ACTIVE")]
        Active = 1,
        [Description("PAUSED")]
        Paused = 2,
        [Description("DELETED")]
        Deleted = 3,
        [Description("PENDING_REVIEW")]
        PendingReview = 4,
        [Description("DISAPPROVED")]
        Disapproved = 5,
        [Description("PREAPPROVED")]
        PreApproved = 6,
        [Description("PENDING_BILLING_INFO")]
        PendingBillingInfo = 7,
        [Description("CAMPAIGN_PAUSED")]
        CampaignPaused = 8,
        [Description("ARCHIVED")]
        Archived = 9,
        [Description("ADSET_PAUSED")]
        AdSetPaused = 10,
        [Description("IN_PROCESS")]
        InProgress = 11,
        [Description("WITH_ISSUES")]
        WithIssues = 12,
    }
}

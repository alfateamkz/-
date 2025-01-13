using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums
{
    public enum AdAccountStatus
    {
        [Description("ACTIVE")]
        Active = 1,
        [Description("DISABLED")]
        Disabled = 2,
        [Description("UNSETTLED")]
        Unsettled = 3,
        [Description("PENDING_RISK_REVIEW")]
        PendingRiskReview = 7,
        [Description("PENDING_SETTLEMENT")]
        PendingSettlement = 8,
        [Description("IN_GRACE_PERIOD")]
        InGracePeriod = 9,
        [Description("PENDING_CLOSURE")]
        PendingClosure = 100,
        [Description("CLOSED")]
        Closed = 101,
        [Description("ANY_ACTIVE")]
        AnyActive = 201,
        [Description("ANY_CLOSED")]
        AnyClosed = 202,
    }
}

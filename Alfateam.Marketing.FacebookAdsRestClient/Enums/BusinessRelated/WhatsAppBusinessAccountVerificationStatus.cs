using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.BusinessRelated
{
    public enum WhatsAppBusinessAccountVerificationStatus
    {
        [Description("expired")]
        Expired = 1,
        [Description("failed")]
        Failed = 2,
        [Description("ineligible")]
        Ineligible = 3,
        [Description("not_verified")]
        NotVerified = 4,
        [Description("pending")]
        Pending = 5,
        [Description("pending_need_more_info")]
        PendingNeedMoreInfo = 6,
        [Description("pending_submission")]
        PendingSubmission = 7,
        [Description("rejected")]
        Rejected = 8,
        [Description("revoked")]
        Revoked = 9,
        [Description("verified")]
        Verified = 10,
    }
}

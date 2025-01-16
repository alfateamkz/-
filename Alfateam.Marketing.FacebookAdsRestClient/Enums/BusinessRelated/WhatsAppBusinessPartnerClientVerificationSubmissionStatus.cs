using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.BusinessRelated
{
    public enum WhatsAppBusinessPartnerClientVerificationSubmissionStatus
    {
        [Description("PENDING")]
        Pending = 1,
        [Description("APPROVED")]
        Approved = 2,
        [Description("REJECTED")]
        Rejected = 3,
        [Description("REVOKED")]
        Revoked = 3,
    }
}

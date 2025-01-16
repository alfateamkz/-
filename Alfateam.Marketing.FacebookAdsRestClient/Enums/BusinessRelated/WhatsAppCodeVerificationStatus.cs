using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.BusinessRelated
{
    public enum WhatsAppCodeVerificationStatus
    {
        [Description("EXPIRED")]
        Expired = 1,
        [Description("NOT_VERIFIED")]
        NotVerified = 2,
        [Description("VERIFIED")]
        Verified = 3,
    }
}

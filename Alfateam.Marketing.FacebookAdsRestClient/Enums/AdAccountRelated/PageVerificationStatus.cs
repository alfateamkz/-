using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated
{
    public enum PageVerificationStatus
    {
        [Description("blue_verified")]
        BlueVerified = 1,
        [Description("gray_verified")]
        GrayVerified = 2,
        [Description("not_verified")]
        NotVerified = 3,
    }
}

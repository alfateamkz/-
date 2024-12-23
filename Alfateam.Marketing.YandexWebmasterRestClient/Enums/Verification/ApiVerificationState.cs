using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Enums.Verification
{
    public enum ApiVerificationState
    {
        [Description("NONE")]
        None = 1,
        [Description("VERIFIED")]
        Verified = 2,
        [Description("IN_PROGRESS")]
        InProgress = 3,
        [Description("VERIFICATION_FAILED")]
        VerificationFailed = 4,
        [Description("INTERNAL_ERROR")]
        InternalError = 5,
    }
}

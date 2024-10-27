using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CertificationCenter.Models.Enums
{
    public enum CancellationRequestStatus
    {
        WaitingVerificationCodes = 1,
        RejectedReasonInvalidCode = 2,
        RejectedReasonFraudSystem = 3,


        Approved = 999
    }
}

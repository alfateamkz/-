using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Enums.DocumentStatuses
{
    public enum DocumentApprovalStatus
    {
        OnApprovalOrSigningStage = 1,
        Approved = 2,
        ApprovalRejected = 3,
        SigningRequestRejected = 4,
    }
}

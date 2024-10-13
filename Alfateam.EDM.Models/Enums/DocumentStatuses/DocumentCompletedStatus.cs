using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Enums.DocumentStatuses
{
    public enum DocumentCompletedStatus
    {
        DocumentFlowCompleted = 1,
        Signed = 2,
        SignedWithConflict = 3,
        SigningRejected = 4,
        Cancelled = 5,
        CancellationRejected = 6
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Enums.DocumentStatuses
{
    public enum DocumentCancellationApprovalStatus
    {
        CancellationNotRequested = 1,
        OnCancellationStage = 2,
        CancellationApproved = 3,
        CancellationRejected = 4,
    }
}

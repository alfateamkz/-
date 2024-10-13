using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Enums.DocumentStatuses
{
    public enum DocumentSigningResultType
    {
        NotSinged = 1,
        DocumentFlowCompleted = 2,
        Signed = 3,
        SignedWithConflict = 4,
        SigningRejected = 5,
    }
}

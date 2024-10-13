using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Enums.DocumentStatuses
{
    public enum DocumentCancellationResult
    {
        NotCancelled = 1,
        CancellationRequested = 2,
        Cancelled = 3,
        CancellationRejected = 4
    }
}

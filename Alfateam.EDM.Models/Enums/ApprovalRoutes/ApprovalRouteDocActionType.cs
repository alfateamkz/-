using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Enums.ApprovalRoutes
{
    public enum ApprovalRouteDocActionType
    {
        Approve = 1,
        RejectApproval = 2,
        SignWithoutDocFlow = 3,
        SignAndCompleteDocFlow = 4,
        CancelSigning = 5,
    }
}

using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.Enums.ApprovalRoutes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.ApprovalRoutes
{
    public class ApprovalRouteStageAction : AbsModel
    {
        public ApprovalRouteDocActionType ActionType { get; set; } = ApprovalRouteDocActionType.Approve;
        public ApprovalRouteDocActionResultType ResultType { get; set; } = ApprovalRouteDocActionResultType.GoToNextStage;
    }
}

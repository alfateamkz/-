using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.Abstractions.ApprovalRoutes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Core;

namespace Alfateam.EDM.Models.ApprovalRoutes
{
    public class ApprovalRoute : AbsModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }

        public int Order { get; set; }

        public List<ApprovalRouteStage> Stages { get; set; } = new List<ApprovalRouteStage>();
        public List<AfterDocSigningAction> AfterDocSigningActions { get; set; } = new List<AfterDocSigningAction>();





        public ApprovalRouteDocCondition ForInboxDocCondition { get; set; }
        public ApprovalRouteDocCondition ForOutgoingDocCondition { get; set; }
    }
}

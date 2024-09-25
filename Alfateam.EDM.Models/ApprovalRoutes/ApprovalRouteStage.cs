using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.Abstractions.ApprovalRoutes;
using Alfateam.EDM.Models.Enums;
using Alfateam.EDM.Models.Enums.ApprovalRoutes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Core;

namespace Alfateam.EDM.Models.ApprovalRoutes
{
    public class ApprovalRouteStage : AbsModel
    {
        public string Title { get; set; }


        public RouteStageExecutor Executor { get; set; }


        public DayTermType HandlingDaysType { get; set; } = DayTermType.WorkingDays;
        public int HandlingDaysLimit { get; set; }
        public ApprovalRouteHandlingNotifyTermType HandlingNotifyTermType { get; set; } = ApprovalRouteHandlingNotifyTermType.OneDayBeforeDeadline;


     

        public List<ApprovalRouteStageAction> Actions { get; set; } = new List<ApprovalRouteStageAction>();
    }
}

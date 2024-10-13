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


        /// <summary>
        /// Автоматическое поле, указывает на маршрут согласование
        /// </summary>
        public int ApprovalRouteId { get; set; }



        public bool HeedToNotifyAboutDeadline(DateTime deadline)
        {
            switch (HandlingNotifyTermType)
            {
                case ApprovalRouteHandlingNotifyTermType.OneDayBeforeDeadline:
                    if(deadline.Subtract(TimeSpan.FromDays(1)) < DateTime.UtcNow)
                    {
                        return true;
                    }
                    break;
                case ApprovalRouteHandlingNotifyTermType.OneDayAfterDeadline:
                    if (deadline.Add(TimeSpan.FromDays(1)) < DateTime.UtcNow)
                    {
                        return true;
                    }
                    break;
                case ApprovalRouteHandlingNotifyTermType.DayOfDeadline:
                    if (deadline.Date <= DateTime.UtcNow.Date)
                    {
                        return true;
                    }
                    break;
            }
            return false;
        }
        public DateTime GetDeadlineDate(DateTime startDate)
        {
            switch (HandlingDaysType)
            {
                case DayTermType.CalendarDays:
                    return startDate.AddDays(HandlingDaysLimit);
                case DayTermType.WorkingDays:
                    var deadline = startDate;

                    int counter = 0;
                    while(counter < HandlingDaysLimit)
                    {
                        if(deadline.DayOfWeek != DayOfWeek.Saturday && deadline.DayOfWeek != DayOfWeek.Sunday)
                        {
                            counter++;
                        }

                        deadline = deadline.AddDays(1);
                    }
                    return deadline;
            }
            return startDate;
        }

    }
}

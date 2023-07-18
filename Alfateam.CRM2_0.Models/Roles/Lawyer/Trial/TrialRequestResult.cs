using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Lawyer.Trial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Lawyer.Trial
{
    /// <summary>
    /// Результат подачи искового заявления в суд
    /// </summary>
    public class TrialRequestResult : AbsModel
    {
        public TrialRequestResultType Type { get; set; } = TrialRequestResultType.Approved;
        public string Description { get; set; }


        /// <summary>
        /// Назначенное слушание в случае, если Type == TrialRequestResultType.Approved
        /// </summary>
        public TrialHearing? ScheduledHearing { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.HR
{
    /// <summary>
    /// Статус решения после интервью с кандидатом
    /// </summary>
    public enum CandidateInterviewDecisionType
    {
        ReInterview = 1, //Необходимо повторное собеседование
        Approved = 2, //Кандидат одобрен
        Rejected = 3, //Кандидат не одобрен
    }
}

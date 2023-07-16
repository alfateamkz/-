using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.HR
{
    /// <summary>
    /// Статус созвона с кандидатом
    /// </summary>
    public enum CandidateCallStatus
    {
        Planned = 1, //Запланированный
        Active = 2, //Активный созвон
        Completed = 3, //Завершенный созвон
        Failed = 4, //Несостоявшийся созвон
        Postponed = 5 //Перенесенный созвон

    }
}

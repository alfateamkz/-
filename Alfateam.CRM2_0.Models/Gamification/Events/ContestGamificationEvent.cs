using Alfateam.CRM2_0.Models.Abstractions.Gamification;
using Alfateam.CRM2_0.Models.Gamification.Contests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Gamification.Events
{
    /// <summary>
    /// Сущность события в системе геймификации с привязкой к победе в конкурсе
    /// </summary>
    public class ContestGamificationEvent : GamificationEvent
    {
        public Contest Contest { get; set; }
    }
}

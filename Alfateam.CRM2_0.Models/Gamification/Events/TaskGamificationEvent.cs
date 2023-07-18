using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Gamification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Gamification.Events
{
    /// <summary>
    /// Сущность события в системе геймификации с привязкой к задаче
    /// </summary>
    public class TaskGamificationEvent : GamificationEvent
    {
        public GamificationUserTask Task { get; set; }
    }
}

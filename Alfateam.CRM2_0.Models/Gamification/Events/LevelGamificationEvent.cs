using Alfateam.CRM2_0.Models.Abstractions.Gamification;
using Alfateam.CRM2_0.Models.Gamification.Contests;
using Alfateam.CRM2_0.Models.Gamification.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Gamification.Events
{
    /// <summary>
    /// Сущность события в системе геймификации с привязкой к переходу на следующий уровень
    /// </summary>
    public class LevelGamificationEvent : GamificationEvent
    {
        public Level NewLevel { get; set; }
    }
}

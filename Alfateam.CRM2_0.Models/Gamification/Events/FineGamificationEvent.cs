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
    /// Сущность события в системе геймификации с привязкой к штрафу
    /// </summary>
    public class FineGamificationEvent : GamificationEvent
    {
        public GamificationFine Fine { get; set; }
    }
}

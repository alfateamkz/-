using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Gamification.Achievements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Gamification.Data
{
    /// <summary>
    /// Модель достижения пользователя
    /// </summary>
    public class GamificationUserAchievement : AbsModel
    {
        public Achievement Achievement { get; set; }
        public DateTime GotAt { get; set; }
    }
}

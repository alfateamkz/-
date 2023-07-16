using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Gamification.Achievements
{
    /// <summary>
    /// Модель категории достижений в геймификации
    /// </summary>
    public class AchievementCategory : AbsModel
    {
        public string Title { get; set; }
    }
}

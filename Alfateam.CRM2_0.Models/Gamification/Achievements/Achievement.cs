using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Gamification.Achievements
{
    /// <summary>
    /// Модель достижения в геймификации
    /// </summary>
    public class Achievement : AbsModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        public AchievementCategory Category { get; set; }


        public double Rating { get; set; }
        public double Reward { get; set; }
    }
}

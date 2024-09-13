using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Gamification.General
{
    /// <summary>
    /// Модель уровня в системе геймификации
    /// </summary>
    public class Level : AbsModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string ImagePath { get; set; }


        /// <summary>
        /// Автоматически проставляется при создании уровня
        /// </summary>
        public int Number { get; set; }


        public List<LevelCriteria> Criterias { get; set; } = new List<LevelCriteria>();
        public LevelReward Reward { get; set; }




        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int GamificationModelId { get; set; }

    }
}

using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Gamification.General
{
    /// <summary>
    /// Награда за достижение уровня
    /// </summary>
    public class LevelReward : AbsModel
    {
        public double Rating { get; set; }
        public double Coins { get; set; }



        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int LevelId { get; set; }
    }
}

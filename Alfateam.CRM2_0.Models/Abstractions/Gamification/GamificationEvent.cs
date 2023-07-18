using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Abstractions.Gamification
{
    /// <summary>
    /// Базовая сущность события в системе геймификации
    /// </summary>
    public abstract class GamificationEvent : AbsModel
    {
        /// <summary>
        /// Название события
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Полученное количество монет
        /// </summary>
        public double Coins { get; set; }

        /// <summary>
        /// Полученное количество рейтинга
        /// </summary>
        public double Karma { get; set; }
    }
}

using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Gamification.Contests
{
    /// <summary>
    /// Модель мест в конкурсе
    /// </summary>
    public class ContestPlaces : AbsModel
    {
        /// <summary>
        /// Первое значение места. Если SecondValue == null, то нет диапазона и имеется единственное место
        /// Если есть - значит есть диапазон мест. Например: с 5 по 10 место
        /// </summary>
        public int FirstValue { get; set; }
        public int? SecondValue { get; set; }


        public ContestPrize Prize { get; set; }



    }
}

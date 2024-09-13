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
        public double Coins { get; set; }
        public double Rating { get; set; }




        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int ContestId { get; set; }



        public bool ArePlacesCorrect()
        {
            if (SecondValue == null && FirstValue > 0) return true;
            return FirstValue < SecondValue;
        }
        public int GetLastPlace()
        {
            if (SecondValue == null) return FirstValue;
            return (int)SecondValue;
        }
    }
}

using Alfateam.EDM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Core;

namespace Alfateam.EDM.Models
{
    public class EDMProvider : AbsModel
    {
        public string Title { get; set; }
        public string CountryCode { get; set; }


        /// <summary>
        /// Вшит ли тип провайдер ЭДО в систему. Если false, то создан пользователем
        /// </summary>
        public bool IsDefault { get; set; }


        /// <summary>
        /// Доступен ли роуминг между Alfateam ЭДО и данным провайдером
        /// </summary>
        public bool IsRoamingAvailable { get; set; }
    }
}

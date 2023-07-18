using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.General
{
    /// <summary>
    /// Сущность стоимости по разным странам
    /// </summary>
    public class PricingItem : AbsModel
    {
        /// <summary>
        /// Страны, на которые действует ценовая политика
        /// </summary>
        public List<Country> Countries { get; set; } = new List<Country>();
        public Cost Cost { get; set; }
    }
}

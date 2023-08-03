using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Promocodes
{
    /// <summary>
    /// Сущность промокода с фиксированным значением
    /// </summary>
    public class PricePromocode : Promocode
    {
        public PricingMatrix Discount { get; set; }
    }
}

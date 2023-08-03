using Alfateam2._0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Abstractions
{
    /// <summary>
    /// Базовая сущность промокода
    /// </summary>
    public abstract class Promocode : AvailabilityModel
    {
        public string Code { get; set; }


        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsReusable { get; set; }


        /// <summary>
        /// С какой стоимости начинает действовать промокод
        /// </summary>
        public PricingMatrix? PriceFrom { get; set; }
        /// <summary>
        /// До какой стоимости начинает действовать промокод
        /// </summary>
        public PricingMatrix? PriceTo { get; set; }
    }
}

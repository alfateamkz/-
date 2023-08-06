using Alfateam2._0.Models.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Abstractions
{
    /// <summary>
    /// Базовая сущность промокода
    /// </summary>
    public abstract class Promocode : AvailabilityModel
    {

        //TODO: посмотреть по коду доступность промокода
        public string Code { get; set; }


        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        [JsonIgnore, NotMapped]
        public bool IsExpired => DateTime.UtcNow >= EndDate;

        public bool IsReusable { get; set; }


        /// <summary>
        /// С какой стоимости начинает действовать промокод
        /// </summary>
        public PricingMatrix? PriceFrom { get; set; }
        /// <summary>
        /// До какой стоимости начинает действовать промокод
        /// </summary>
        public PricingMatrix? PriceTo { get; set; }



        public bool IsCostInRange(Cost cost)
        {
            //TODO: реализовать логику
            return true;
        }

    }
}

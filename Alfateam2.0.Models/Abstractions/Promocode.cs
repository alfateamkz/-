using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Promocodes;
using JsonKnownTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Abstractions
{


    [JsonConverter(typeof(JsonKnownTypesConverter<Promocode>))]
    [JsonDiscriminator(Name = "Discriminator")]
    [JsonKnownType(typeof(PricePromocode), "PricePromocode")]
    [JsonKnownType(typeof(UsedPromocode), "UsedPromocode")]
    /// <summary>
    /// Базовая сущность промокода
    /// </summary>
    public abstract class Promocode : AvailabilityModel
    {
        [NotMapped]
        public abstract PromocodeType Type { get; }
        public string Discriminator { get; set; }

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



        public bool IsCostInRange(Cost cost,int? countryId)
        {
            bool isInRange = true;

            double? fromCost = PriceFrom?.GetPrice(countryId, cost.CurrencyId)?.Value;
            double? toCost = PriceTo?.GetPrice(countryId, cost.CurrencyId)?.Value;

            if(PriceFrom != null)
            {
                if(fromCost != null)
                {
                    isInRange &= cost.Value >= fromCost;
                }
                else return false;
            }

            if (PriceTo != null)
            {
                if (toCost != null)
                {
                    isInRange &= cost.Value <= toCost;
                }
                else return false;
            }

            return isInRange;
        }

    }
}

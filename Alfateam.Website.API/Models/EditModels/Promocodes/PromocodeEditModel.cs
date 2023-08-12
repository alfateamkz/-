using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Promocodes;
using JsonKnownTypes;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Alfateam.Website.API.Models.EditModels.Promocodes
{
    
    [JsonConverter(typeof(JsonKnownTypesConverter<Promocode>))]
    [JsonDiscriminator(Name = "Discriminator")]
    [JsonKnownType(typeof(PricePromocodeEditModel), "PricePromocode")]
    [JsonKnownType(typeof(PercentPromocodeEditModel), "PercentPromocode")]
    public abstract class PromocodeEditModel : EditModel<Promocode>
    {
        //TODO: Реализовать получение типа по Discriminator
        public abstract string Discriminator { get; }

        public string Code { get; set; }


        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool IsReusable { get; set; }


        public PricingMatrix? PriceFrom { get; set; }
        public PricingMatrix? PriceTo { get; set; }

    }
}

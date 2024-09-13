using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Promocodes;
using JsonKnownTypes;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Alfateam.Website.API.Models.CreateModels.Promocodes
{
    
    [JsonConverter(typeof(JsonKnownTypesConverter<PromocodeCreateModel>))]
    [JsonDiscriminator(Name = "Discriminator")]
    [JsonKnownType(typeof(PricePromocodeCreateModel), "PricePromocode")]
    [JsonKnownType(typeof(PercentPromocodeCreateModel), "PercentPromocode")]
    public abstract class PromocodeCreateModel : CreateModel<Promocode>
    {
        public abstract string Discriminator { get; }

        public string Code { get; set; }


        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool IsReusable { get; set; }


        public PricingMatrix? PriceFrom { get; set; }
        public PricingMatrix? PriceTo { get; set; }

    }
}

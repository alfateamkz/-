using Alfateam.Sales.API.Models.DTO.Plan.Types;
using Alfateam.Sales.Models.Abstractions;
using Alfateam.Sales.Models.Enums;
using Alfateam.Sales.Models.Plan.Types;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.Sales.API.Models.DTO.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<SalesPlanDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(ByFunnelsSalesPlanDTO), "ByFunnelsSalesPlan")]
    [JsonKnownType(typeof(ByManagersSalesPlanDTO), "ByManagersSalesPlan")]
    [JsonKnownType(typeof(ForAllCompanySalesPlanDTO), "ForAllCompanySalesPlan")]
    public class SalesPlanDTO : DTOModelAbs<SalesPlan>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }

        public string Title { get; set; }
        public string? Description { get; set; }
        public SalesPlanTargetType Target { get; set; }
    }
}

using Alfateam.Sales.API.Models.DTO.Tasks.AsCompleted;
using Alfateam.Sales.Models.Abstractions.Tasks;
using Alfateam.Sales.Models.Tasks.AsCompleted;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.Sales.API.Models.DTO.Abstractions.Tasks
{
    [JsonConverter(typeof(JsonKnownTypesConverter<MarkedAsCompletedDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(SimpleMarkedAsCompletedDTO), "SimpleMarkedAsCompleted")]
    [JsonKnownType(typeof(WithAmountMarkedAsCompletedDTO), "WithAmountMarkedAsCompleted")]
    public class MarkedAsCompletedDTO : DTOModelAbs<MarkedAsCompleted>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public string? Comment { get; set; }
    }
}

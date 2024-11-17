using Alfateam.Sales.API.Models.ByEmployees;
using Alfateam.Sales.API.Models.ByValue;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.Sales.API.Abstractions
{

    [JsonConverter(typeof(JsonKnownTypesConverter<ByValueFilter>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(ConditionalByValueFilter), "ConditionalByValueFilter")]
    [JsonKnownType(typeof(RangeByValueFilter), "RangeByValueFilter")]
    public class ByValueFilter
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }
    }
}

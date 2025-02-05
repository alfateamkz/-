using Alfateam.Marketing.API.Models.DTO.SalesGenerators.StartOptions;
using Alfateam.Marketing.Models.Abstractions;
using Alfateam.Marketing.Models.SalesGenerators.StartOptions;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.Marketing.API.Models.DTO.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<SalesGeneratorStartOptionsDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(StartAtSGStartOptionsDTO), "StartAtSGStartOptions")]
    [JsonKnownType(typeof(StartEveryDaySGStartOptionsDTO), "StartEveryDaySGStartOptions")]
    [JsonKnownType(typeof(StartManuallySGStartOptionsDTO), "StartManuallySGStartOptions")]
    [JsonKnownType(typeof(StartNowSGStartOptionsDTO), "StartNowSGStartOptions")]
    public class SalesGeneratorStartOptionsDTO : DTOModelAbs<SalesGeneratorStartOptions>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }
    }
}

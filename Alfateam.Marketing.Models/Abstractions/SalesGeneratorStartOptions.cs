using Alfateam.Core;
using Alfateam.Marketing.Models.SalesGenerators;
using Alfateam.Marketing.Models.SalesGenerators.StartOptions;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Abstractions
{

    [JsonConverter(typeof(JsonKnownTypesConverter<SalesGeneratorStartOptions>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(StartAtSGStartOptions), "StartAtSGStartOptions")]
    [JsonKnownType(typeof(StartEveryDaySGStartOptions), "StartEveryDaySGStartOptions")]
    [JsonKnownType(typeof(StartManuallySGStartOptions), "StartManuallySGStartOptions")]
    [JsonKnownType(typeof(StartNowSGStartOptions), "StartNowSGStartOptions")]
    public class SalesGeneratorStartOptions : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }
    }
}

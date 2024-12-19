using Alfateam.SharedModels.Abstractions;
using Alfateam.SharedModels.DTO.Filters.ByValue;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.SharedModels.DTO.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<ByValueFilterDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(ConditionalByValueFilterDTO), "ConditionalByValueFilter")]
    [JsonKnownType(typeof(RangeByValueFilterDTO), "RangeByValueFilter")]
    public class ByValueFilterDTO : DTOModelAbs<ByValueFilter>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }
    }
}

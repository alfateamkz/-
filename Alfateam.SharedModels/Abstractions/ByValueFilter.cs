using Alfateam.Core;
using Alfateam.SharedModels.Filters.ByValue;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.SharedModels.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<ByValueFilter>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(ConditionalByValueFilter), "ConditionalByValueFilter")]
    [JsonKnownType(typeof(RangeByValueFilter), "RangeByValueFilter")]
    public class ByValueFilter : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }
    }
}

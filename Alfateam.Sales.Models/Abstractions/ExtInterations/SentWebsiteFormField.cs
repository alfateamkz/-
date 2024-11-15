using Alfateam.Core;
using Alfateam.Sales.Models.ExternalInteractions.SentForms.Fields;
using Alfateam.Sales.Models.ExternalInteractions.SentForms.Values;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Abstractions.ExtInterations
{
    [JsonConverter(typeof(JsonKnownTypesConverter<SentWebsiteFormField>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(FilesSentFormField), "FilesSentFormField")]
    [JsonKnownType(typeof(SimpleSentFormField), "SimpleSentFormField")]
    public class SentWebsiteFormField : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }

        public string FieldName { get; set; }
    }
}

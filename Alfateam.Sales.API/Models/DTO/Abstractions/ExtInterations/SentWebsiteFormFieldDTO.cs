using Alfateam.Sales.API.Models.DTO.ExternalInteractions.SentForms.Fields;
using Alfateam.Sales.Models.Abstractions.ExtInterations;
using Alfateam.Sales.Models.ExternalInteractions.SentForms.Fields;
using Alfateam.Sales.Models.ExternalInteractions.SentForms.Values;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.Sales.API.Models.DTO.Abstractions.ExtInterations
{
    [JsonConverter(typeof(JsonKnownTypesConverter<SentWebsiteFormFieldDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(FilesSentFormFieldDTO), "FilesSentFormField")]
    [JsonKnownType(typeof(SimpleSentFormFieldDTO), "SimpleSentFormField")]
    public class SentWebsiteFormFieldDTO : DTOModelAbs<SentWebsiteFormField>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }

        public string FieldName { get; set; }
    }
}

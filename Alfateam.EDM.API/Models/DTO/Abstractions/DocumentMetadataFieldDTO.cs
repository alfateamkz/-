using Alfateam.EDM.API.Models.DTO.Documents.Meta.Fields;
using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.Documents.Meta.Fields;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.EDM.API.Models.DTO.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<DocumentMetadataFieldDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(DocumentMetadataCurrencyCodeFieldDTO), "DocumentMetadataCurrencyCodeField")]
    [JsonKnownType(typeof(DocumentMetadataDateFieldDTO), "DocumentMetadataDateField")]
    [JsonKnownType(typeof(DocumentMetadataDoubleFieldDTO), "DocumentMetadataDoubleField")]
    [JsonKnownType(typeof(DocumentMetadataIntegerFieldDTO), "DocumentMetadataIntegerField")]
    [JsonKnownType(typeof(DocumentMetadataStringFieldDTO), "DocumentMetadataStringField")]
    [JsonKnownType(typeof(DocumentMetadataTaxSumInfoFieldDTO), "DocumentMetadataTaxSumInfoField")]
    public class DocumentMetadataFieldDTO : DTOModelAbs<DocumentMetadataField>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public string FieldName { get; set; }
    }
}

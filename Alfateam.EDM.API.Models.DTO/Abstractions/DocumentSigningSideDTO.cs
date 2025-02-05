using Alfateam.EDM.API.Models.DTO.Documents.DocumentSigning.Sides;
using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.Documents.DocumentSigning.Sides;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.EDM.API.Models.DTO.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<DocumentSigningSideDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(AlfateamEDMDocumentSigningSideDTO), "AlfateamEDMDocumentSigningSide")]
    [JsonKnownType(typeof(CompanyDocumentSigningSideDTO), "CompanyDocumentSigningSide")]
    [JsonKnownType(typeof(IndividualDocumentSigningSideDTO), "IndividualDocumentSigningSide")]
    public class DocumentSigningSideDTO : DTOModelAbs<DocumentSigningSide>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }
    }
}

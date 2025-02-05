using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.API.Models.DTO.Documents.DocumentSigning.Results;
using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.Documents.DocumentSigning.Results;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.EDM.API.Models.DTO.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<DocumentSigningResultDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(DocumentRejectedResultDTO), "DocumentRejectedResult")]
    [JsonKnownType(typeof(DocumentSuccessfullySignedResultDTO), "DocumentSuccessfullySignedResult")]
    public class DocumentSigningResultDTO : DTOModelAbs<DocumentSigningResult>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        [ForClientOnly]
        public DocumentSigningSideDTO Side { get; set; }
        public int SideId { get; set; }
    }
}

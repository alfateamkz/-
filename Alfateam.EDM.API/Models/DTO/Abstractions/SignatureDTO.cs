using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.API.Models.DTO.Documents.DocumentSigning.Signatures;
using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.Documents.DocumentSigning.Signatures;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.EDM.API.Models.DTO.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<SignatureDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(AlfateamEDMSignatureDTO), "AlfateamEDMSignature")]
    [JsonKnownType(typeof(MarkedAsElectronicallySignatureDTO), "MarkedAsElectronicallySignature")]
    [JsonKnownType(typeof(ScanSignatureDTO), "ScanSignature")]
    [JsonKnownType(typeof(ScanSignatureWithoutDocFlowDTO), "ScanSignatureWithoutDocFlow")]
    public class SignatureDTO : DTOModelAbs<Signature>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        [ForClientOnly]
        public DocumentSigningSideDTO Side { get; set; }
        public int SideId { get; set; }
    }
}

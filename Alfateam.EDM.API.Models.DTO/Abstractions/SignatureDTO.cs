using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.API.Models.DTO.Documents.DocumentSigning.Signatures;
using Alfateam.EDM.API.Models.DTO.General;
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
    [JsonKnownType(typeof(ScanSignatureDTO), "ScanSignature")]
    public class SignatureDTO : DTOModelAbs<Signature>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        [ForClientOnly]
        public DocumentSigningSideDTO Side { get; set; }
        public int SideId { get; set; }



        [ForClientOnly]
        public UserDTO SignedBy { get; set; }
        [ForClientOnly]
        public int SignedById { get; set; }
    }
}

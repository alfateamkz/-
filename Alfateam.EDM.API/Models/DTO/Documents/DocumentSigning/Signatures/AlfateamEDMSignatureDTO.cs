using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.API.Models.DTO.Abstractions;
using Alfateam.EDM.API.Models.DTO.General;

namespace Alfateam.EDM.API.Models.DTO.Documents.DocumentSigning.Signatures
{
    public class AlfateamEDMSignatureDTO : SignatureDTO
    {
        public string PublicKey { get; set; }
        public byte[] Signature { get; set; }
    }
}

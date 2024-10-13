using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.API.Models.DTO.Abstractions;
using Alfateam.EDM.API.Models.DTO.General;

namespace Alfateam.EDM.API.Models.DTO.Documents.DocumentSigning.Signatures
{
    public class ScanSignatureDTO : SignatureDTO
    {
        [ForClientOnly]
        public UserDTO SignedBy { get; set; }
        [ForClientOnly]
        public int SignedById { get; set; }

        [ForClientOnly]
        public string ScanPath { get; set; }
    }
}

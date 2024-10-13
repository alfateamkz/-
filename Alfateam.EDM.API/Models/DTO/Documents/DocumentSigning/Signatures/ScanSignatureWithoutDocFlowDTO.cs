using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.API.Models.DTO.Abstractions;

namespace Alfateam.EDM.API.Models.DTO.Documents.DocumentSigning.Signatures
{
    public class ScanSignatureWithoutDocFlowDTO : SignatureDTO
    {
        [ForClientOnly]
        public string ScanPath { get; set; }
    }
}

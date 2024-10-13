using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.API.Models.DTO.Abstractions;

namespace Alfateam.EDM.API.Models.DTO.Documents.DocumentSigning.Signatures
{
    public class MarkedAsElectronicallySignatureDTO : SignatureDTO
    {
        [ForClientOnly]
        public EDMProviderDTO EDMProvider { get; set; }
        public int EDMProviderId { get; set; }
    }
}

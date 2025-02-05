using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.Models.Documents.DocumentSigning;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.EDM.API.Models.DTO.Documents.DocumentSigning
{
    public class SignedDocumentRoamingInfoDTO : DTOModelAbs<SignedDocumentRoamingInfo>
    {
        [ForClientOnly]
        public EDMProviderDTO Provider { get; set; }
        public int ProviderId { get; set; }
    }
}

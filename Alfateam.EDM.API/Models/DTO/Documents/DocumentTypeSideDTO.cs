using Alfateam.EDM.Models.Documents;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.EDM.API.Models.DTO.Documents
{
    public class DocumentTypeSideDTO : DTOModelAbs<DocumentTypeSide>
    {
        public string Title { get; set; }
        public bool IsSignatureRequired { get; set; }
    }
}

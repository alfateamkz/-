using Alfateam.EDM.API.Models.DTO.Abstractions;
using Alfateam.EDM.Models.Documents;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.EDM.API.Models.DTO.Documents
{
    public class DocumentsParcelDTO : DTOModelAbs<DocumentsParcel>
    {
        public List<DocumentDTO> Documents { get; set; } = new List<DocumentDTO>();
    }
}

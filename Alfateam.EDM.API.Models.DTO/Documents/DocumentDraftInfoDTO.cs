using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.API.Models.DTO.General;
using Alfateam.EDM.Models.Documents;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.EDM.API.Models.DTO.Documents
{
    public class DocumentDraftInfoDTO : DTOModelAbs<DocumentDraftInfo>
    {
        [ForClientOnly]
        public DepartmentDTO Department { get; set; }
        public int DepartmentId { get; set; }

        public string? Comment { get; set; }
    }
}

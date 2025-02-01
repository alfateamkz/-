using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.API.Models.DTO.General;
using Alfateam.EDM.Models.Documents.DocumentSigning;
using Alfateam.EDM.Models.Enums;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.EDM.API.Models.DTO.Documents.DocumentSigning
{
    public class DocumentCancellationApprovalResultDTO : DTOModelAbs<DocumentCancellationApprovalResult>
    {
        [ForClientOnly]
        public UserDTO User { get; set; }





        [ForClientOnly]
        public DocumentCancellationApprovalResultType ResultType { get; set; }

        [ForClientOnly]
        public string? Comment { get; set; }
    }
}

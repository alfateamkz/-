using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.Models.Documents.DocumentSigning;
using Alfateam.EDM.Models.Enums.DocumentStatuses;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.EDM.API.Models.DTO.Documents.DocumentSigning
{
    public class DocumentCancellationApprovalMetadataDTO : DTOModelAbs<DocumentCancellationApprovalMetadata>
    {
        [ForClientOnly]
        public DocumentCancellationApprovalStatus Status { get; set; }

        [ForClientOnly]
        public DateTime LastUpdateDate { get; set; }

        [ForClientOnly]
        public List<DocumentCancellationApprovalResultDTO> ApprovalResults { get; set; } = new List<DocumentCancellationApprovalResultDTO>();
    }
}

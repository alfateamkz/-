using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.API.Models.DTO.ApprovalRoutes;
using Alfateam.EDM.Models.ApprovalRoutes;
using Alfateam.EDM.Models.Documents.DocumentSigning;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.EDM.API.Models.DTO.Documents.DocumentSigning
{
    public class DocumentApprovalMetadataDTO : DTOModelAbs<DocumentApprovalMetadata>
    {
        /// <summary>
        /// Используется, если документ пущен по маршруту согласования
        /// </summary>
        [ForClientOnly]
        public ApprovalRouteDTO? ApprovalRoute { get; set; }
        [ForClientOnly]
        public List<DocumentApprovalResultDTO> ApprovalResults { get; set; } = new List<DocumentApprovalResultDTO>();
    }
}

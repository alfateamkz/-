using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.API.Models.DTO.ApprovalRoutes;
using Alfateam.EDM.API.Models.DTO.General;
using Alfateam.EDM.Models.ApprovalRoutes;
using Alfateam.EDM.Models.Documents.DocumentSigning;
using Alfateam.EDM.Models.Enums;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.EDM.API.Models.DTO.Documents.DocumentSigning
{
    public class DocumentApprovalResultDTO : DTOModelAbs<DocumentApprovalResult>
    {
        [ForClientOnly]
        public UserDTO User { get; set; }
        [ForClientOnly]
        public int UserId { get; set; }



        /// <summary>
        /// Используется, если документ пущен по маршруту согласования
        /// </summary>
        [ForClientOnly]
        public ApprovalRouteStageDTO? ApprovalRouteStage { get; set; }


        [DTOFieldFor(DTOFieldForType.CreationOnly)]
        public DocumentApprovalResultType ResultType { get; set; }
        [DTOFieldFor(DTOFieldForType.CreationOnly)]
        public string? Comment { get; set; }
    }
}

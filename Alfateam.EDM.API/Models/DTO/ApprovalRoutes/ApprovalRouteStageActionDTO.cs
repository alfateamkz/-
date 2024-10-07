using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.Models.ApprovalRoutes;
using Alfateam.EDM.Models.Enums.ApprovalRoutes;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.EDM.API.Models.DTO.ApprovalRoutes
{
    public class ApprovalRouteStageActionDTO : DTOModelAbs<ApprovalRouteStageAction>
    {
        public ApprovalRouteDocActionType ActionType { get; set; }
        public ApprovalRouteDocActionResultType ResultType { get; set; }


        [DTOFieldFor(DTOFieldForType.CreationOnly)]
        public int ApprovalRouteStageId { get; set; }
    }
}

using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.API.Models.DTO.Abstractions.ApprovalRoutes;
using Alfateam.EDM.Models.Abstractions.ApprovalRoutes;
using Alfateam.EDM.Models.ApprovalRoutes;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.EDM.API.Models.DTO.ApprovalRoutes
{
    public class ApprovalRouteDTO : DTOModelAbs<ApprovalRoute>
    {
        public string Title { get; set; }
        public string? Description { get; set; }

        public int Order { get; set; }

        [ForClientOnly]
        public List<ApprovalRouteStageDTO> Stages { get; set; } = new List<ApprovalRouteStageDTO>();
        [ForClientOnly]
        public List<AfterDocSigningActionDTO> AfterDocSigningActions { get; set; } = new List<AfterDocSigningActionDTO>();




        [ForClientOnly]
        public ApprovalRouteDocConditionDTO ForInboxDocCondition { get; set; }
        [ForClientOnly]
        public ApprovalRouteDocConditionDTO ForOutgoingDocCondition { get; set; }
    }
}

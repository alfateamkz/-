using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.API.Models.DTO.Abstractions;
using Alfateam.EDM.API.Models.DTO.ApprovalRoutes;
using Alfateam.EDM.Models.ApprovalRoutes;
using System.ComponentModel;

namespace Alfateam.EDM.API.Models.DTO.Documents.DocumentSigning.ApproveStrategies
{
    public class DocumentApprovalRouteStrategyDTO : DocumentApproveStrategyDTO
    {
        [ForClientOnly]
        public ApprovalRouteDTO ApprovalRoute { get; set; }

        [HiddenFromClient]
        public int ApprovalRouteId { get; set; }


        [ForClientOnly]
        [Description("На каком этапе маршрута согласования сейчас находится документ")]
        public ApprovalRouteStageDTO? ApprovalRouteStage { get; set; }

        [HiddenFromClient]
        public int? ApprovalRouteStageId { get; set; }
    }
}

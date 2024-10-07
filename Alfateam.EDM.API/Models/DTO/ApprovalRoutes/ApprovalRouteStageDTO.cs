using Alfateam.EDM.Models.Abstractions.ApprovalRoutes;
using Alfateam.EDM.Models.ApprovalRoutes;
using Alfateam.EDM.Models.Enums.ApprovalRoutes;
using Alfateam.EDM.Models.Enums;
using Alfateam.Website.API.Abstractions;
using Alfateam.EDM.API.Models.DTO.Abstractions.ApprovalRoutes;
using Alfateam.Core.Attributes.DTO;

namespace Alfateam.EDM.API.Models.DTO.ApprovalRoutes
{
    public class ApprovalRouteStageDTO : DTOModelAbs<ApprovalRouteStage>
    {
        public string Title { get; set; }


        public RouteStageExecutorDTO Executor { get; set; }


        public DayTermType HandlingDaysType { get; set; }
        public int HandlingDaysLimit { get; set; }
        public ApprovalRouteHandlingNotifyTermType HandlingNotifyTermType { get; set; }




        public List<ApprovalRouteStageActionDTO> Actions { get; set; } = new List<ApprovalRouteStageActionDTO>();


        /// <summary>
        /// Автоматическое поле, указывает на маршрут согласование
        /// </summary>
        [DTOFieldFor(DTOFieldForType.CreationOnly)]
        public int ApprovalRouteId { get; set; }
    }
}

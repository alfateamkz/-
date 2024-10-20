using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.ApprovalRoutes;
using Alfateam.EDM.Models.Documents.Types;
using JsonKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Documents.DocumentSigning.ApproveStrategies
{

    public class DocumentApprovalRouteStrategy : DocumentApproveStrategy
    {
        public DocumentApprovalRouteStrategy()
        {

        }
        public DocumentApprovalRouteStrategy(int routeId, int stageId)
        {
            ApprovalRouteId = routeId;
            ApprovalRouteStageId = stageId;
        }
        public DocumentApprovalRouteStrategy(int routeId, int stageId, string comment)
        {
            ApprovalRouteId = routeId;
            ApprovalRouteStageId = stageId;
            Comment = comment;
        }
        public ApprovalRoute ApprovalRoute { get; set; }
        public int ApprovalRouteId { get; set; }

        /// <summary>
        /// На каком этапе маршрута согласования сейчас находится документ
        /// </summary>
        public ApprovalRouteStage? ApprovalRouteStage { get; set; }
        public int? ApprovalRouteStageId { get; set; }
    }
}

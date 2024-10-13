using Alfateam.Core;
using Alfateam.EDM.Models.ApprovalRoutes;
using Alfateam.EDM.Models.Enums.DocumentStatuses;
using Alfateam.EDM.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Documents.DocumentSigning
{
    public class DocumentApprovalMetadata : AbsModel
    {
        /// <summary>
        /// Используется, если документ пущен по маршруту согласования
        /// </summary>
        public ApprovalRoute? ApprovalRoute { get; set; }
        /// <summary>
        /// На каком этапе маршрута согласования сейчас находится документ
        /// </summary>
        public ApprovalRouteStage? ApprovalRouteStage { get; set; }




        public DocumentApprovalStatus Status { get; set; } = DocumentApprovalStatus.OnApprovalOrSigningStage;
        public DateTime LastUpdateDate { get; set; } = DateTime.UtcNow;
        public List<DocumentApprovalResult> ApprovalResults { get; set; } = new List<DocumentApprovalResult>();    
    }
}

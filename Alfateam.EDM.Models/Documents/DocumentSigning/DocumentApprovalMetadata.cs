using Alfateam.Core;
using Alfateam.EDM.Models.Abstractions;
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
        public DocumentApproveStrategy? Strategy { get; set; }
        public int? StrategyId { get; set; }

        public DocumentApprovalStatus Status { get; set; } = DocumentApprovalStatus.OnApprovalOrSigningStage;
        public DateTime LastUpdateDate { get; set; } = DateTime.UtcNow;
        public List<DocumentApprovalResult> ApprovalResults { get; set; } = new List<DocumentApprovalResult>();    
    }
}

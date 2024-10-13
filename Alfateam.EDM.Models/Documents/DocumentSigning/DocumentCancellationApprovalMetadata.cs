using Alfateam.Core;
using Alfateam.EDM.Models.Enums.DocumentStatuses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Documents.DocumentSigning
{
    public class DocumentCancellationApprovalMetadata : AbsModel
    {
        public DocumentCancellationApprovalStatus Status { get; set; } = DocumentCancellationApprovalStatus.CancellationNotRequested;
        public DateTime LastUpdateDate { get; set; } = DateTime.UtcNow;
        public List<DocumentCancellationApprovalResult> ApprovalResults { get; set; } = new List<DocumentCancellationApprovalResult>();
    }
}

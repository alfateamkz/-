using Alfateam.Core;
using Alfateam.EDM.Models.ApprovalRoutes;
using Alfateam.EDM.Models.Enums;
using Alfateam.EDM.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Documents.DocumentSigning
{
    public class DocumentCancellationApprovalResult : AbsModel
    {
        public User User { get; set; }
        public int UserId { get; set; }


        public DocumentCancellationApprovalResultType ResultType { get; set; }
        public string? Comment { get; set; }
    }
}

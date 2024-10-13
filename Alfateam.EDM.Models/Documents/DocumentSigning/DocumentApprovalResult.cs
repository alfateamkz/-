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
    public class DocumentApprovalResult : AbsModel
    {
        public User User { get; set; }
        public int UserId { get; set; }



        /// <summary>
        /// Используется, если документ пущен по маршруту согласования
        /// </summary>
        public ApprovalRouteStage? ApprovalRouteStage { get; set; }



        public DocumentApprovalResultType ResultType { get; set; } 
        public string? Comment { get; set; }
    }
}

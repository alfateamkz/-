using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Lawyer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Lawyer.Documents
{
    /// <summary>
    /// Версия документа
    /// </summary>
    public class DocumentVersion : AbsModel
    {
        public DocumentVersionStatus Status { get; set; } = DocumentVersionStatus.Review;

        public int VersionNumber { get; set; }
        public string DocumentFilepath { get; set; }


        public string? SecondSideComment { get; set; }
        public string? LawyerComment { get; set; }
    }

}

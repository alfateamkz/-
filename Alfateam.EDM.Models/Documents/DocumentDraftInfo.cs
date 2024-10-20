using Alfateam.Core;
using Alfateam.EDM.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Documents
{
    public class DocumentDraftInfo : AbsModel
    {
        public Department Department { get; set; }
        public int DepartmentId { get; set; }

        public string? Comment { get; set; }
    }
}

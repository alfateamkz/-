using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.Documents.DocumentSigning;
using Alfateam.EDM.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Documents
{
    public class DocumentVersionSideFeedback : AbsModel
    {
        public DocumentSigningSide Side { get; set; }
        public int SideId { get; set; }


        public DocumentVersionFeedbackStatus Status { get; set; }

    }

}

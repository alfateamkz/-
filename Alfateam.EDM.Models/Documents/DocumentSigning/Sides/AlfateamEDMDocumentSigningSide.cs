using Alfateam.EDM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Documents.DocumentSigning.Sides
{
    public class AlfateamEDMDocumentSigningSide : DocumentSigningSide
    {
        public EDMSubject Subject { get; set; }
        public int SubjectId { get; set; }
    }
}

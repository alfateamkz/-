using Alfateam.EDM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Core;

namespace Alfateam.EDM.Models.Documents.DocumentSigning
{
    public class DocumentSigningSideComment : AbsModel
    {
        public DocumentSigningSide Side { get; set; }
        public int SideId { get; set; }

        public string Comment { get; set; }
    }
}

using Alfateam.EDM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Documents.DocumentSigning
{
    public class DocumentSigningSideScan : AbsModel
    {
        public DocumentSigningSide Side { get; set; }
        public int SideId { get; set; }

        public string ScanPath { get; set; }
    }
}

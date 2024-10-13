using Alfateam.EDM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Documents.DocumentSigning.Results
{
    public class DocumentRejectedResult : DocumentSigningResult
    {
        public string? Comment { get; set; }
    }
}

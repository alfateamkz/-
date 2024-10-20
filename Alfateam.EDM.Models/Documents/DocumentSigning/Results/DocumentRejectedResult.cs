using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Documents.DocumentSigning.Results
{
    public class DocumentRejectedResult : DocumentSigningResult
    {
        public User? RejectedBy { get; set; }
        public int? RejectedById { get; set; }


        public string? Comment { get; set; }
    }
}

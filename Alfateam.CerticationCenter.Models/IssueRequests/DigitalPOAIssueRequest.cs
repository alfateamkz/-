using Alfateam.CertificationCenter.Models.Abstraction;
using Alfateam.CertificationCenter.Models.Files;
using Alfateam.CertificationCenter.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CertificationCenter.Models.IssueRequests
{
    public class DigitalPOAIssueRequest : IssueRequest
    {
        public DateTime StartsFrom { get; set; }
        public DateTime ValidBefore { get; set; }


        public string Powers { get; set; }


        public List<AttachedImage> PersonForDocumentImages { get; set; } = new List<AttachedImage>();
        public AttachedVideo PersonForDocumentVideo { get; set; }


        public EDSSigned DigitalSignature { get; set; }
    }
}

using Alfateam.CertificationCenter.Models.Abstraction;
using Alfateam.CertificationCenter.Models.Enums;
using Alfateam.CertificationCenter.Models.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CertificationCenter.Models.IssueRequests
{
    public class EDSIssueRequest : IssueRequest
    {
      
        public EDSFor EDSFor { get; set; }


        public List<AttachedImage> PersonalDocumentImages { get; set; } = new List<AttachedImage>();
        public AttachedVideo PersonalDocumentVideo { get; set; }
        public AttachedVideo PersonalBiometryVideo { get; set; }


        public List<AttachedImage> CompanyDocumentImages { get; set; } = new List<AttachedImage>();
        public AttachedVideo? CompanyDocumentVideo { get; set; }

        

        public int? AlfateamIDSMSVerificationId { get; set; }
        public int? AlfateamIDEmailVerificationId { get; set; }

    }
}

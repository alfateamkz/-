using Alfateam.CertificationCenter.Models.Abstraction;
using Alfateam.CertificationCenter.Models.DocumentRecognizedInfo;
using Alfateam.CertificationCenter.Models.Enums;
using Alfateam.CertificationCenter.Models.General.Biometric;
using Alfateam.CertificationCenter.Models.General.Documents;
using Alfateam.CertificationCenter.Models.RequestSuccessDocs;
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



        public SentDocument PersonalDocument { get; set; }
        public int PersonalDocumentId { get; set; }



        public SentBiometricIdentification PersonalBiometricIdentification { get; set; }
        public int PersonalBiometricIdentificationId { get; set; }


        public SentDocument? CompanyDocument { get; set; }
        public int? CompanyDocumentId { get; set; }




        public int? AlfateamIDSMSVerificationId { get; set; }
        public int? AlfateamIDEmailVerificationId { get; set; }



        public EDSIssueRequestSuccessDocs? SuccessDocs { get; set; }
        public int? SuccessDocsId { get; set; }
    }
}

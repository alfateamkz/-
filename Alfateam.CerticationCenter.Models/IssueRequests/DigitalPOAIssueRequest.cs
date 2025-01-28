using Alfateam.CertificationCenter.Models.Abstraction;
using Alfateam.CertificationCenter.Models.DocumentRecognizedInfo;
using Alfateam.CertificationCenter.Models.General;
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
    public class DigitalPOAIssueRequest : IssueRequest
    {
        public DateTime StartsFrom { get; set; }
        public DateTime ValidBefore { get; set; }


        public string Powers { get; set; }



        public SentDocument PersonForDocument { get; set; }
        public int PersonForDocumentId { get; set; }


        public SentBiometricIdentification PersonForBiometricIdentification { get; set; }
        public int PersonForBiometricIdentificationId { get; set; }



        public EDSSigned DigitalSignature { get; set; }




        public DigitalPOAIssueRequestSuccessDocs? SuccessDocs { get; set; }
    }
}

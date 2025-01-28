using Alfateam.CertificationCenter.Models.Abstraction;
using Alfateam.CertificationCenter.Models.DocumentRecognizedInfo;
using Alfateam.CertificationCenter.Models.General.Biometric;
using Alfateam.CertificationCenter.Models.General.Documents;
using Alfateam.CertificationCenter.Models.RequestSuccessDocs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CertificationCenter.Models.Verification
{
    public class PersonalVerificationRequest : VerificationRequest
    {
        public SentDocument Document { get; set; }
        public int DocumentId { get; set; }




        public SentBiometricIdentification BiometricIdentification { get; set; }
        public int BiometricIdentificationId { get; set; }




        public PersonalVerificationRequestSuccessDocs? SuccessDocs { get; set; }
    }
}

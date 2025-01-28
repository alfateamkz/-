using Alfateam.CertificationCenter.Models.DTO.Abstractions;
using Alfateam.CertificationCenter.Models.DTO.General.Biometric;
using Alfateam.CertificationCenter.Models.DTO.General.Documents;
using Alfateam.CertificationCenter.Models.General.Biometric;
using Alfateam.CertificationCenter.Models.General.Documents;
using Alfateam.CertificationCenter.Models.Verification;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CertificationCenter.Models.DTO.Verification
{
    public class PersonalVerificationRequestDTO : VerificationRequestDTO
    {
        public SentDocumentDTO Document { get; set; }
        public SentBiometricIdentificationDTO BiometricIdentification { get; set; }
    }
}

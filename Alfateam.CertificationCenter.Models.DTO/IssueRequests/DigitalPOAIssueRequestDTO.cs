using Alfateam.CertificationCenter.Models.DTO.Abstractions;
using Alfateam.CertificationCenter.Models.DTO.General;
using Alfateam.CertificationCenter.Models.DTO.General.Biometric;
using Alfateam.CertificationCenter.Models.DTO.General.Documents;
using Alfateam.CertificationCenter.Models.General;
using Alfateam.CertificationCenter.Models.General.Biometric;
using Alfateam.CertificationCenter.Models.General.Documents;

namespace Alfateam.CertificationCenter.Models.DTO.IssueRequests
{
    public class DigitalPOAIssueRequestDTO : IssueRequestDTO
    {
        public DateTime StartsFrom { get; set; }
        public DateTime ValidBefore { get; set; }


        public string Powers { get; set; }

        public SentDocumentDTO PersonForDocument { get; set; }
        public SentBiometricIdentificationDTO PersonForBiometricIdentification { get; set; }


        public EDSSignedDTO DigitalSignature { get; set; }
    }
}

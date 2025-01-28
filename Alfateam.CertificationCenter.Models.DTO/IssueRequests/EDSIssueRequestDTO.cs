using Alfateam.CertificationCenter.Models.DTO.Abstractions;
using Alfateam.CertificationCenter.Models.DTO.General.Biometric;
using Alfateam.CertificationCenter.Models.DTO.General.Documents;
using Alfateam.CertificationCenter.Models.Enums;
using Alfateam.CertificationCenter.Models.General.Biometric;
using Alfateam.CertificationCenter.Models.General.Documents;
using Alfateam.Core.Attributes.DTO;

namespace Alfateam.CertificationCenter.Models.DTO.IssueRequests
{
    public class EDSIssueRequestDTO : IssueRequestDTO
    {
        public EDSFor EDSFor { get; set; }


        public SentDocumentDTO PersonalDocument { get; set; }
        public SentBiometricIdentificationDTO PersonalBiometricIdentification { get; set; }
        public SentDocumentDTO? CompanyDocument { get; set; }



        public int? AlfateamIDSMSVerificationId { get; set; }
        public int? AlfateamIDEmailVerificationId { get; set; }
    }
}

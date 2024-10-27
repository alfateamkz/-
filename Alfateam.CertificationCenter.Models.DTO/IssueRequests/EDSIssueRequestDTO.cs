using Alfateam.CertificationCenter.Models.DTO.Abstractions;
using Alfateam.CertificationCenter.Models.DTO.Files;
using Alfateam.CertificationCenter.Models.Enums;
using Alfateam.CertificationCenter.Models.Files;
using Alfateam.Core.Attributes.DTO;

namespace Alfateam.CertificationCenter.Models.DTO.IssueRequests
{
    public class EDSIssueRequestDTO : IssueRequestDTO
    {
        public EDSFor EDSFor { get; set; }


        [ForClientOnly]
        public List<AttachedImageDTO> PersonalDocumentImages { get; set; } = new List<AttachedImageDTO>();
        [ForClientOnly]
        public AttachedVideoDTO PersonalDocumentVideo { get; set; }
        [ForClientOnly]
        public AttachedVideoDTO PersonalBiometryVideo { get; set; }


        [ForClientOnly]
        public List<AttachedImageDTO> CompanyDocumentImages { get; set; } = new List<AttachedImageDTO>();
        [ForClientOnly]
        public AttachedVideoDTO? CompanyDocumentVideo { get; set; }



        public int? AlfateamIDSMSVerificationId { get; set; }
        public int? AlfateamIDEmailVerificationId { get; set; }
    }
}

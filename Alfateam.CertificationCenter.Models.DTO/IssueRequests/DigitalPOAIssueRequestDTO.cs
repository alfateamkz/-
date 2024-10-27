using Alfateam.CertificationCenter.Models.DTO.Abstractions;
using Alfateam.CertificationCenter.Models.DTO.Files;
using Alfateam.CertificationCenter.Models.DTO.General;
using Alfateam.CertificationCenter.Models.Files;
using Alfateam.CertificationCenter.Models.General;

namespace Alfateam.CertificationCenter.Models.DTO.IssueRequests
{
    public class DigitalPOAIssueRequestDTO : IssueRequestDTO
    {
        public DateTime StartsFrom { get; set; }
        public DateTime ValidBefore { get; set; }


        public string Powers { get; set; }


        public List<AttachedImageDTO> PersonForDocumentImages { get; set; } = new List<AttachedImageDTO>();
        public AttachedVideoDTO PersonForDocumentVideo { get; set; }


        public EDSSignedDTO DigitalSignature { get; set; }
    }
}

using Alfateam.CertificationCenter.Models.Enums;
using Alfateam.CertificationCenter.Models.General;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.CertificationCenter.Models.DTO.General
{
    public class IssueRequestInfoDTO : DTOModelAbs<IssueRequestInfo>
    {
        public IssueRequestStatus Status { get; set; }
        public string? Comment { get; set; }
    }
}

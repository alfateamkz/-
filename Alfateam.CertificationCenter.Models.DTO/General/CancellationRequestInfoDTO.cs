using Alfateam.CertificationCenter.Models.Enums;
using Alfateam.CertificationCenter.Models.General;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.CertificationCenter.Models.DTO.General
{
    public class CancellationRequestInfoDTO : DTOModelAbs<CancellationRequestInfo>
    {
        public CancellationRequestStatus Status { get; set; }
        public string? Comment { get; set; }
    }
}

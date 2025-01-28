using Alfateam.AdminPanelGeneral.API.Abstractions;
using Alfateam.CertificationCenter.Models.Enums;

namespace Alfateam.AdminPanelGeneral.API.Models.Filters.CertCenter
{
    public class CertCenterVerificationRequestsSearchFilter : SearchFilter
    {
        public VerificationRequestStatus? Status { get; set; }
    }
}

using Alfateam.AdminPanelGeneral.API.Abstractions;
using Alfateam.CertificationCenter.Models.Enums;

namespace Alfateam.AdminPanelGeneral.API.Models.Filters.CertCenter
{
    public class CertCenterIssueRequestsSearchFilter : SearchFilter
    {
        public IssueRequestStatus? Status { get; set; }
    }
}

using Alfateam.AdminPanelGeneral.API.Abstractions;
using Alfateam.SharedModels.Abstractions;

namespace Alfateam.AdminPanelGeneral.API.Models.Filters.CertCenter
{
    public class CertCenterPOASearchFilter : SearchFilter
    {
        public string? AlfateamId { get; set; }


        public DateFilterModel? IssuedAtPeriod { get; set; }
        public DateFilterModel? ValidBeforePeriod { get; set; }
        public DateFilterModel? RevokedAtPeriod { get; set; }
    }
}

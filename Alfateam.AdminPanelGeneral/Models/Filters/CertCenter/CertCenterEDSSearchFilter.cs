using Alfateam.AdminPanelGeneral.API.Abstractions;
using Alfateam.SharedModels.Abstractions;
using Alfateam.SharedModels.Filters.Dates.Props;

namespace Alfateam.AdminPanelGeneral.API.Models.Filters.CertCenter
{
    public class CertCenterEDSSearchFilter : SearchFilter
    {
        public string? AlfateamId { get; set; }


        public DateFilterModel? ValidFromPeriod { get; set; }
        public DateFilterModel? ValidBeforePeriod { get; set; }
        public DateFilterModel? RevokedAtPeriod { get; set; }
    }
}

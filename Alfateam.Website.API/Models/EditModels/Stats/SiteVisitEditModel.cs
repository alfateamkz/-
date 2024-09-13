using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Stats;

namespace Alfateam.Website.API.Models.EditModels.Stats
{
    public class SiteVisitEditModel : EditModel<SiteVisit>
    {
        public string URL { get; set; }
        public string UserAgent { get; set; }
        public string? IP { get; set; }
        public int? CountryId { get; set; }




        public string Fingerprint { get; set; }
        public int? VisitedById { get; set; }
    }
}

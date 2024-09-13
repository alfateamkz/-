using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Stats;

namespace Alfateam.Website.API.Models.CreateModels.Stats
{
    public class SiteVisitCreateModel : CreateModel<SiteVisit>
    {
        public string URL { get; set; }
        public string UserAgent { get; set; }
        public string? IP { get; set; }
        public int? CountryId { get; set; }




        public string Fingerprint { get; set; }
        public int? VisitedById { get; set; }
    }
}

using Alfateam2._0.Models.General;

namespace Alfateam.Website.API.Models.Filters.Admin
{
    public class SiteVisitFilter
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }


        public int Offset { get; set; }
        public int Count { get; set; } = 20;


        public string? IP { get; set; }
        public int? CountryId { get; set; }

        public string? Fingerprint { get; set; }
    }
}

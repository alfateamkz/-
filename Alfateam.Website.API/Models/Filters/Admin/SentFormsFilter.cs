using Alfateam2._0.Models.Enums;

namespace Alfateam.Website.API.Models.Filters.Admin
{
    public class SentFormsFilter
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }


        public int Offset { get; set; }
        public int Count { get; set; } = 20;


        public string? IP { get; set; }
        public string? Fingerprint { get; set; }
        public SentFromWebsiteFormHandlingStatus? Status { get; set; }
    }
}

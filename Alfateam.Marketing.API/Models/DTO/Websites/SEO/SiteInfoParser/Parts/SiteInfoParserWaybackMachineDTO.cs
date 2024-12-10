using Alfateam.Marketing.Models.Websites.SEO.SiteInfoParser.Parts;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Websites.SEO.SiteInfoParser.Parts
{
    public class SiteInfoParserWaybackMachineDTO : DTOModelAbs<SiteInfoParserWaybackMachine>
    {
        public int IndexedURLsCount { get; set; }

        public bool Indexation { get; set; }
        public DateTime? FirstCrawled { get; set; }
        public DateTime? LastCrawled { get; set; }
        public bool? LastCapturedURL { get; set; }
    }
}

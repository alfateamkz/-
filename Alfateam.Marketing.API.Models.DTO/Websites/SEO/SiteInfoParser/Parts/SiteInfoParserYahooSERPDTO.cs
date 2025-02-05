using Alfateam.Marketing.Models.Websites.SEO.SiteInfoParser.Parts;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Websites.SEO.SiteInfoParser.Parts
{
    public class SiteInfoParserYahooSERPDTO : DTOModelAbs<SiteInfoParserYahooSERP>
    {
        public int IndexedURLsCount { get; set; }
        public bool Indexation { get; set; }
        public bool Splice { get; set; }
        public string? URLOfMirror { get; set; }


        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}

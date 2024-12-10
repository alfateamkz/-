using Alfateam.Marketing.Models.Websites.SEO.SiteInfoParser.Parts;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Websites.SEO.SiteInfoParser.Parts
{
    public class SiteInfoParserGoogleSERPDTO : DTOModelAbs<SiteInfoParserGoogleSERP>
    {
        public int IndexedURLsCount { get; set; }
        public bool Indexation { get; set; }
    }
}

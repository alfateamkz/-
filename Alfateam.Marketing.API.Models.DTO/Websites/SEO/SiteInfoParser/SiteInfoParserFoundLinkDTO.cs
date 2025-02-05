using Alfateam.Marketing.Models.Enums.SEO;
using Alfateam.Marketing.Models.Websites.SEO.SiteInfoParser;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Websites.SEO.SiteInfoParser
{
    public class SiteInfoParserFoundLinkDTO : DTOModelAbs<SiteInfoParserFoundLink>
    {
        public string URL { get; set; }
        public SiteInfoParserFoundLinkType Type { get; set; }
    }
}

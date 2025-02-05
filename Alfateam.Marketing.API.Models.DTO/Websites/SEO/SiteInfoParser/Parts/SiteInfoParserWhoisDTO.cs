using Alfateam.Marketing.Models.Websites.SEO.SiteInfoParser.Parts;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Websites.SEO.SiteInfoParser.Parts
{
    public class SiteInfoParserWhoisDTO : DTOModelAbs<SiteInfoParserWhois>
    {
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public string RootDomain { get; set; }
    }
}

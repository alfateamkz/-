using Alfateam.Marketing.Models.Websites.SEO.SiteInfoParser.Parts;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Websites.SEO.SiteInfoParser.Parts
{
    public class SiteInfoParserDNSDTO : DTOModelAbs<SiteInfoParserDNS>
    {
        public string IP { get; set; }
        public string CountryCode { get; set; }
    }
}

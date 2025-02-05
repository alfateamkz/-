using Alfateam.Marketing.Models.Websites.SEO.SiteInfoParser;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Websites.SEO.SiteInfoParser
{
    public class SiteInfoParserURLResponseDTO : DTOModelAbs<SiteInfoParserURLResponse>
    {
        public int Code { get; set; }
        public string? Content { get; set; }
    }
}

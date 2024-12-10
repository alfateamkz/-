using Alfateam.Marketing.Models.Websites.SEO.Reports.WebsiteSEOAudit;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Websites.SEO.Reports.WebsiteSEOAudit
{
    public class WebsiteSEOAuditURLResponseDTO : DTOModelAbs<WebsiteSEOAuditURLResponse>
    {
        public int Code { get; set; }
        public string? Content { get; set; }
    }
}

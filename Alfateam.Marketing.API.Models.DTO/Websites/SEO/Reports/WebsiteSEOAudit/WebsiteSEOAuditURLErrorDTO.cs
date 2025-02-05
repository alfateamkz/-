using Alfateam.Marketing.Models.Enums.SEO.Errors;
using Alfateam.Marketing.Models.Websites.SEO.Reports.WebsiteSEOAudit;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Websites.SEO.Reports.WebsiteSEOAudit
{
    public class WebsiteSEOAuditURLErrorDTO : DTOModelAbs<WebsiteSEOAuditURLError>
    {
        public SEOWebsiteErrorType Type { get; set; }
        public string? Description { get; set; }
    }
}

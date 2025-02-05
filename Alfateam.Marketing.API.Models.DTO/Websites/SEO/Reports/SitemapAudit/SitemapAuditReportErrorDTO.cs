using Alfateam.Marketing.Models.Enums.SEO.Errors;
using Alfateam.Marketing.Models.Websites.SEO.Reports.SitemapAudit;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Websites.SEO.Reports.SitemapAudit
{
    public class SitemapAuditReportErrorDTO : DTOModelAbs<SitemapAuditReportError>
    {
        public SEOSitemapErrorType Type { get; set; }
        public string? Description { get; set; }
    }
}

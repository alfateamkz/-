using Alfateam.Marketing.Models.Websites.SEO.Reports.SitemapAudit;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Websites.SEO.Reports.SitemapAudit
{
    public class SitemapAuditReportDTO : DTOModelAbs<SitemapAuditReport>
    {
        public string URL { get; set; }
        public List<SitemapAuditReportErrorDTO> Errors { get; set; } = new List<SitemapAuditReportErrorDTO>();
    }
}

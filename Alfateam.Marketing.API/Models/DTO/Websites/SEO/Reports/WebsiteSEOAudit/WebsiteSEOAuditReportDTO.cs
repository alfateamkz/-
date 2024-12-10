using Alfateam.Marketing.Models.Websites.SEO.Reports.WebsiteSEOAudit;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Websites.SEO.Reports.WebsiteSEOAudit
{
    public class WebsiteSEOAuditReportDTO : DTOModelAbs<WebsiteSEOAuditReport>
    {
        public List<WebsiteSEOAuditURLDTO> CheckedURLs { get; set; } = new List<WebsiteSEOAuditURLDTO>();
        public List<WebsiteSEOAuditSkippedURLDTO> SkippedURLs { get; set; } = new List<WebsiteSEOAuditSkippedURLDTO>();
    }
}

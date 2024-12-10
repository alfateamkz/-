using Alfateam.Marketing.Models.Websites.SEO.Reports.WebsiteSEOAudit;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Websites.SEO.Reports.WebsiteSEOAudit
{
    public class WebsiteSEOAuditSkippedURLDTO : DTOModelAbs<WebsiteSEOAuditSkippedURL>
    {
        public string URL { get; set; }
        public string Reason { get; set; }
    }
}

using Alfateam.Marketing.Models.Websites.SEO.Reports.WebsiteSEOAudit;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Websites.SEO.Reports.WebsiteSEOAudit
{
    public class WebsiteSEOAuditURLDTO : DTOModelAbs<WebsiteSEOAuditURL>
    {
        public string URL { get; set; }
        public List<WebsiteSEOAuditURLResponseDTO> Responses { get; set; } = new List<WebsiteSEOAuditURLResponseDTO>();
        public string ContentType { get; set; }



        public List<WebsiteSEOAuditURLErrorDTO> Errors { get; set; } = new List<WebsiteSEOAuditURLErrorDTO>();
        public int ServerResponseTimeInMs { get; set; }
        public double? InternalPageRank { get; set; }
    }
}

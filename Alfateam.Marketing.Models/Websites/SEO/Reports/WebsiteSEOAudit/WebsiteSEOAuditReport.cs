using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Websites.SEO.Reports.WebsiteSEOAudit
{
    public class WebsiteSEOAuditReport : AbsModel
    {
        public List<WebsiteSEOAuditURL> CheckedURLs { get; set; } = new List<WebsiteSEOAuditURL>();
        public List<WebsiteSEOAuditSkippedURL> SkippedURLs { get; set; } = new List<WebsiteSEOAuditSkippedURL>();
    }
}

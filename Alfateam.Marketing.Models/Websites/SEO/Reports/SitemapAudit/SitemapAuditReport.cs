using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Websites.SEO.Reports.SitemapAudit
{
    public class SitemapAuditReport : AbsModel
    {
        public string URL { get; set; }
        public List<SitemapAuditReportError> Errors { get; set; } = new List<SitemapAuditReportError>();
    }
}

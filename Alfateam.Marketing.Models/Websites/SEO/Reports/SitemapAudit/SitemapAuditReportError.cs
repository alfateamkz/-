using Alfateam.Core;
using Alfateam.Marketing.Models.Enums.SEO.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Websites.SEO.Reports.SitemapAudit
{
    public class SitemapAuditReportError : AbsModel
    {
        public SEOSitemapErrorType Type { get; set; }
        public string? Description { get; set; }
    }
}

using Alfateam.Core;
using Alfateam.Marketing.Models.Enums.SEO.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Websites.SEO.Reports.WebsiteSEOAudit
{
    public class WebsiteSEOAuditURLError : AbsModel
    {
        public SEOWebsiteErrorType Type { get; set; }
        public string? Description { get; set; }
    }
}

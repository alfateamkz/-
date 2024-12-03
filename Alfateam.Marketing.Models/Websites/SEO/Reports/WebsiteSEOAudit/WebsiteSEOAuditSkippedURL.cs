using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Websites.SEO.Reports.WebsiteSEOAudit
{
    public class WebsiteSEOAuditSkippedURL : AbsModel
    {
        public string URL { get; set; }
        public string Reason { get; set; }
    }
}

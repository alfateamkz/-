using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Websites.SEO.Reports.WebsiteSEOAudit
{
    public class WebsiteSEOAuditURL : AbsModel
    {
        public string URL { get; set; }
        public List<WebsiteSEOAuditURLResponse> Responses { get; set; } = new List<WebsiteSEOAuditURLResponse>();
        public string ContentType { get; set; }



        public List<WebsiteSEOAuditURLError> Errors { get; set; } = new List<WebsiteSEOAuditURLError>();
        public int ServerResponseTimeInMs { get; set; }
        public double? InternalPageRank { get; set; }


    }
}

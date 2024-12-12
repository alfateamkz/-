using Alfateam.Marketing.Models.Websites.SEO;
using Alfateam.Marketing.Models.Websites.SEO.Reports.SitemapAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.SEO.Lib
{
    public class WebsiteSEOAuditTool
    {
        protected readonly SEOToolSettings Settings;
        public WebsiteSEOAuditTool(SEOToolSettings settings)
        {
            Settings = settings;
        }




        public SitemapAuditReport AuditSitemap(string url)
        {
            throw new NotImplementedException();    
        }
        public SitemapAuditReport AuditWebsite(string url)
        {
            throw new NotImplementedException();
        }
    }
}

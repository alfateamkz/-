using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Enums.Sitemaps
{
    public enum ApiSitemapSource
    {
        [Description("ROBOTS_TXT")]
        RobotsTXT = 1,
        [Description("WEBMASTER")]
        Webmaster = 2,
        [Description("INDEX_SITEMAP")]
        IndexSitemap = 3
    }
}

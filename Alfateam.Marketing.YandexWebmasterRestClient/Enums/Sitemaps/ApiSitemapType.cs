using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Enums.Sitemaps
{
    public enum ApiSitemapType
    {
        [Description("SITEMAP")]
        Sitemap = 1,
        [Description("INDEX_SITEMAP")]
        IndexSitemap = 2,
    }
}

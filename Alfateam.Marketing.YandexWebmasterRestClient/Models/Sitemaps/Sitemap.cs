using Alfateam.Marketing.YandexWebmasterRestClient.Enums.Sitemaps;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.Sitemaps
{
    public class Sitemap
    {
        [JsonProperty("sitemap_id")]
        public string SitemapId { get; set; }

        [JsonProperty("sitemap_url")]
        public string SitemapURL { get; set; }

        [JsonProperty("last_access_date")]
        public DateTime LastAccessDate { get; set; }

        [JsonProperty("errors_count")]
        public int ErrorsCount { get; set; }

        [JsonProperty("urls_count")]
        public long URLsCount { get; set; }

        [JsonProperty("children_count")]
        public int ChildrenCount { get; set; }

        [JsonProperty("sources")]
        public List<ApiSitemapSource> Sources { get; set; } = new List<ApiSitemapSource>();

        [JsonProperty("sitemap_type")]
        public ApiSitemapType SitemapType { get; set; }
    }
}

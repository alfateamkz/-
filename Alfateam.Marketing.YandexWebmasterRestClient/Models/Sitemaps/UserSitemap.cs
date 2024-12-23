using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.Sitemaps
{
    public class UserSitemap
    {
        [JsonProperty("sitemap_id")]
        public string SitemapId { get; set; }

        [JsonProperty("sitemap_url")]
        public string SitemapURL { get; set; }

        [JsonProperty("added_date")]
        public DateTime AddedDate { get; set; }
    }
}

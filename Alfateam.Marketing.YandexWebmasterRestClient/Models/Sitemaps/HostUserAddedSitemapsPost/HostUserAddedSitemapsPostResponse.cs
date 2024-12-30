using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.Sitemaps.HostUserAddedSitemapsPost
{
    public class HostUserAddedSitemapsPostResponse
    {
        [JsonProperty("sitemap_id")]
        public string SitemapId { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.Sitemaps.HostSitemapsGet
{
    public class HostSitemapsGetResponse
    {
        [JsonProperty("sitemaps")]
        public List<Sitemap> Sitemaps { get; set; } = new List<Sitemap>();
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.Sitemaps.HostUserAddedSitemapsGet
{
    public class HostUserAddedSitemapsGetResponse
    {
        [JsonProperty("sitemaps")]
        public List<UserSitemap> Sitemaps { get; set; } = new List<UserSitemap>();

        [JsonProperty("count")]
        public int Count { get; set; }
    }
}

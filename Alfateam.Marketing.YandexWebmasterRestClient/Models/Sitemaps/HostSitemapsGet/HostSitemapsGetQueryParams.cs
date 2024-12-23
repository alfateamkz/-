using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.Sitemaps.HostSitemapsGet
{
    public class HostSitemapsGetQueryParams
    {
        [JsonProperty("parent_id")]
        public string ParentId { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("from")]
        public DateTime From { get; set; }
    }
}

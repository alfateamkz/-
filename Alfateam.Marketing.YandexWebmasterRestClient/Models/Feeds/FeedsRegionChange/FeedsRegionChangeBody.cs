using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.Feeds.FeedsRegionChange
{
    public class FeedsRegionChangeBody
    {
        [JsonProperty("url")]
        public string URL { get; set; }

        [JsonProperty("newRegionIds")]
        public List<int> NewRegionIds { get; set; } = new List<int>();
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AdGroups.Get
{
    public class SmartAdGroupGet
    {
        [JsonProperty("FeedId")]
        public long FeedId { get; set; }

        [JsonProperty("AdTitleSource")]
        public string AdTitleSource { get; set; }

        [JsonProperty("AdBodySource")]
        public string AdBodySource { get; set; }
    }
}

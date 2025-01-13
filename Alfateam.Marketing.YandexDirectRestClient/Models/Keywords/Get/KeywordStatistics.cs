using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Keywords.Get
{
    public class KeywordStatistics
    {
        [JsonProperty("Clicks")]
        public long Clicks { get; set; }

        [JsonProperty("Impressions")]
        public long Impressions { get; set; }
    }
}

using Alfateam.Marketing.YandexWebmasterRestClient.Enums.Verification;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.SiteQuality
{
    public class SQIHistoryItem
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }
    }
}

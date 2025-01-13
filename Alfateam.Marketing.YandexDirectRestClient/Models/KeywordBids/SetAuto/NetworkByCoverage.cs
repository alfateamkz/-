using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.KeywordBids.SetAuto
{
    public class NetworkByCoverage
    {
        [JsonProperty("TargetCoverage")]
        public int TargetCoverage { get; set; }

        [JsonProperty("IncreasePercent")]
        public int IncreasePercent { get; set; }

        [JsonProperty("BidCeiling")]
        public long BidCeiling { get; set; }
    }
}

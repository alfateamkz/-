using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.KeywordBids.SetAuto
{
    public class BiddingRule
    {
        [JsonProperty("SearchByTrafficVolume")]
        public SearchByTrafficVolume SearchByTrafficVolume { get; set; }

        [JsonProperty("NetworkByCoverage")]
        public NetworkByCoverage NetworkByCoverage { get; set; }
    }
}

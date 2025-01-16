using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.BusinessRelated.WhatsAppBusinessAccounts
{
    public class WABAAnalyticsDataPoint
    {
        [JsonProperty("delivered")]
        public int Delivered { get; set; }

        [JsonProperty("end")]
        public int End { get; set; }

        [JsonProperty("received")]
        public int Received { get; set; }

        [JsonProperty("sent")]
        public int Sent { get; set; }

        [JsonProperty("start")]
        public int Start { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.Recrawl.HostRecrawlQuotaGet
{
    public class HostRecrawlQuotaGetResponse
    {
        [JsonProperty("daily_quota")]
        public int DailyQuota { get; set; }

        [JsonProperty("quota_remainder")]
        public int QuotaRemainder { get; set; }
    }
}

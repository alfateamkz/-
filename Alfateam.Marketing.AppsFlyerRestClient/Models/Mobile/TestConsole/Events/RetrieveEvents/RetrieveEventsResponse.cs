using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Mobile.TestConsole.Events.RetrieveEvents
{
    public class RetrieveEventsResponse
    {
        [JsonProperty("app_id")]
        public string AppId { get; set; }

        [JsonProperty("device_id")]
        public string DeviceId { get; set; }

        [JsonProperty("max_results")]
        public int MaxResults { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("data")]
        public List<RetrieveEventsResponseData> Data { get; set; } = new List<RetrieveEventsResponseData>();

        [JsonProperty("response_time")]
        public int ResponseTime { get; set; }
    }
}

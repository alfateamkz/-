using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.RawDataReport.RawDataPull
{
    public class RawDataPullGeneralEventsQueryParams : RawDataPullGeneralQueryParams
    {
        [JsonProperty("event_name")]
        public List<string> EventName { get; set; } = new List<string>();
    }
}

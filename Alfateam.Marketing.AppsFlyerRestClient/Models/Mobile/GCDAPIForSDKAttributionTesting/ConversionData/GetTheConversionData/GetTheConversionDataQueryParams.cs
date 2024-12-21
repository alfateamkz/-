using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Mobile.GCDAPIForSDKAttributionTesting.ConversionData.GetTheConversionData
{
    public class GetTheConversionDataQueryParams
    {
        [JsonProperty("devkey")]
        public string DevKey { get; set; }

        [JsonProperty("device_id")]
        public string DeviceId { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Measurements.PreloadC2SMeasurement.DownloadEvents
{
    public class PreloadC2SDownloadEventResponse
    {
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }
    }
}

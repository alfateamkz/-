using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Push.PostSendBatch
{
    public class PushBatchRequestBatchMessagesiOS
    {
        [JsonProperty("silent")]
        public bool Silent { get; set; }

        [JsonProperty("content")]
        public PushBatchRequestBatchMessagesiOSContent Content { get; set; }

        [JsonProperty("open_action")]
        public PushBatchRequestBatchMessagesiOSContentOpenAction OpenAction { get; set; }
    }
}

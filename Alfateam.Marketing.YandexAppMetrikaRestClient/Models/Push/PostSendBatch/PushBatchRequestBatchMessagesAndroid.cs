using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Push.PostSendBatch
{
    public class PushBatchRequestBatchMessagesAndroid
    {
        [JsonProperty("silent")]
        public bool Silent { get; set; }

        [JsonProperty("content")]
        public PushBatchRequestBatchMessagesAndroidContent Content { get; set; }

        [JsonProperty("open_action")]
        public PushBatchRequestBatchMessagesAndroidOpenAction OpenAction { get; set; }
    }
}

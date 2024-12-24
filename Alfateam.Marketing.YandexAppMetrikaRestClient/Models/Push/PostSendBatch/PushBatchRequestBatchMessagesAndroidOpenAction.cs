using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Push.PostSendBatch
{
    public class PushBatchRequestBatchMessagesAndroidOpenAction
    {
        [JsonProperty("deeplink")]
        public string Deeplink { get; set; }
    }
}

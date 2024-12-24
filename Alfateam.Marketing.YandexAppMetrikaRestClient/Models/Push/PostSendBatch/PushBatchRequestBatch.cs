using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Push.PostSendBatch
{
    public class PushBatchRequestBatch
    {
        [JsonProperty("messages")]
        public PushBatchRequestBatchMessages Messages { get; set; }
    }
}

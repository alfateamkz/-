using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Push.PostSendBatch
{
    public class PostSendBatchBody
    {
        [JsonProperty("push_batch_request")]
        public PushBatchRequest PushBatchRequest { get; set; }
    }
}

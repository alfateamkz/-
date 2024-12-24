using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Push.PostSendBatch
{
    public class PushBatchRequest
    {
        [JsonProperty("group_id")]
        public int GroupId { get; set; }

        [JsonProperty("client_transfer_id")]
        public long ClientTransferId { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("batch")]
        public List<PushBatchRequestBatch> Batch { get; set; } = new List<PushBatchRequestBatch>();
    }
}

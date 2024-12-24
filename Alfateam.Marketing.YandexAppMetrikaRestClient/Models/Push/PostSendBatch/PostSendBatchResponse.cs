using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Push.PostSendBatch
{
    public class PostSendBatchResponse
    {
        [JsonProperty("transfer_id")]
        public int TransferId { get; set; }

        [JsonProperty("client_transfer_id")]
        public long ClientTransferId { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Push.PostSendBatch
{
    public class PushBatchRequestBatchMessagesiOSContentAttachment
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("file_url")]
        public string FileURL { get; set; }

        [JsonProperty("file_type")]
        public string FileType { get; set; }
    }
}

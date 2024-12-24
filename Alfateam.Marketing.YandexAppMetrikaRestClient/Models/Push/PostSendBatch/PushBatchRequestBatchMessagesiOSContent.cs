using Alfateam.Marketing.YandexAppMetrikaRestClient.Enums.Push;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Push.PostSendBatch
{
    public class PushBatchRequestBatchMessagesiOSContent
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("badge")]
        public int Badge { get; set; }

        [JsonProperty("sound")]
        public PushBatchRequestBatchMessagesiOSContentSound Sound { get; set; }

        [JsonProperty("thread_id")]
        public string ThreadId { get; set; }

        [JsonProperty("category")]
        public string Сategory { get; set; }

        [JsonProperty("mutable_content")]
        public int MutableContent { get; set; }

        [JsonProperty("expiration")]
        public int Expiration { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("collapse_id")]
        public string CollapseId { get; set; }

        [JsonProperty("attachments")]
        public List<PushBatchRequestBatchMessagesiOSContentAttachment> Attachments { get; set; } = new List<PushBatchRequestBatchMessagesiOSContentAttachment>();
    }
}

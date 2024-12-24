using Alfateam.Marketing.YandexAppMetrikaRestClient.Enums.Push;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Push
{
    public class PushTransfer
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("group_id")]
        public int GroupId { get; set; }

        [JsonProperty("status")]
        public PushTransferStatus Status { get; set; }

        [JsonProperty("errors")]
        public List<string> Errors { get; set; } = new List<string>();

        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("creation_date")]
        public DateTime CreationDate { get; set; }

        [JsonProperty("client_transfer_id")]
        public int ClientTransferId { get; set; }
    }
}

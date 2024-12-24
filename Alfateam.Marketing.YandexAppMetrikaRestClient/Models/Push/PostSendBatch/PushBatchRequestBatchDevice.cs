using Alfateam.Marketing.YandexAppMetrikaRestClient.Enums.Push;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Push.PostSendBatch
{
    public class PushBatchRequestBatchDevice
    {
        [JsonProperty("id_type")]
        public PushBatchRequestBatchDeviceIdType IdType { get; set; }

        [JsonProperty("id_values")]
        public List<int> IdValues { get; set; } = new List<int>();
    }
}

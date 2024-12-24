using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.Feeds.FeedsAddStart
{
    public class FeedsAddStartResponse
    {
        [JsonProperty("requestId")]
        public string RequestId { get; set; }
    }
}

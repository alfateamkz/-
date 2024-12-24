using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.Feeds.FeedsBatchDelete
{
    public class FeedsBatchDeleteBody
    {
        [JsonProperty("urls")]
        public List<string> URLs { get; set; } = new List<string>();
    }
}

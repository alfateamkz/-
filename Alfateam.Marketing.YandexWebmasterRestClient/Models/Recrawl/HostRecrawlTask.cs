using Alfateam.Marketing.YandexWebmasterRestClient.Enums.Recrawl;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.Recrawl
{
    public class HostRecrawlTask
    {
        [JsonProperty("task_id")]
        public string TaskId { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }

        [JsonProperty("added_time")]
        public DateTime AddedTime { get; set; }

        [JsonProperty("state")]
        public HostRecrawlTaskStatus State { get; set; }
    }
}

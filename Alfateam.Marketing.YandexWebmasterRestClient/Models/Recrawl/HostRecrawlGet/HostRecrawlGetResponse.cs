using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.Recrawl.HostRecrawlGet
{
    public class HostRecrawlGetResponse
    {
        [JsonProperty("tasks")]
        public List<HostRecrawlTask> Tasks { get; set; } = new List<HostRecrawlTask>();
    }
}

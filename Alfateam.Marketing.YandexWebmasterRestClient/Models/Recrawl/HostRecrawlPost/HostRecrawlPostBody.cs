using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.Recrawl.HostRecrawlPost
{
    public class HostRecrawlPostBody
    {
        [JsonProperty("url")]
        public string URL { get; set; }
    }
}

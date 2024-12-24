using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.Feeds
{
    public class WithFeedBody
    {
        [JsonProperty("feed")]
        public Feed Feed { get; set; }
    }
}

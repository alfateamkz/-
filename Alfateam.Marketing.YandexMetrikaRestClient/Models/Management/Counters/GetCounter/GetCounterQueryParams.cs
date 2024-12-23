using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Counters.GetCounter
{
    public class GetCounterQueryParams
    {
        [JsonProperty("callback")]
        public string Callback { get; set; }

        [JsonProperty("field")]
        public string Field { get; set; }
    }
}

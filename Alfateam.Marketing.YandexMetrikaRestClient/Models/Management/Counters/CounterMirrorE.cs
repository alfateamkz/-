using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Counters
{
    public class CounterMirrorE
    {
        [JsonProperty("site")]
        public string Site { get; set; }
    }
}

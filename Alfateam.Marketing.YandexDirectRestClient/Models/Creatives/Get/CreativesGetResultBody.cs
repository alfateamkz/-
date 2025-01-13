using Alfateam.Marketing.YandexDirectRestClient.Models.Creatives.Add;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Creatives.Get
{
    public class CreativesGetResultBody
    {
        [JsonProperty("Creatives")]
        public List<CreativeGetItem> Creatives { get; set; } = new List<CreativeGetItem>();

        [JsonProperty("LimitedBy")]
        public long LimitedBy { get; set; }
    }
}

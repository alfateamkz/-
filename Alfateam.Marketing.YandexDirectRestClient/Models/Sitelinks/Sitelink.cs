using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Sitelinks
{
    public class Sitelink
    {
        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Href")]
        public string Href { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("TurboPageId")]
        public long TurboPageId { get; set; }
    }
}

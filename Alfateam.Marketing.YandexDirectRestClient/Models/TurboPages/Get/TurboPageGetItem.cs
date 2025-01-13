using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.TurboPages.Get
{
    public class TurboPageGetItem
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Href")]
        public string Href { get; set; }

        [JsonProperty("PreviewHref")]
        public string PreviewHref { get; set; }

        [JsonProperty("TurboSiteHref")]
        public string TurboSiteHref { get; set; }

        [JsonProperty("BoundWithHref")]
        public string BoundWithHref { get; set; }
    }
}

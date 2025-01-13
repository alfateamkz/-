using Alfateam.Marketing.YandexDirectRestClient.Models.DynamicTextAdTargets.Add;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.DynamicTextAdTargets.Get
{
    public class DynamicTextAdTargetsGetResultBody
    {
        [JsonProperty("Webpages")]
        public List<WebpageGetItem> Webpages { get; set; } = new List<WebpageGetItem>();
    }
}

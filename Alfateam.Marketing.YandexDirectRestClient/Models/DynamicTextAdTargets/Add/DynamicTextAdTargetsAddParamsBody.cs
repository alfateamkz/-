using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.DynamicTextAdTargets.Add
{
    public class DynamicTextAdTargetsAddParamsBody
    {
        [JsonProperty("Webpages")]
        public List<WebpageAddItem> Webpages { get; set; } = new List<WebpageAddItem>();
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AdExtensions.Add
{
    public class AdExtensionsAddParamsBody
    {
        [JsonProperty("AdExtensions")]
        public List<AdExtensionAddItem> AdExtensions { get; set; } = new List<AdExtensionAddItem>();
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Ads.Add
{
    public class AdsAddParamsBody
    {
        [JsonProperty("Ads")]
        public List<AdAddItem> Ads { get; set; } = new List<AdAddItem>();
    }
}

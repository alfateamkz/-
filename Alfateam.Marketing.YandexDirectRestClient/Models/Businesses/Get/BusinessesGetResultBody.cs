using Alfateam.Marketing.YandexDirectRestClient.Enums.Businesses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Businesses.Get
{
    public class BusinessesGetResultBody
    {
        [JsonProperty("Businesses")]
        public List<BusinessGetItem> Businesses { get; set; } = new List<BusinessGetItem>();

        [JsonProperty("LimitedBy")]
        public long LimitedBy { get; set; }
    }
}

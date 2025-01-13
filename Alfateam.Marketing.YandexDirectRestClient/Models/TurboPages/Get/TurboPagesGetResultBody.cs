using Alfateam.Marketing.YandexDirectRestClient.Enums.TurboPages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.TurboPages.Get
{
    public class TurboPagesGetResultBody
    {
        [JsonProperty("TurboPages")]
        public List<TurboPageGetItem> TurboPages { get; set; } = new List<TurboPageGetItem>();

        [JsonProperty("LimitedBy")]
        public long LimitedBy { get; set; }
    }
}

using Alfateam.Marketing.YandexWebmasterRestClient.Enums.InternalLinks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.InternalLinks.HostLinksInternalHistory
{
    public class HostLinksInternalHistoryResponse
    {
        [JsonProperty("indicators")]
        public Dictionary<ApiInternalLinksBrokenIndicator, HostLinksInternalHistoryIndicatorValue> Indicators { get; set; } = new Dictionary<ApiInternalLinksBrokenIndicator, HostLinksInternalHistoryIndicatorValue>();
    }
}

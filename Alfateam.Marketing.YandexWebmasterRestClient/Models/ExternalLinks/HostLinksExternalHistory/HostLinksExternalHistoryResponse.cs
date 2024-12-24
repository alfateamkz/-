using Alfateam.Marketing.YandexWebmasterRestClient.Enums.ExternalLinks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.ExternalLinks.HostLinksExternalHistory
{
    public class HostLinksExternalHistoryResponse
    {
        [JsonProperty("indicators")]
        public Dictionary<APIExternalLinksIndicator, HostLinksExternalHistoryIndicatorValue> Indicators { get; set; } = new Dictionary<APIExternalLinksIndicator, HostLinksExternalHistoryIndicatorValue>();
    }
}

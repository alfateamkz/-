using Alfateam.Marketing.YandexWebmasterRestClient.Enums.ExternalLinks;
using Alfateam.Marketing.YandexWebmasterRestClient.Enums.InternalLinks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.ExternalLinks.HostLinksExternalHistory
{
    public class HostLinksExternalHistoryQueryParams
    {
        [JsonProperty("indicator")]
        public APIExternalLinksIndicator Indicator { get; set; }
    }
}

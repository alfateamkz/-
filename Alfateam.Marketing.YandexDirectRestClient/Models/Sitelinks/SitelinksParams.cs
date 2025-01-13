using Alfateam.Marketing.YandexDirectRestClient.Enums.Sitelinks;
using Alfateam.Marketing.YandexDirectRestClient.Enums.SmartAdTargets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Sitelinks
{
    public class SitelinksParams<T>
    {
        [JsonProperty("method")]
        public SitelinksMethod Method { get; set; }

        [JsonProperty("params")]
        public T Params { get; set; }
    }
}

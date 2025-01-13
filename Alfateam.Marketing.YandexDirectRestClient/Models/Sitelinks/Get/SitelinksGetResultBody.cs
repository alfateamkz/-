using Alfateam.Marketing.YandexDirectRestClient.Models.Sitelinks.Add;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Sitelinks.Get
{
    public class SitelinksGetResultBody
    {
        [JsonProperty("SitelinksSets")]
        public List<SitelinksSetGetItem> SitelinksSets { get; set; } = new List<SitelinksSetGetItem>();

        [JsonProperty("LimitedBy")]
        public long LimitedBy { get; set; }
    }
}

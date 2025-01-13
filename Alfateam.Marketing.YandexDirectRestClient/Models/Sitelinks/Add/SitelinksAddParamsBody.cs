using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Sitelinks.Add
{
    public class SitelinksAddParamsBody
    {
        [JsonProperty("SitelinksSets")]
        public List<SitelinksSetAddItem> SitelinksSets { get; set; } = new List<SitelinksSetAddItem>();
    }
}

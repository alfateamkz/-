using Alfateam.Marketing.YandexDirectRestClient.Enums.Sitelinks;
using Alfateam.Marketing.YandexDirectRestClient.Models.Sitelinks.Add;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Sitelinks.Get
{
    public class SitelinksGetParamsBody
    {
        [JsonProperty("SelectionCriteria")]
        public IdsCriteria SelectionCriteria { get; set; }

        [JsonProperty("FieldNames")]
        public List<SitelinksSetFieldEnum> FieldNames { get; set; } = Enum.GetValues<SitelinksSetFieldEnum>().ToList();

        [JsonProperty("SitelinkFieldNames")]
        public List<SitelinkFieldEnum> SitelinkFieldNames { get; set; } = Enum.GetValues<SitelinkFieldEnum>().ToList();

        [JsonProperty("Page")]
        public LimitOffset Page { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Stat.Drilldown
{
    public class DrilldownQueryParameters : StatGeneralQueryParams
    {
        [JsonProperty("only_expandable_undefined")]
        public bool OnlyExpandableUndefined { get; set; }

        [JsonProperty("parent_id")]
        public List<string> ParentId { get; set; } = new List<string>();
    }
}

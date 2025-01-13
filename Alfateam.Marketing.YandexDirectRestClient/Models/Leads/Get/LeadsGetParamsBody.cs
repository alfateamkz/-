using Alfateam.Marketing.YandexDirectRestClient.Enums.Leads;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Leads.Get
{
    public class LeadsGetParamsBody
    {
        [JsonProperty("SelectionCriteria")]
        public LeadsSelectionCriteria SelectionCriteria { get; set; }

        [JsonProperty("FieldNames")]
        public List<LeadFieldEnum> FieldNames { get; set; } = new List<LeadFieldEnum>();

        [JsonProperty("Page")]
        public LimitOffset Page { get; set; }
    }
}

using Alfateam.Marketing.YandexDirectRestClient.Enums.Leads;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Leads.Get
{
    public class LeadsGetResultBody
    {
        [JsonProperty("Leads")]
        public List<LeadGetItem> Leads { get; set; } = new List<LeadGetItem>();

        [JsonProperty("LimitedBy")]
        public long LimitedBy { get; set; }
    }
}

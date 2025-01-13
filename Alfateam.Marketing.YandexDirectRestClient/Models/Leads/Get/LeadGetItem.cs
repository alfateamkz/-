using Alfateam.Marketing.YandexDirectRestClient.Enums.Leads;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Leads.Get
{
    public class LeadGetItem
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("SubmittedAt")]
        public DateTime SubmittedAt { get; set; }

        [JsonProperty("TurboPageId")]
        public string TurboPageId { get; set; }

        [JsonProperty("TurboPageName")]
        public string TurboPageName { get; set; }

        [JsonProperty("Data")]
        public List<LeadDataItem> Data { get; set; } = new List<LeadDataItem>();
    }
}

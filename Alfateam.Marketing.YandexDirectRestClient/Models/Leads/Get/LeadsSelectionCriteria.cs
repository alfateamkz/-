using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Leads.Get
{
    public class LeadsSelectionCriteria
    {
        [JsonProperty("TurboPageIds")]
        public List<long> TurboPageIds { get; set; } = new List<long>();

        [JsonProperty("DateTimeFrom")]
        public DateTime DateTimeFrom { get; set; }

        [JsonProperty("DateTimeTo")]
        public DateTime DateTimeTo { get; set; }
    }
}

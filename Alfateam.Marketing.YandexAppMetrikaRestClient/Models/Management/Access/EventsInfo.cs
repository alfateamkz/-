using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Management.Access
{
    public class EventsInfo
    {
        [JsonProperty("events")]
        public List<string> Events { get; set; } = new List<string>();

        [JsonProperty("totals")]
        public int Totals { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Management.Access.ListEvents
{
    public class ListEventsResponse
    {
        [JsonProperty("events_info")]
        public EventsInfo EventsInfo { get; set; }
    }
}

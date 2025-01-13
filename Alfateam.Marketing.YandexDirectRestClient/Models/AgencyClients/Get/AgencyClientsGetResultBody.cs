using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AgencyClients.Get
{
    public class AgencyClientsGetResultBody
    {
        [JsonProperty("Clients")]
        public List<ClientGetItem> Clients { get; set; } = new List<ClientGetItem>();

        [JsonProperty("LimitedBy")]
        public long LimitedBy { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Clients.GetClients
{
    public class GetClientsQueryParams
    {
        [JsonProperty("counters")]
        public List<int> Counters { get; set; } = new List<int>();
    }
}

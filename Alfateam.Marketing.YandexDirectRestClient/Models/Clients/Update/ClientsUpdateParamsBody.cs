using Alfateam.Marketing.YandexDirectRestClient.Models.AgencyClients.Get;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Clients.Update
{
    public class ClientsUpdateParamsBody
    {
        [JsonProperty("Clients")]
        public List<ClientUpdateItem> Clients { get; set; } = new List<ClientUpdateItem>();
    }
}

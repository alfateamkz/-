using Alfateam.Marketing.YandexDirectRestClient.Models.AgencyClients.Get;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Clients.Get
{
    public class ClientsGetResultBody
    {
        [JsonProperty("Clients")]
        public List<ClientGetItem> Clients { get; set; } = new List<ClientGetItem>();
    }
}

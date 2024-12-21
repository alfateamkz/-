using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Clients.GetClients
{
    public class GetClientsResponse
    {
        [JsonProperty("clients")]
        public List<Client> Clients { get; set; } = new List<Client>();
    }
}

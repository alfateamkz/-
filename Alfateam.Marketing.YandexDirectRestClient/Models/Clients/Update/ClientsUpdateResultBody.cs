using Alfateam.Marketing.YandexDirectRestClient.Models.AgencyClients.Update;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Clients.Update
{
    public class ClientsUpdateResultBody
    {
        [JsonProperty("UpdateResults")]
        public List<ClientsActionResult> UpdateResults { get; set; } = new List<ClientsActionResult>();
    }
}

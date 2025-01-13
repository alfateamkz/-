using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AgencyClients.Update
{
    public class AgencyClientsUpdateParamsBody
    {
        [JsonProperty("Clients")]
        public List<AgencyClientUpdateItem> Clients { get; set; } = new List<AgencyClientUpdateItem>();
    }
}

using Alfateam.Marketing.YandexDirectRestClient.Enums.AgencyClients;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AgencyClients.Get
{
    public class ClientRestrictionItem
    {
        [JsonProperty("Element")]
        public ClientRestrictionEnum Element { get; set; }

        [JsonProperty("Value")]
        public int Value { get; set; }
    }
}

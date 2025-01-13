using Alfateam.Marketing.YandexDirectRestClient.Models.AgencyClients.Get;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AgencyClients.Update
{
    public class ErirAttributesUpdate
    {
        [JsonProperty("Organization")]
        public OrganizationUpdate Organization { get; set; }

        [JsonProperty("Contract")]
        public ContractUpdate Contract { get; set; }

        [JsonProperty("Contragent")]
        public ContragentUpdate Contragent { get; set; }
    }
}

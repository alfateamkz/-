using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AgencyClients.Get
{
    public class ErirAttributesGet
    {
        [JsonProperty("Organization")]
        public OrganizationGet Organization { get; set; }

        [JsonProperty("Contract")]
        public ContractGet Contract { get; set; }

        [JsonProperty("Contragent")]
        public ContragentGet Contragent { get; set; }
    }
}

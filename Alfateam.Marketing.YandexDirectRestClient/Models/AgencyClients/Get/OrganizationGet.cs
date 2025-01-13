using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AgencyClients.Get
{
    public class OrganizationGet
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("EpayNumber")]
        public string EpayNumber { get; set; }

        [JsonProperty("RegNumber")]
        public string RegNumber { get; set; }

        [JsonProperty("OksmNumber")]
        public string OksmNumber { get; set; }

        [JsonProperty("OkvedCode")]
        public string OkvedCode { get; set; }
    }
}

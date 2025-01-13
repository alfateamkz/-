using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AgencyClients
{
    public class ContractPrice
    {
        [JsonProperty("Amount")]
        public decimal Amount { get; set; }

        [JsonProperty("IncludingVat")]
        public YesNoEnum IncludingVAT { get; set; }
    }
}

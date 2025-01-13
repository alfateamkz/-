using Alfateam.Marketing.YandexDirectRestClient.Enums.AgencyClients;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AgencyClients.Get
{
    public class ContractGet
    {
        [JsonProperty("Number")]
        public string Number { get; set; }

        [JsonProperty("Date")]
        public DateTime Date { get; set; }

        [JsonProperty("Type")]
        public ContractTypeEnum Type { get; set; }

        [JsonProperty("ActionType")]
        public ContractActionTypeEnum ActionType { get; set; }

        [JsonProperty("SubjectType")]
        public ContractSubjectTypeEnum SubjectType { get; set; }

        [JsonProperty("Price")]
        public ContractPrice Price { get; set; }
    }
}

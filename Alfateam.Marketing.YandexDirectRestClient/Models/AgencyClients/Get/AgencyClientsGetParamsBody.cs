using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Alfateam.Marketing.YandexDirectRestClient.Enums.AgencyClients;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AgencyClients.Get
{
    public class AgencyClientsGetParamsBody
    {

        public virtual void a()
        {
            
        }

        [JsonProperty("SelectionCriteria")]
        public AgencyClientsSelectionCriteria SelectionCriteria { get; set; }

        [JsonProperty("FieldNames")]
        public List<AgencyClientFieldEnum> FieldNames { get; set; } = Enum.GetValues<AgencyClientFieldEnum>().ToList();

        [JsonProperty("TinInfoFieldNames")]
        public List<TinInfoFieldEnum> TinInfoFieldNames { get; set; } = Enum.GetValues<TinInfoFieldEnum>().ToList();

        [JsonProperty("OrganizationFieldNames")]
        public List<OrganizationFieldEnum> OrganizationFieldNames { get; set; } = Enum.GetValues<OrganizationFieldEnum>().ToList();

        [JsonProperty("ContractFieldNames")]
        public List<ContractFieldEnum> ContractFieldNames { get; set; } = Enum.GetValues<ContractFieldEnum>().ToList();

        [JsonProperty("ContragentFieldNames")]
        public List<ContragentFieldEnum> ContragentFieldNames { get; set; } = Enum.GetValues<ContragentFieldEnum>().ToList();

        [JsonProperty("ContragentTinInfoFieldNames")]
        public List<TinInfoFieldEnum> ContragentTinInfoFieldNames { get; set; } = Enum.GetValues<TinInfoFieldEnum>().ToList();

        [JsonProperty("Page")]
        public LimitOffset Page { get; set; }
    }
}

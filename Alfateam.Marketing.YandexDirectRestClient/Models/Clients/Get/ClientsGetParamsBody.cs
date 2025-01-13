using Alfateam.Marketing.YandexDirectRestClient.Enums.AgencyClients;
using Alfateam.Marketing.YandexDirectRestClient.Enums.Clients;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Clients.Get
{
    public class ClientsGetParamsBody
    {
        [JsonProperty("FieldNames")]
        public List<ClientFieldEnum> FieldNames { get; set; } = Enum.GetValues<ClientFieldEnum>().ToList();

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
    }
}

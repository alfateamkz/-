using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.API.Models.DTO.Counterparties;
using Alfateam.EDM.API.Models.DTO.General.Subjects;
using Alfateam.EDM.Models;
using Alfateam.EDM.Models.Abstractions;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.EDM.API.Models.DTO.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<CounterpartyDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(CompanyCounterpartyDTO), "CompanyCounterparty")]
    [JsonKnownType(typeof(EDMCounterpartyDTO), "EDMCounterparty")]
    [JsonKnownType(typeof(IndividualCounterpartyDTO), "IndividualCounterparty")]
    public class CounterpartyDTO : DTOModelAbs<Counterparty>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        [ForClientOnly]
        public CounterpartyGroupDTO Group { get; set; }
        public int GroupId { get; set; }
    }
}

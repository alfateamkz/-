using Alfateam.ID.API.Models.DTO.Payments.Ways;
using Alfateam.ID.Models.Abstractions;
using Alfateam.ID.Models.Payments.Ways;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.ID.API.Abstractions.DTO
{
    [JsonConverter(typeof(JsonKnownTypesConverter<BindedPaymentWayDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(BindedBankCardDTO), "BindedBankCard")]
    public class BindedPaymentWayDTO : DTOModelAbs<BindedPaymentWay>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }
    }
}

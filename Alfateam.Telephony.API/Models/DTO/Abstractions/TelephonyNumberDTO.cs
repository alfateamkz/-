using Alfateam.Telephony.API.Models.DTO.General.Numbers;
using Alfateam.Telephony.Models.Abstractions;
using Alfateam.Telephony.Models.General.Numbers;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.Telephony.API.Models.DTO.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<TelephonyNumberDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(ExternalNumberDTO), "ExternalNumber")]
    [JsonKnownType(typeof(VirtualNumberDTO), "VirtualNumber")]
    public class TelephonyNumberDTO : DTOModelAbs<TelephonyNumber>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public string PhoneNumber { get; set; }
    }
}

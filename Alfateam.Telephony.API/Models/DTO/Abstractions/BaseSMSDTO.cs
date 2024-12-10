using Alfateam.Telephony.API.Models.DTO.SMS;
using Alfateam.Telephony.Models.Abstractions;
using Alfateam.Telephony.Models.SMS;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.Telephony.API.Models.DTO.Abstractions
{

    [JsonConverter(typeof(JsonKnownTypesConverter<BaseSMSDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(ReceivedSMSDTO), "ReceivedSMS")]
    [JsonKnownType(typeof(SentSMSDTO), "SentSMS")]
    public class BaseSMSDTO : DTOModelAbs<BaseSMS>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public string Text { get; set; }
    }
}

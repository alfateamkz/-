using Alfateam.Core.Attributes.DTO;
using Alfateam.Telephony.API.Models.DTO.Calls;
using Alfateam.Telephony.API.Models.DTO.Calls.Types;
using Alfateam.Telephony.Models.Abstractions;
using Alfateam.Telephony.Models.Calls.Types;
using Alfateam.Telephony.Models.Enums;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.Telephony.API.Models.DTO.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<BaseCallDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(IncomingCallDTO), "IncomingCall")]
    [JsonKnownType(typeof(OutgoingCallDTO), "OutgoingCall")]
    public class BaseCallDTO : DTOModelAbs<BaseCall>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }




        [ForClientOnly]
        public CallStatus Status { get; set; }

        [ForClientOnly]
        public DateTime? StartedAt { get; set; }

        [ForClientOnly]
        public DateTime? EndedAt { get; set; }




        [ForClientOnly]
        public CallRecordDTO? Record { get; set; }
        public string? Comment { get; set; }
    }
}

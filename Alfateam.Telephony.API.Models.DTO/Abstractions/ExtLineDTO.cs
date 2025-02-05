using Alfateam.Telephony.API.Models.DTO.ExtLines;
using Alfateam.Telephony.API.Models.DTO.General.AudioRecords;
using Alfateam.Telephony.Models.Abstractions;
using Alfateam.Telephony.Models.ExtLines;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.Telephony.API.Models.DTO.Abstractions
{

    [JsonConverter(typeof(JsonKnownTypesConverter<ExtLineDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(FromServiceToServerExtLineDTO), "FromServiceToServerExtLine")]
    [JsonKnownType(typeof(FromServerToServiceExtLineDTO), "FromServerToServiceExtLine")]
    public class ExtLineDTO : DTOModelAbs<ExtLine>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public string Title { get; set; }
        public bool IsEnabled { get; set; }


        public int OutgoingChannelsCount { get; set; }
        public int IncomingChannelsCount { get; set; }


        public string OutgoingCallsPrefix { get; set; }
    }
}

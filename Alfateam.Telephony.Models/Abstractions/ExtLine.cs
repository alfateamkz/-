using Alfateam.Core;
using Alfateam.Telephony.Models.ExternalInteractions;
using Alfateam.Telephony.Models.ExtLines;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<ExtInteraction>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(FromServiceToServerExtLine), "FromServiceToServerExtLine")]
    [JsonKnownType(typeof(FromServerToServiceExtLine), "FromServerToServiceExtLine")]
    public class ExtLine : AbsModel
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

using Alfateam.Core;
using Alfateam.Telephony.Models.Calls;
using Alfateam.Telephony.Models.Calls.Types;
using Alfateam.Telephony.Models.Enums;
using Alfateam.Telephony.Models.SMS;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<BaseCall>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(IncomingCall), "IncomingCall")]
    [JsonKnownType(typeof(OutgoingCall), "OutgoingCall")]
    public class BaseCall : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public CallStatus Status { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? EndedAt { get; set; }



        public CallRecord? Record { get; set; }
        public int? RecordId { get; set; }

        public string? Comment { get; set; }
    }
}

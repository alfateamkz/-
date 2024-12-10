using Alfateam.Core;
using Alfateam.Telephony.Models.ExternalInteractions;
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
    [JsonConverter(typeof(JsonKnownTypesConverter<BaseSMS>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(ReceivedSMS), "ReceivedSMS")]
    [JsonKnownType(typeof(SentSMS), "SentSMS")]
    public class BaseSMS : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public string Text { get; set; }
    }
}

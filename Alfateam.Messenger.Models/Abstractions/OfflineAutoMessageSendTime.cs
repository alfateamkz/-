using Alfateam.Core;
using Alfateam.Messenger.Models.General.Chats.OfflineAutoTime;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<OfflineAutoMessageSendTime>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(OfflineAutoMessageSendAlways), "OfflineAutoMessageSendAlways")]
    [JsonKnownType(typeof(OfflineAutoMessageSendBySchedule), "OfflineAutoMessageSendBySchedule")]
    public class OfflineAutoMessageSendTime : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }
    }
}

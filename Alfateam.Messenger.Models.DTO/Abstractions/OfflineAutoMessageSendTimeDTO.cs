using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.DTO.General.Chats.OfflineAutoTime;
using Alfateam.Messenger.Models.General.Chats.OfflineAutoTime;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<OfflineAutoMessageSendTimeDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(OfflineAutoMessageSendAlwaysDTO), "OfflineAutoMessageSendAlways")]
    [JsonKnownType(typeof(OfflineAutoMessageSendByScheduleDTO), "OfflineAutoMessageSendBySchedule")]
    public class OfflineAutoMessageSendTimeDTO : DTOModelAbs<OfflineAutoMessageSendTime>
    {
    }
}

using Alfateam.TicketSystem.Models.Abstractions;
using Alfateam.TicketSystem.Models.DTO.General.Notifications;
using Alfateam.TicketSystem.Models.General.Notifications;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models.DTO.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<UserNotificationDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(NewTicketUserNotificationDTO), "NewTicketUserNotification")]
    [JsonKnownType(typeof(SimpleUserNotificationDTO), "SimpleUserNotification")]
    public class UserNotificationDTO : DTOModelAbs<UserNotification>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }
    }
}

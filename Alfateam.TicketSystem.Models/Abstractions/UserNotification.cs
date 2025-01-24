using Alfateam.Core;
using Alfateam.TicketSystem.Models.DTO.Tickets.DistributionStrategies;
using Alfateam.TicketSystem.Models.General.Notifications;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<UserNotification>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(NewTicketUserNotification), "NewTicketUserNotification")]
    [JsonKnownType(typeof(SimpleUserNotification), "SimpleUserNotification")]
    public class UserNotification : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }
        public DateTime? ReadAt { get; set; }



        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int UserId { get; set; }
    }
}

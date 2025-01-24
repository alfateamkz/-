using Alfateam.Core;
using Alfateam.TicketSystem.Models.Tickets.Messages;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<TicketMessage>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(TextTicketMessage), "TextTicketMessage")]
    public class TicketMessage : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }

        public TicketMessageSender Sender { get; set; } 


        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int TicketId { get; set; }
    }
}

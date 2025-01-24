using Alfateam.TicketSystem.Models.Abstractions;
using Alfateam.TicketSystem.Models.DTO.Tickets.Messages;
using Alfateam.TicketSystem.Models.Tickets.Messages;
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
    [JsonConverter(typeof(JsonKnownTypesConverter<TicketMessageDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(TextTicketMessageDTO), "TextTicketMessage")]
    public class TicketMessageDTO : DTOModelAbs<TicketMessage>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }

        public TicketMessageSenderDTO Sender { get; set; }
    }
}

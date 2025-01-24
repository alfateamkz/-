using Alfateam.TicketSystem.Models.Abstractions;
using Alfateam.TicketSystem.Models.DTO.Tickets.Senders;
using Alfateam.TicketSystem.Models.Tickets.Senders;
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
    [JsonConverter(typeof(JsonKnownTypesConverter<TicketMessageSenderDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(TicketMessageAdminSenderDTO), "TicketMessageAdminSender")]
    [JsonKnownType(typeof(TicketMessageAnonymSenderDTO), "TicketMessageAnonymSender")]
    [JsonKnownType(typeof(TicketMessageCustomerSenderDTO), "TicketMessageCustomerSender")]
    public class TicketMessageSenderDTO : DTOModelAbs<TicketMessageSender>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }
    }
}

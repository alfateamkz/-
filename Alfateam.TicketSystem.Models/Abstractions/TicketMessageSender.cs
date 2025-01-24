using Alfateam.Core;
using Alfateam.TicketSystem.Models.Tickets.Messages;
using Alfateam.TicketSystem.Models.Tickets.Senders;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<TicketMessageSender>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(TicketMessageAdminSender), "TicketMessageAdminSender")]
    [JsonKnownType(typeof(TicketMessageCustomerSender), "TicketMessageCustomerSender")]
    [JsonKnownType(typeof(TicketMessageAnonymSender), "TicketMessageAnonymSender")]
    public class TicketMessageSender : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }
    }
}

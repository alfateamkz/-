using Alfateam.Core;
using Alfateam.TicketSystem.Models.DTO.Tickets.DistributionStrategies;
using Alfateam.TicketSystem.Models.Tickets.Creators;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<TicketCreator>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(TicketAnonymCreator), "TicketAnonymCreator")]
    [JsonKnownType(typeof(TicketCustomerCreator), "TicketCustomerCreator")]
    public class TicketCreator : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }
    }
}

using Alfateam.TicketSystem.Models.Abstractions;
using Alfateam.TicketSystem.Models.DTO.Tickets.Creators;
using Alfateam.TicketSystem.Models.Tickets.Creators;
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
    [JsonConverter(typeof(JsonKnownTypesConverter<TicketCreatorDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(TicketAnonymCreatorDTO), "TicketAnonymCreator")]
    [JsonKnownType(typeof(TicketCustomerCreatorDTO), "TicketCustomerCreator")]
    public class TicketCreatorDTO : DTOModelAbs<TicketCreator>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }
    }
}

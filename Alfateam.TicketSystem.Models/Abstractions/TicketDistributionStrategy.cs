using Alfateam.Core;
using Alfateam.TicketSystem.Models.DTO.Tickets.DistributionStrategies;
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
    [JsonConverter(typeof(JsonKnownTypesConverter<TicketDistributionStrategy>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(AverageLoadingTicketDistributionStrategy), "AverageLoadingTicketDistributionStrategy")]
    [JsonKnownType(typeof(ByOperatorPriorityTicketDistributionStrategy), "ByOperatorPriorityTicketDistributionStrategy")]
    [JsonKnownType(typeof(MaxLoadingTicketDistributionStrategy), "MaxLoadingTicketDistributionStrategy")]
    [JsonKnownType(typeof(NotifyAllTicketDistributionStrategy), "NotifyAllTicketDistributionStrategy")]
    [JsonKnownType(typeof(RandomTicketDistributionStrategy), "RandomTicketDistributionStrategy")]
    public class TicketDistributionStrategy : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }
    }
}

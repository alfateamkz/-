using Alfateam.TicketSystem.Models.Abstractions;
using Alfateam.TicketSystem.Models.DTO.Tickets.DistributionStrategies;
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
    [JsonConverter(typeof(JsonKnownTypesConverter<TicketDistributionStrategyDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(AverageLoadingTicketDistributionStrategyDTO), "AverageLoadingTicketDistributionStrategy")]
    [JsonKnownType(typeof(ByOperatorPriorityTicketDistributionStrategyDTO), "ByOperatorPriorityTicketDistributionStrategy")]
    [JsonKnownType(typeof(MaxLoadingTicketDistributionStrategyDTO), "MaxLoadingTicketDistributionStrategy")]
    [JsonKnownType(typeof(NotifyAllTicketDistributionStrategyDTO), "NotifyAllTicketDistributionStrategy")]
    [JsonKnownType(typeof(RandomTicketDistributionStrategyDTO), "RandomTicketDistributionStrategy")]
    public class TicketDistributionStrategyDTO : DTOModelAbs<TicketDistributionStrategy>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }
    }
}

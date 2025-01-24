using Alfateam.TicketSystem.Models.DTO.Abstractions;
using Alfateam.TicketSystem.Models.DTO.Tickets.DistributionStrategies.Items;
using Alfateam.TicketSystem.Models.Tickets.DistributionStrategies.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models.DTO.Tickets.DistributionStrategies
{
    public class ByOperatorPriorityTicketDistributionStrategyDTO : TicketDistributionStrategyDTO
    {
        public List<TicketOperatorPriorityDTO> OperatorPriorities { get; set; } = new List<TicketOperatorPriorityDTO>();
        public int MaxTicketsCountForOperator { get; set; }
    }
}

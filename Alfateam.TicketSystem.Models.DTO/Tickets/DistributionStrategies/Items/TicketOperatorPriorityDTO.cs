using Alfateam.Core.Attributes.DTO;
using Alfateam.TicketSystem.Models.DTO.General;
using Alfateam.TicketSystem.Models.Tickets.DistributionStrategies.Items;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models.DTO.Tickets.DistributionStrategies.Items
{
    public class TicketOperatorPriorityDTO : DTOModelAbs<TicketOperatorPriority>
    {
        [ForClientOnly]
        public UserDTO User { get; set; }

        [HiddenFromClient]
        public int UserId { get; set; }


        public int Priority { get; set; }
    }
}

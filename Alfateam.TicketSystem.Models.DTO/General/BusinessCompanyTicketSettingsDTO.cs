using Alfateam.Core.Attributes.DTO;
using Alfateam.TicketSystem.Models.Abstractions;
using Alfateam.TicketSystem.Models.DTO.Abstractions;
using Alfateam.TicketSystem.Models.General;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models.DTO.General
{
    public class BusinessCompanyTicketSettingsDTO : DTOModelAbs<BusinessCompanyTicketSettings>
    {
        public TicketDistributionStrategyDTO TicketDistributionStrategy { get; set; }
        public int MakeTicketClosedAfterHours { get; set; }




        [ForClientOnly]
        public TicketPriorityDTO DefaultPriority { get; set; }

        [HiddenFromClient]
        public int DefaultPriorityId { get; set; }
    }
}

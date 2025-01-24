using Alfateam.Core;
using Alfateam.TicketSystem.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models.General
{
    public class BusinessCompanyTicketSettings : AbsModel
    {
        public TicketDistributionStrategy TicketDistributionStrategy { get; set; }
        public int MakeTicketClosedAfterHours { get; set; }


        public TicketPriority DefaultPriority { get; set; }
        public int DefaultPriorityId { get; set; }
    }
}

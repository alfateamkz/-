using Alfateam.Core;
using Alfateam.TicketSystem.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models.Tickets.DistributionStrategies.Items
{
    public class TicketOperatorPriority : AbsModel
    {
        public User User { get; set; }
        public int UserId { get; set; }


        public int Priority { get; set; }
    }
}

using Alfateam.TicketSystem.Models.General;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models.DTO.General
{
    public class SubscriptionInfoDTO : DTOModelAbs<SubscriptionInfo>
    {
        public DateTime SubscriptionBefore { get; set; }
    }
}

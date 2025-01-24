using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models.DTO
{
    public class TicketPriorityDTO : DTOModelAbs<TicketPriority>
    {
        public string Title { get; set; }
        public int Priority { get; set; }
    }
}

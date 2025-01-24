using Alfateam.Core;
using Alfateam.TicketSystem.Models.Abstractions;
using Alfateam.TicketSystem.Models.Enums;
using Alfateam.TicketSystem.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models.Tickets
{
    public class Ticket : AbsModel
    {
        public TicketCreator CreatedBy { get; set; }
        public TicketStatus Status { get; set; }



        public TicketCategory Category { get; set; }
        public int CategoryId { get; set; }


        public TicketPriority Priority { get; set; }
        public int PriorityId { get; set; }


        public List<TicketMessage> Messages { get; set; } = new List<TicketMessage>();
        public List<User> ResponsibleUsers { get; set; } = new List<User>();


        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessCompanyId { get; set; }
    }
}

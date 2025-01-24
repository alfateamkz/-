using Alfateam.Core;
using Alfateam.TicketSystem.Models.Abstractions;
using Alfateam.TicketSystem.Models.Enums;
using Alfateam.TicketSystem.Models.General.Security;
using Alfateam.TicketSystem.Models.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models.General
{
    public class User : AbsModel
    {
        public string AlfateamID { get; set; }
        public UserRole Role { get; set; } = UserRole.Operator;


        public string Position { get; set; }



        public Department Department { get; set; }
        public int DepartmentId { get; set; }



        public UserPermissions Permissions { get; set; }
        public bool IsBlocked { get; set; }



        public List<Ticket> ResponsibleInTickets { get; set; } = new List<Ticket>();
        public List<UserNotification> Notifications { get; set; } = new List<UserNotification>();



        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessCompanyId { get; set; }
    }
}

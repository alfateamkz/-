using Alfateam.Core;
using Alfateam.TicketSystem.Models.General.WorkingDays;
using Alfateam.TicketSystem.Models.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models.General
{
    public class BusinessCompany : AbsModel
    {
        public string Title { get; set; }
        public string LegalAddress { get; set; }
        public string? ActualAddress { get; set; }


        public string? Description { get; set; }
        public string? CountryCode { get; set; }
        public string? BusinessNumber { get; set; }


        public string? LogoPath { get; set; }





        public List<User> Users { get; set; } = new List<User>();
        public Department Department { get; set; }



        public List<Ticket> Tickets { get; set; } = new List<Ticket>();
        public List<TicketCategory> TicketCategories { get; set; } = new List<TicketCategory>();
        public List<TicketPriority> TicketPriorities { get; set; } = new List<TicketPriority>();


        public BusinessCompanyTicketSettings TicketSettings { get; set; }
        public CompanyWorkingDays WorkingDays { get; set; }



        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessId { get; set; }
    }
}

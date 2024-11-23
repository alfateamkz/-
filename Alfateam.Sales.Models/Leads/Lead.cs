using Alfateam.Core;
using Alfateam.Sales.Models.Customers;
using Alfateam.Sales.Models.Enums;
using Alfateam.Sales.Models.General;
using Alfateam.Sales.Models.Leads.Kanban;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Leads
{
    public class Lead : AbsModel
    {
        public string? Title { get; set; }
        public LeadSource? Source { get; set; }
        public UTMMark? UTMMark { get; set; }



        public PersonContact? PersonContact { get; set; }
        public int? PersonContactId { get; set; }


        public Company? Company { get; set; }
        public int? CompanyId { get; set; }




        public LeadsKanbanData KanbanData { get; set; }



        public string? Comment { get; set; }


        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessCompanyId { get; set; }

    }
}

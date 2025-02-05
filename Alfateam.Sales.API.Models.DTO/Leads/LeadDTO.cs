using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.API.Models.DTO.Customers;
using Alfateam.Sales.API.Models.DTO.Leads.Kanban;
using Alfateam.Sales.Models.Customers;
using Alfateam.Sales.Models.Enums;
using Alfateam.Sales.Models.General;
using Alfateam.Sales.Models.Leads;
using Alfateam.Sales.Models.Leads.Kanban;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.Leads
{
    public class LeadDTO : DTOModelAbs<Lead>
    {
        public string? Title { get; set; }
        public LeadSource? Source { get; set; }
        public UTMMark? UTMMark { get; set; }



        [ForClientOnly]
        public PersonContactDTO? PersonContact { get; set; }

        [HiddenFromClient]
        public int? PersonContactId { get; set; }



        [ForClientOnly]
        public CompanyDTO? Company { get; set; }

        [HiddenFromClient]
        public int? CompanyId { get; set; }




        [ForClientOnly]
        public LeadsKanbanDataDTO KanbanData { get; set; }



        public string? Comment { get; set; }
    }
}

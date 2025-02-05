using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.API.Models.DTO.BusinessProposals.Kanban;
using Alfateam.Sales.API.Models.DTO.Customers;
using Alfateam.Sales.API.Models.DTO.General;
using Alfateam.Sales.Models.BusinessProposals;
using Alfateam.Sales.Models.BusinessProposals.Kanban;
using Alfateam.Sales.Models.General;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.BusinessProposals
{
    public class BusinessProposalDTO : DTOModelAbs<BusinessProposal>
    {

        [ForClientOnly]
        public string UniqueURL { get; set; }



        [ForClientOnly]
        public PersonContactDTO? PersonContact { get; set; }

        [HiddenFromClient]
        public int? PersonContactId { get; set; }



        [ForClientOnly]
        public CompanyDTO? Company { get; set; }

        [HiddenFromClient]
        public int? CompanyId { get; set; }





        public string Title { get; set; }
        public string? HTMLContent { get; set; }
        public CurrencyAndValueDTO Sum { get; set; }




        public DateTime? ExpiresAt { get; set; }



        [ForClientOnly]
        public BusinessProposalsKanbanDataDTO KanbanData { get; set; }

    }
}

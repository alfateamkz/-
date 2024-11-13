using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.Models.BusinessProposals;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.BusinessProposals
{
    public class BusinessProposalDTO : DTOModelAbs<BusinessProposal>
    {

        [ForClientOnly]
        public string UniqueURL { get; set; }



        public string Title { get; set; }
        public string HTMLContent { get; set; }


        public DateTime? ExpiresAt { get; set; }


        [ForClientOnly]
        public CustomerDTO Customer { get; set; }
        [HiddenFromClient]
        public int CustomerId { get; set; }
    }
}

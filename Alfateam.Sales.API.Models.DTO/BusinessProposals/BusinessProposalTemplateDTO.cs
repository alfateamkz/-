using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.API.Models.DTO.Abstractions;
using Alfateam.Sales.Models.Abstractions;
using Alfateam.Sales.Models.BusinessProposals;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.BusinessProposals
{
    public class BusinessProposalTemplateDTO : DTOModelAbs<BusinessProposalTemplate>
    {
        public string Title { get; set; }
        public string HTMLContent { get; set; }

        [ForClientOnly]
        public List<BPTemplatePlaceholderDTO> Placeholders { get; set; } = new List<BPTemplatePlaceholderDTO>();
    }
}

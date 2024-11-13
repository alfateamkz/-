using Alfateam.Sales.API.Models.DTO.Abstractions;
using Alfateam.Sales.Models.Enums.Fields;

namespace Alfateam.Sales.API.Models.DTO.BusinessProposals.Placeholders
{
    public class BPCustomerTemplatePlaceholderDTO : BPTemplatePlaceholderDTO
    {
        public PlaceholderCustomerFieldType Field { get; set; }
    }
}

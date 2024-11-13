using Alfateam.Sales.API.Models.DTO.Abstractions;
using Alfateam.Sales.Models.Enums.Fields;

namespace Alfateam.Sales.API.Models.DTO.BusinessProposals.Placeholders
{
    public class BPManualTemplatePlaceholderDTO : BPTemplatePlaceholderDTO
    {
        public ManualPlaceholderFieldType Type { get; set; }
    }
}

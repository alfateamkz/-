using Alfateam.Sales.API.Models.DTO.Abstractions.ExtInterations;

namespace Alfateam.Sales.API.Models.DTO.ExternalInteractions.Inputs
{
    public class TextWebsiteFormInputDTO : WebsiteFormInputDTO
    {
        public bool Multiline { get; set; }
        public int? MaxLength { get; set; }
        public int? MinLength { get; set; }
    }
}

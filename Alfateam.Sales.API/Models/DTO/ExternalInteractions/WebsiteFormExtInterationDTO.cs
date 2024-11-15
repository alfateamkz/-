using Alfateam.Sales.API.Models.DTO.Abstractions.ExtInterations;
using Alfateam.Sales.Models.Abstractions.ExtInterations;
using Alfateam.Sales.Models.Enums;

namespace Alfateam.Sales.API.Models.DTO.ExternalInteractions
{
    public class WebsiteFormExtInterationDTO : ExternalInteractionDTO
    {
        public string Header { get; set; }
        public string? Description { get; set; }
        public WebsiteFormType Type { get; set; }


        public List<WebsiteFormInputDTO> Inputs { get; set; } = new List<WebsiteFormInputDTO>();


        public string? PrivacyPolicyURL { get; set; }
    }
}

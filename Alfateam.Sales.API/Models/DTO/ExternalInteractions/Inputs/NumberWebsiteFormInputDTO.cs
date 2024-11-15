using Alfateam.Sales.API.Models.DTO.Abstractions.ExtInterations;

namespace Alfateam.Sales.API.Models.DTO.ExternalInteractions.Inputs
{
    public class NumberWebsiteFormInputDTO : WebsiteFormInputDTO
    {
        public bool IsDouble { get; set; }
        public double? MinValue { get; set; }
        public double? MaxValue { get; set; }
        public double? Step { get; set; }
    }
}

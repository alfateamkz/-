using Alfateam.Sales.API.Models.DTO.Abstractions.ExtInterations;

namespace Alfateam.Sales.API.Models.DTO.ExternalInteractions.Inputs
{
    public class RangeWebsiteFormInputDTO : WebsiteFormInputDTO
    {
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public double Step { get; set; }
    }
}

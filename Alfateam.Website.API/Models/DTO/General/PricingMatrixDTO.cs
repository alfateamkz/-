using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.General;

namespace Alfateam.Website.API.Models.DTO.General
{
    public class PricingMatrixDTO : DTOModel<PricingMatrix>
    {
        public List<PricingMatrixItemDTO> Costs { get; set; } = new List<PricingMatrixItemDTO>();

    }
}

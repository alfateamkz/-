using Alfateam.Sales.API.Models.DTO.Abstractions;
using Alfateam.Sales.API.Models.DTO.Plan.Types.Items;
using Alfateam.Sales.Models.Plan.Types.Items;

namespace Alfateam.Sales.API.Models.DTO.Plan.Types
{
    public class ByFunnelsSalesPlanDTO : SalesPlanDTO
    {
        public List<ByFunnelsSalesPlanFunnelDTO> Funnels { get; set; } = new List<ByFunnelsSalesPlanFunnelDTO>();
    }
}

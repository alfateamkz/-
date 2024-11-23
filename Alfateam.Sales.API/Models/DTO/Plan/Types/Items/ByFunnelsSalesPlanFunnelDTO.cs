using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.API.Models.DTO.Funnel;
using Alfateam.Sales.Models.Plan.Types.Items;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.Plan.Types.Items
{
    public class ByFunnelsSalesPlanFunnelDTO : DTOModelAbs<ByFunnelsSalesPlanFunnel>
    {
        [ForClientOnly]
        public SalesFunnelDTO Funnel { get; set; }
        [HiddenFromClient]
        public int FunnelId { get; set; }


        public double Value { get; set; }
    }
}

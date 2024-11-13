using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.API.Models.DTO.Funnel;
using Alfateam.Sales.Models.Orders;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.Orders
{
    public class OrderSaleFunnelInfoDTO : DTOModelAbs<OrderSaleFunnelInfo>
    {
        [ForClientOnly]
        public SalesFunnelDTO Funnel { get; set; }
        [ForClientOnly]
        public SalesFunnelStageDTO FunnelStage { get; set; }
    }
}

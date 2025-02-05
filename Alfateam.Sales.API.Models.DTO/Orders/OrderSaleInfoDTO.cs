using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.API.Models.DTO.Funnel;
using Alfateam.Sales.API.Models.DTO.General;
using Alfateam.Sales.Models.Orders;
using Alfateam.Website.API.Abstractions;
using System.ComponentModel;

namespace Alfateam.Sales.API.Models.DTO.Orders
{
    public class OrderSaleInfoDTO : DTOModelAbs<OrderSaleInfo>
    {

        [ForClientOnly]
        public SalesFunnelDTO Funnel { get; set; }

        [ForClientOnly]
        public SalesFunnelStageDTO FunnelStage { get; set; }





        [Description("Продажник, который внес заказ в систему")]
        [ForClientOnly]
        public UserDTO FoundBy { get; set; }

        [Description("Продажник, который ответственнен за заказ")]
        [ForClientOnly]
        public UserDTO Responsible { get; set; }
    }
}

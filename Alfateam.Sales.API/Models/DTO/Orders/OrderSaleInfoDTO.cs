using Alfateam.Sales.API.Models.DTO.Funnel;
using Alfateam.Sales.Models.Orders;
using Alfateam.Website.API.Abstractions;
using System.ComponentModel;

namespace Alfateam.Sales.API.Models.DTO.Orders
{
    public class OrderSaleInfoDTO : DTOModelAbs<OrderSaleInfo>
    {
        public SalesFunnelDTO? Funnel { get; set; }
        public SalesFunnelStageDTO? FunnelStage { get; set; }





        [Description("Продажник, который внес заказ в систему")]
        public UserDTO FoundBy { get; set; }

        [Description("Продажник, который ответственнен за заказ")]
        public UserDTO Responsible { get; set; }
    }
}

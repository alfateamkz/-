using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Shop.Orders;

namespace Alfateam.Website.API.Models.DTO.Shop.Orders
{
    public class ShopOrderReturnDTO : DTOModel<ShopOrderReturn>
    {

        public DateTime ReturnedAt { get; set; }
        public string Reason { get; set; }
    }
}

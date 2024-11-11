using Alfateam.Sales.Models.Orders;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.Orders
{
    public class OrderStatusDTO : DTOModelAbs<OrderStatus>
    {
        public string Title { get; set; }
    }
}

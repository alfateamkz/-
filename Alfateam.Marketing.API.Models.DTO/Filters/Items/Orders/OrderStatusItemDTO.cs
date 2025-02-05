using Alfateam.Marketing.Models.Enums.Orders;
using Alfateam.Marketing.Models.Filters.Items.Orders;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Filters.Items.Orders
{
    public class OrderStatusItemDTO : DTOModelAbs<OrderStatusItem>
    {
        public OrderStatus Status { get; set; }
    }
}

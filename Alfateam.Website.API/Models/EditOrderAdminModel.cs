using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.Shop.Orders;

namespace Alfateam.Website.API.Models
{
    public class EditOrderAdminModel : DTOModel<ShopOrder>
    {
        public ShopOrderStatus Status { get; set; }
        public string? TrackingURL { get; set; }


        //public ShopOrderReturn? Return { get; set; }
    }
}

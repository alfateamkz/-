using Alfateam.Website.API.Abstractions;

namespace Alfateam.Website.API.Models.ClientModels.Shop.Orders
{
    public class ShopOrderReturnClientModel : ClientModel
    {
        public DateTime ReturnedAt { get; set; }
        public string Reason { get; set; }
    }
}

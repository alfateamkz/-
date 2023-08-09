using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.General;

namespace Alfateam.Website.API.Models.ClientModels.Shop.Orders
{
    public class ShopOrderPaymentClientModel : ClientModel
    {
        public double Sum { get; set; }
        public Currency Currency { get; set; }




        public DateTime InitiatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? PaidAt { get; set; }

        public MerchantServiceType MerchantService { get; set; }
        public string Description { get; set; }
    }
}

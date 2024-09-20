using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Attributes.DTO;
using Alfateam.Website.API.Models.DTO.General;
using Alfateam.Website.API.Models.DTO.General;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.Shop.Orders;

namespace Alfateam.Website.API.Models.DTO.Shop.Orders
{
    public class ShopOrderPaymentDTO : DTOModel<ShopOrderPayment>
    {
        public double Sum { get; set; }

        [ForClientOnly]
        public CurrencyDTO Currency { get; set; }
        public int CurrencyId { get; set; }


        [ForClientOnly]
        public DateTime InitiatedAt { get; set; } = DateTime.UtcNow;
        [ForClientOnly]
        public DateTime? PaidAt { get; set; }

        public MerchantServiceType MerchantService { get; set; }

        [ForClientOnly]
        public string Description { get; set; }
    }
}

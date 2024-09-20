using Alfateam.Website.API.Attributes.DTO;
using Alfateam.Website.API.Models.DTO.General;
using Alfateam.Website.API.Models.DTO.Promocodes;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Shop.Orders;

namespace Alfateam.Website.API.Models.DTO.Shop.Orders.Admin
{
    public class ShopOrderAdminDTO : ShopOrderDTO
    {
        [ForClientOnly]
        public UserDTO CreatedBy { get; set; }


        /// <summary>
        /// Страна, из которой создан заказ
        /// </summary>
        [ForClientOnly]
        public CountryDTO? Country { get; set; }


        [ForClientOnly]
        public PromocodeDTO? UsedPromocode { get; set; }


        /// <summary>
        /// Список всех оплат(неуспешные и одна успешная)
        /// </summary>
        [ForClientOnly]
        public List<ShopOrderPaymentDTO> Payments { get; set; } = new List<ShopOrderPaymentDTO>();
    }
}

using Alfateam.Website.API.Models.DTO.General;
using Alfateam.Website.API.Models.DTO.Promocodes;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Shop.Orders;

namespace Alfateam.Website.API.Models.DTO.Shop.Orders.Admin
{
    public class ShopOrderAdminDTO : ShopOrderDTO
    {
        public UserDTO CreatedBy { get; set; }


        /// <summary>
        /// Страна, из которой создан заказ
        /// </summary>
        public CountryDTO? Country { get; set; }



        public PromocodeDTO? UsedPromocode { get; set; }


        /// <summary>
        /// Список всех оплат(неуспешные и одна успешная)
        /// </summary>
        public List<ShopOrderPaymentDTO> Payments { get; set; } = new List<ShopOrderPaymentDTO>();
    }
}

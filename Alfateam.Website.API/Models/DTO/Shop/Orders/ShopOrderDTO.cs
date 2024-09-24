using Alfateam.Website.API.Abstractions;
using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Models.DTO.General;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.Shop.Orders;

namespace Alfateam.Website.API.Models.DTO.Shop.Orders
{
    public class ShopOrderDTO : DTOModel<ShopOrder>
    {
        public AddressDTO Address { get; set; }


        [ForClientOnly]
        public CurrencyDTO? Currency { get; set; }
        public double SumWithoutDiscount => Items.Sum(o => o.Sum);
        public double TotalSum
        {
            get
            {
                double val = SumWithoutDiscount;

                if (UsedPromocodeType != null)
                {
                    switch (UsedPromocodeType)
                    {
                        case PromocodeType.Fixed:
                            val -= (double)DiscountByPromocode;
                            break;
                        case PromocodeType.Percent:
                            val -= val - val / 100 * (double)DiscountByPromocode;
                            break;
                    }
                }
                return val;
            }
        }


        public ShopOrderStatus Status { get; set; } = ShopOrderStatus.Basket;

        [ForClientOnly]
        public List<ShopOrderItemDTO> Items { get; set; } = new List<ShopOrderItemDTO>();
        public string? TrackingURL { get; set; }




        /// <summary>
        /// Сохраняем значение на момент применения промокода, т.к. может измениться тип промокода в будущем
        /// и подсчеты будут неверны
        /// </summary>
        public PromocodeType? UsedPromocodeType { get; set; }
        public double? DiscountByPromocode { get; set; }



        public ShopOrderReturnDTO? Return { get; set; }

    }
}

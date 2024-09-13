using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models.DTO.General;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.Shop.Orders;

namespace Alfateam.Website.API.Models.DTO.Shop.Orders
{
    public class ShopOrderDTO : DTOModel<ShopOrder>
    {
        public AddressDTO Address { get; set; }

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
        public List<ShopOrderItemDTO> Items { get; set; } = new List<ShopOrderItemDTO>();
        public string? TrackingURL { get; set; }




        /// <summary>
        /// Сохраняем значение на момент применения промокода, т.к. может измениться тип промокода в будущем
        /// и подсчеты будут неверны
        /// </summary>
        public PromocodeType? UsedPromocodeType { get; set; }
        public double? DiscountByPromocode { get; set; }



        public ShopOrderReturn? Return { get; set; }


        public static ShopOrderDTO Create(ShopOrder item, int? langId, int? countryId)
        {

            var model = new ShopOrderDTO();

            model.Id = item.Id;
            model.Address = AddressDTO.CreateWithLocalization(item.Address, langId) as AddressDTO;
            model.Currency = CurrencyDTO.CreateWithLocalization(item.Currency, langId) as CurrencyDTO;


            model.Status = item.Status;

            model.TrackingURL = item.TrackingURL;

            model.UsedPromocodeType = item.UsedPromocodeType;
            model.DiscountByPromocode = item.DiscountByPromocode;

            model.Return = item.Return;

            return model;
        }
        public static List<ShopOrderDTO> CreateItems(IEnumerable<ShopOrder> items, int? langId, int? countryId)
        {
            var models = new List<ShopOrderDTO>();
            foreach (var item in items)
            {
                models.Add(Create(item, langId, countryId));
            }
            return models;
        }
    }
}

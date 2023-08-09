using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Shop.Orders;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Alfateam.Website.API.Models.ClientModels.Shop.Orders
{
    public class ShopOrderClientModel : ClientModel
    {
        public Address Address { get; set; }

        public Currency? Currency { get; set; }


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
        public List<ShopOrderItemClientModel> Items { get; set; } = new List<ShopOrderItemClientModel>();
        public string? TrackingURL { get; set; }




        /// <summary>
        /// Сохраняем значение на момент применения промокода, т.к. может измениться тип промокода в будущем
        /// и подсчеты будут неверны
        /// </summary>
        public PromocodeType? UsedPromocodeType { get; set; }
        public double? DiscountByPromocode { get; set; }



        public ShopOrderReturn? Return { get; set; }


        public static ShopOrderClientModel Create(ShopOrder item, int? langId, int? countryId)
        {

            var model = new ShopOrderClientModel();

            model.Id = item.Id;
            model.Address = item.Address;
            model.Currency = item.Currency;


            model.Status = item.Status;

            model.TrackingURL = item.TrackingURL;

            model.UsedPromocodeType = item.UsedPromocodeType;
            model.DiscountByPromocode = item.DiscountByPromocode;

            model.Return = item.Return;

            return model;
        }
        public static List<ShopOrderClientModel> CreateItems(IEnumerable<ShopOrder> items, int? langId, int? countryId)
        {
            var models = new List<ShopOrderClientModel>();
            foreach (var item in items)
            {
                models.Add(Create(item, langId, countryId));
            }
            return models;
        }
    }
}

using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Shop.Orders;
using Alfateam2._0.Models.Shop;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alfateam.Website.API.Models.ClientModels.Shop.Orders
{
    public class ShopOrderItemClientModel : ClientModel
    {
        public ShopProductClientModel Item { get; set; }
        public int ItemId { get; set; }


        public double Amount { get; set; }
        public double PriceForOne { get; set; }

        [NotMapped]
        public double Sum
        {
            get
            {
                double val = 0;
                val += Amount * PriceForOne;

                foreach (var selectedOption in SelectedModifiers.SelectMany(o => o.SelectedOptions))
                {
                    val += selectedOption.Sum * Amount;
                }

                return val;
            }

        }

        public List<ShopOrderItemModifierClientModel> SelectedModifiers { get; set; } = new List<ShopOrderItemModifierClientModel>();

    }
}

using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models.DTO.Shop.Orders;
using Alfateam.Website.API.Models.DTO.Shop;
using Alfateam2._0.Models.Shop.Orders;
using System.ComponentModel.DataAnnotations.Schema;
using Alfateam.Core.Attributes.DTO;

namespace Alfateam.Website.API.Models.DTO.Shop.Orders
{
    public class ShopOrderItemDTO : DTOModel<ShopOrderItem>
    {
        public ShopProductDTO Item { get; set; }
        public int ItemId { get; set; }


        public double Amount { get; set; }

        [ForClientOnly]
        public double PriceForOne { get; set; }

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

        public List<ShopOrderItemModifierDTO> SelectedModifiers { get; set; } = new List<ShopOrderItemModifierDTO>();
    }
}

﻿using Alfateam.Website.API.Abstractions;
using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Models.DTO.Shop.ProductModifierItems;
using Alfateam2._0.Models.Shop.Orders;

namespace Alfateam.Website.API.Models.DTO.Shop.Orders
{
    public class ShopOrderItemModifierOptionDTO : DTOModel<ShopOrderItemModifierOption>
    {
        [ForClientOnly]
        public ProductModifierItemDTO Option { get; set; }
        public int OptionId { get; set; }


        public double Amount { get; set; }

        [ForClientOnly]
        public double PriceForOne { get; set; }

        public double Sum => Amount * PriceForOne;
    }
}

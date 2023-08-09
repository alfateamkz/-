using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alfateam.Website.API.Models.ClientModels.Shop.Orders
{
    public class ShopOrderItemModifierOptionClientModel : ClientModel
    {
        public ProductModifierItemClientModel Option { get; set; }



        //public double Amount { get; set; }
        public double PriceForOne { get; set; }

        public double Sum => /*Amount **/ PriceForOne;
    }
}

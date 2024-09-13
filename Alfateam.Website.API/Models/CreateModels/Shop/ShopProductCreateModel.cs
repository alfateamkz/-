using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Shop;

namespace Alfateam.Website.API.Models.CreateModels.Shop
{
    public class ShopProductCreateModel : CreateModel<ShopProduct>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string SKU { get; set; }

        public int CategoryId { get; set; }


        public ShopProductImage MainImage { get; set; }
        //public List<ShopProductImage> Images { get; set; } = new List<ShopProductImage>();



        ///// <summary>
        ///// Стоимость без учета модификаторов
        ///// </summary>
        //public PricingMatrix BasePricing { get; set; }
        //public List<ProductModifier> Modifiers { get; set; } = new List<ProductModifier>();


        public int MainLanguageId { get; set; }
    }
}

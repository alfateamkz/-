using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Localization.Items.Shop;
using Alfateam2._0.Models.Shop.Modifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Shop
{
    /// <summary>
    /// Сущность товара в магазине
    /// </summary>
    public class ShopProduct : AbsModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string SKU { get; set; }
        public ShopProductCategory Category { get; set; }



        public ShopProductImage MainImage { get; set; }
        public List<ShopProductImage> Images { get; set; } = new List<ShopProductImage>();

       

        /// <summary>
        /// Стоимость без учета модификаторов
        /// </summary>
        public PricingMatrix BasePricing { get; set; }
        public List<ProductModifier> Modifiers { get; set; } = new List<ProductModifier>();



        public List<ShopProductLocalization> Localizations { get; set; } = new List<ShopProductLocalization>();
    }
}

using Alfateam.Models.Helpers;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Localization.Items.Shop;
using Alfateam2._0.Models.Shop.Modifiers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Shop
{
    /// <summary>
    /// Сущность товара в магазине
    /// </summary>
    public class ShopProduct : AvailabilityModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string SKU { get; set; }

        public ShopProductCategory Category { get; set; }
        public int CategoryId { get; set; }


        [NotMapped]
        public string Slug => SlugHelper.GetLatynSlug(Title);

        public ShopProductImage MainImage { get; set; }
        public List<ShopProductImage> Images { get; set; } = new List<ShopProductImage>();

       

        /// <summary>
        /// Стоимость без учета модификаторов
        /// </summary>
        public PricingMatrix BasePricing { get; set; }
        public List<ProductModifier> Modifiers { get; set; } = new List<ProductModifier>();



        public Language MainLanguage { get; set; }
        public int MainLanguageId { get; set; }
        public List<ShopProductLocalization> Localizations { get; set; } = new List<ShopProductLocalization>();
    }
}

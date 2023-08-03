using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Items.Shop
{
    public class ShopProductLocalization : LocalizableModel
    {
        public string Title { get; set; }
        public string Description { get; set; }


        /// <summary>
        /// Если UseLocalizationImages == false, то будут использоваться изображения из основной сущности
        /// </summary>
        public bool UseLocalizationImages { get; set; } = true;
        public ShopProductImage MainImage { get; set; }
        public List<ShopProductImage> Images { get; set; } = new List<ShopProductImage>();
    }
}

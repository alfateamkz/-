using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Localization.Items.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Shop
{
    /// <summary>
    /// Категория товара
    /// </summary>
    public class ShopProductCategory : AbsModel
    {
        public string Title { get; set; }



        public Language MainLanguage { get; set; }
        public int MainLanguageId { get; set; }
        public List<ShopProductCategoryLocalization> Localizations { get; set; } = new List<ShopProductCategoryLocalization>();
    }
}

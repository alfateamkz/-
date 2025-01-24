using Alfateam.Core.Helpers;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Shop;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Items.Shop
{
    public class ShopProductCategoryLocalization : LocalizableModel
    {
        public string Title { get; set; }


        [NotMapped]
        public string Slug => $"{SlugHelper.GetLatynSlug(Title)}-{ShopProductCategoryId}";


        /// <summary>
        /// Автоматическое поле
        /// Указывает на главную сущность (категорию товаров)
        /// </summary>
        public int ShopProductCategoryId { get; set; }
    }
}

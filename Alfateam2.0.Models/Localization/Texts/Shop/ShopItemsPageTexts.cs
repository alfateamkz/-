using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.Shop
{
    public class ShopItemsPageTexts : LocalizableModel
    {
        public string LastBreadcrump { get; set; } = "Мерч";

        public string Header { get; set; } = "МЕРЧ";


        public string Category { get; set; } = "Категория";

        public string PriceSortTitle { get; set; } = "Сортировка по цене";
        public string PriceSortAsc { get; set; } = "От меньшего к большему";
        public string PriceSortDesc { get; set; } = "От большего к меньшему";
        public string BtnSort { get; set; } = "Готово";
    }
}

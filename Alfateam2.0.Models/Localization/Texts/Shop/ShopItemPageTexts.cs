using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.Shop
{
    public class ShopItemPageTexts : LocalizableModel
    {
        public string MiddleBreadcrump { get; set; } = "Мерч";
        public string LastBreadcrump { get; set; } = "Товар";



        public string BtnAddToBasket { get; set; } = "Добавить";


        public string AccordionAdditionalInfo { get; set; } = "Допольнительная информация:";
        public string AccordionAdditionalInfoTitle { get; set; } = "Информация";
    }
}

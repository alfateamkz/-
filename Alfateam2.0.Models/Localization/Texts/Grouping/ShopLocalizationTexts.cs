using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Localization.Texts.Portfolio;
using Alfateam2._0.Models.Localization.Texts.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.Grouping
{
    public class ShopLocalizationTexts : LocalizableModel
    {
        public ShopLocalizationTexts() : base()
        {

        }
        public ShopLocalizationTexts(int languageId) : base(languageId)
        {
            ShopBasketPageTexts.LanguageEntityId = languageId;
            ShopDeliveryAddressPageTexts.LanguageEntityId = languageId;
            ShopItemPageTexts.LanguageEntityId = languageId;
            ShopItemsPageTexts.LanguageEntityId = languageId;
            ShopOrderNotPaidPageTexts.LanguageEntityId = languageId;
            ShopOrderPaidSuccessfullyPageTexts.LanguageEntityId = languageId;
        }


        public int WebsiteLocalizationTextsId { get; set; }


        public ShopBasketPageTexts ShopBasketPageTexts { get; set; } = new ShopBasketPageTexts();
        public ShopDeliveryAddressPageTexts ShopDeliveryAddressPageTexts { get; set; } = new ShopDeliveryAddressPageTexts();
        public ShopItemPageTexts ShopItemPageTexts { get; set; } = new ShopItemPageTexts();
        public ShopItemsPageTexts ShopItemsPageTexts { get; set; } = new ShopItemsPageTexts();
        public ShopOrderNotPaidPageTexts ShopOrderNotPaidPageTexts { get; set; } = new ShopOrderNotPaidPageTexts();
        public ShopOrderPaidSuccessfullyPageTexts ShopOrderPaidSuccessfullyPageTexts { get; set; } = new ShopOrderPaidSuccessfullyPageTexts();
    }
}

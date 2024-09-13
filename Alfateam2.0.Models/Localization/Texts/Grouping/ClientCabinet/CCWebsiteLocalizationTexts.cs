using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Localization.Texts.ClientCabinet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.Grouping.ClientCabinet
{
    public class CCWebsiteLocalizationTexts : LocalizableModel
    {

        public CCWebsiteLocalizationTexts() : base()
        {

        }
        public CCWebsiteLocalizationTexts(int languageId) : base(languageId)
        {
            CCRefLocalizationTexts = new CCRefLocalizationTexts(languageId);
            CCAuthLocalizationTexts = new CCAuthLocalizationTexts(languageId);


            CCInfoPageTexts.LanguageEntityId = languageId;
            CCMyOrdersPageTexts.LanguageEntityId = languageId;
            CCMyProjectsPageTexts.LanguageEntityId = languageId;
            CCNotificationsPageTexts.LanguageEntityId = languageId;
            CCOrderPageTexts.LanguageEntityId = languageId;
            CCProjectPageTexts.LanguageEntityId = languageId;
        }
        public int WebsiteLocalizationTextsId { get; set; }

        public CCAuthLocalizationTexts CCAuthLocalizationTexts { get; set; } = new CCAuthLocalizationTexts();
        public CCRefLocalizationTexts CCRefLocalizationTexts { get; set; } = new CCRefLocalizationTexts();





        public CCInfoPageTexts CCInfoPageTexts { get; set; } = new CCInfoPageTexts();
        public CCMyOrdersPageTexts CCMyOrdersPageTexts { get; set; } = new CCMyOrdersPageTexts();
        public CCMyProjectsPageTexts CCMyProjectsPageTexts { get; set; } = new CCMyProjectsPageTexts();
        public CCNotificationsPageTexts CCNotificationsPageTexts { get; set; } = new CCNotificationsPageTexts();
        public CCOrderPageTexts CCOrderPageTexts { get; set; } = new CCOrderPageTexts();
        public CCProjectPageTexts CCProjectPageTexts { get; set; } = new CCProjectPageTexts();
    }
}

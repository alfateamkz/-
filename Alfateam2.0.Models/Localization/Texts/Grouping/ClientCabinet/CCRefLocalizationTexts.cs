using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Localization.Texts.ClientCabinet;
using Alfateam2._0.Models.Localization.Texts.ClientCabinet.Referral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.Grouping.ClientCabinet
{
    public class CCRefLocalizationTexts : LocalizableModel
    {
        public CCRefLocalizationTexts() : base()
        {

        }

        public CCRefLocalizationTexts(int languageId) : base(languageId)
        {
            CCRefAccountPageTexts.LanguageEntityId = languageId;
            CCRefMainPageTexts.LanguageEntityId = languageId;
            CCRefMyAccountsPageTexts.LanguageEntityId = languageId;
            CCRefWithdrawalPageTexts.LanguageEntityId = languageId;
        }



        public CCRefAccountPageTexts CCRefAccountPageTexts { get; set; } = new CCRefAccountPageTexts();
        public CCRefMainPageTexts CCRefMainPageTexts { get; set; } = new CCRefMainPageTexts();
        public CCRefMyAccountsPageTexts CCRefMyAccountsPageTexts { get; set; } = new CCRefMyAccountsPageTexts();
        public CCRefWithdrawalPageTexts CCRefWithdrawalPageTexts { get; set; } = new CCRefWithdrawalPageTexts();
    }
}

using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Localization.Texts.ClientCabinet;
using Alfateam2._0.Models.Localization.Texts.ClientCabinet.Auth;
using Alfateam2._0.Models.Localization.Texts.ClientCabinet.Referral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.Grouping.ClientCabinet
{
    public class CCAuthLocalizationTexts : LocalizableModel
    {
        public CCAuthLocalizationTexts() : base()
        {

        }

        public CCAuthLocalizationTexts(int languageId) : base(languageId)
        {
            CCAuthCodeSentPageTexts.LanguageEntityId = languageId;
            CCAuthRestorePageTexts.LanguageEntityId = languageId;
            CCAuthSignInPageTexts.LanguageEntityId = languageId;
            CCAuthSignUpPageTexts.LanguageEntityId = languageId;
        }



        public CCAuthCodeSentPageTexts CCAuthCodeSentPageTexts { get; set; } = new CCAuthCodeSentPageTexts();
        public CCAuthRestorePageTexts CCAuthRestorePageTexts { get; set; } = new CCAuthRestorePageTexts();
        public CCAuthSignInPageTexts CCAuthSignInPageTexts { get; set; } = new CCAuthSignInPageTexts();
        public CCAuthSignUpPageTexts CCAuthSignUpPageTexts { get; set; } = new CCAuthSignUpPageTexts();
    }
}

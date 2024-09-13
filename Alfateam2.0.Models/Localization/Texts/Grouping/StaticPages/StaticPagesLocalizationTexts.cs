using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Localization.Texts.Grouping.ClientCabinet;
using Alfateam2._0.Models.Localization.Texts.Shop;
using Alfateam2._0.Models.Localization.Texts.StaticPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.Grouping.StaticPages
{
    public class StaticPagesLocalizationTexts : LocalizableModel
    {
        public StaticPagesLocalizationTexts() : base()
        {

        }
        public StaticPagesLocalizationTexts(int languageId) : base(languageId)
        {
            InnerLandingsLocalizationTexts = new InnerLandingsLocalizationTexts(languageId);


            AboutUsPageTexts.LanguageEntityId = languageId;
            CorporateCulturePageTexts.LanguageEntityId = languageId;
            FindMyAgreementPageTexts.LanguageEntityId = languageId;
            FraudCounteractionPageTexts.LanguageEntityId = languageId;
            LandingTexts.LanguageEntityId = languageId;
            PrivacyPolicyPageTexts.LanguageEntityId = languageId;
            ServicesListPageTexts.LanguageEntityId = languageId;
        }
        public int WebsiteLocalizationTextsId { get; set; }


        public InnerLandingsLocalizationTexts InnerLandingsLocalizationTexts { get; set; } = new InnerLandingsLocalizationTexts();




        public AboutUsPageTexts AboutUsPageTexts { get; set; } = new AboutUsPageTexts();
        public CorporateCulturePageTexts CorporateCulturePageTexts { get; set; } = new CorporateCulturePageTexts();
        public FindMyAgreementPageTexts FindMyAgreementPageTexts { get; set; } = new FindMyAgreementPageTexts();
        public FraudCounteractionPageTexts FraudCounteractionPageTexts { get; set; } = new FraudCounteractionPageTexts();
        public LandingTexts LandingTexts { get; set; } = new LandingTexts();
        public PrivacyPolicyPageTexts PrivacyPolicyPageTexts { get; set; } = new PrivacyPolicyPageTexts();
        public ServicesListPageTexts ServicesListPageTexts { get; set; } = new ServicesListPageTexts();
    }
}

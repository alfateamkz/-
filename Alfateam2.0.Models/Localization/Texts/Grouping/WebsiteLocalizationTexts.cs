using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Localization.Texts.Grouping.ClientCabinet;
using Alfateam2._0.Models.Localization.Texts.Grouping.StaticPages;
using Alfateam2._0.Models.Localization.Texts.Invest;
using Alfateam2._0.Models.Localization.Texts.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.Grouping
{
    public class WebsiteLocalizationTexts : LocalizableModel
    {

        public WebsiteLocalizationTexts() : base()
        {

        }

        public WebsiteLocalizationTexts(int languageId) : base(languageId)
        {
            CCWebsiteLocalizationTexts = new CCWebsiteLocalizationTexts(languageId);
            StaticPagesLocalizationTexts = new StaticPagesLocalizationTexts(languageId);


            HRLocalizationTexts = new HRLocalizationTexts(languageId);
            InvestLocalizationTexts = new InvestLocalizationTexts(languageId);
            PortfolioLocalizationTexts = new PortfolioLocalizationTexts(languageId);
            ShopLocalizationTexts = new ShopLocalizationTexts(languageId);
            TeamLocalizationTexts = new TeamLocalizationTexts(languageId);



            CommonTexts.LanguageEntityId = languageId;
            ComplianceTexts.LanguageEntityId = languageId;
            EventTexts.LanguageEntityId = languageId;
            MassMediaAboutUsTexts.LanguageEntityId = languageId;
            OutstaffPageTexts.LanguageEntityId = languageId;
            PartnersPageTexts.LanguageEntityId = languageId;
            PostsPageTexts.LanguageEntityId = languageId;
            ReviewsPageTexts.LanguageEntityId = languageId;
            ServicePageTexts.LanguageEntityId = languageId;
            SitemapPageTexts.LanguageEntityId = languageId;
        }


        public CCWebsiteLocalizationTexts CCWebsiteLocalizationTexts { get; set; }
        public StaticPagesLocalizationTexts StaticPagesLocalizationTexts { get; set; }



        public HRLocalizationTexts HRLocalizationTexts { get; set; }
        public InvestLocalizationTexts InvestLocalizationTexts { get; set; }
        public PortfolioLocalizationTexts PortfolioLocalizationTexts { get; set; }
        public ShopLocalizationTexts ShopLocalizationTexts { get; set; }
        public TeamLocalizationTexts TeamLocalizationTexts { get; set; }







        public CommonTexts CommonTexts { get; set; } = new CommonTexts();
        public ComplianceTexts ComplianceTexts { get; set; } = new ComplianceTexts();
        public EventTexts EventTexts { get; set; } = new EventTexts();
        public MassMediaAboutUsTexts MassMediaAboutUsTexts { get; set; } = new MassMediaAboutUsTexts();
        public OutstaffPageTexts OutstaffPageTexts { get; set; } = new OutstaffPageTexts();
        public PartnersPageTexts PartnersPageTexts { get; set; } = new PartnersPageTexts();
        public PostsPageTexts PostsPageTexts { get; set; } = new PostsPageTexts();
        public ReviewsPageTexts ReviewsPageTexts { get; set; } = new ReviewsPageTexts();
        public ServicePageTexts ServicePageTexts { get; set; } = new ServicePageTexts();
        public SitemapPageTexts SitemapPageTexts { get; set; } = new SitemapPageTexts();
    }
}

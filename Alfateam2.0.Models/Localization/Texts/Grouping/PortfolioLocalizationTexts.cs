using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Localization.Texts.Invest;
using Alfateam2._0.Models.Localization.Texts.Portfolio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.Grouping
{
    public class PortfolioLocalizationTexts : LocalizableModel
    {
        public PortfolioLocalizationTexts() : base()
        {

        }
        public PortfolioLocalizationTexts(int languageId) : base(languageId)
        {
            PortfolioItemPageTexts.LanguageEntityId = languageId;
            PortfolioListPageTexts.LanguageEntityId = languageId;
            PortfolioStatsPageTexts.LanguageEntityId = languageId;
        }


        public int WebsiteLocalizationTextsId { get; set; }


        public PortfolioItemPageTexts PortfolioItemPageTexts { get; set; } = new PortfolioItemPageTexts();
        public PortfolioListPageTexts PortfolioListPageTexts { get; set; } = new PortfolioListPageTexts();
        public PortfolioStatsPageTexts PortfolioStatsPageTexts { get; set; } = new PortfolioStatsPageTexts();
    }
}

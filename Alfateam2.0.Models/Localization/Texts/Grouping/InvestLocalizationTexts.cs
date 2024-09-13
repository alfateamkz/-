using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Localization.Texts.HR;
using Alfateam2._0.Models.Localization.Texts.Invest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.Grouping
{
    public class InvestLocalizationTexts : LocalizableModel
    {
        public InvestLocalizationTexts() : base()
        {

        }
        public InvestLocalizationTexts(int languageId) : base(languageId)
        {
            InvestProjectPageTexts.LanguageEntityId = languageId;
            InvestProjectsListPageTexts.LanguageEntityId = languageId;
        }
        public int WebsiteLocalizationTextsId { get; set; }

        public InvestProjectPageTexts InvestProjectPageTexts { get; set; } = new InvestProjectPageTexts();
        public InvestProjectsListPageTexts InvestProjectsListPageTexts { get; set; } = new InvestProjectsListPageTexts();
    }
}

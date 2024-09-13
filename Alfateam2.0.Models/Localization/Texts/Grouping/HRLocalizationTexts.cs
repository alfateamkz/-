using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Localization.Texts.ClientCabinet;
using Alfateam2._0.Models.Localization.Texts.Grouping.ClientCabinet;
using Alfateam2._0.Models.Localization.Texts.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.Grouping
{
    public class HRLocalizationTexts : LocalizableModel
    {

        public HRLocalizationTexts() : base()
        {

        }
        public HRLocalizationTexts(int languageId) : base(languageId)
        {
            HRJobVacanciesListPageTexts.LanguageEntityId = languageId;
            HRJobVacancyPageText.LanguageEntityId = languageId;
        }
        public int WebsiteLocalizationTextsId { get; set; }

        public HRJobVacanciesListPageTexts HRJobVacanciesListPageTexts { get; set; } = new HRJobVacanciesListPageTexts();
        public HRJobVacancyPageText HRJobVacancyPageText { get; set; } = new HRJobVacancyPageText();
    }
}

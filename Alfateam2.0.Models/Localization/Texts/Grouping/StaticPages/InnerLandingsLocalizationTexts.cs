using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Localization.Texts.Portfolio;
using Alfateam2._0.Models.Localization.Texts.StaticPages.InnerLandings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.Grouping.StaticPages
{
    public class InnerLandingsLocalizationTexts : LocalizableModel
    {

        public InnerLandingsLocalizationTexts() :base()
        {

        }
        public InnerLandingsLocalizationTexts(int languageId) : base(languageId)
        {
            ILQualityAndPipelinePageTexts.LanguageEntityId = languageId;
            ILRefProgramPageTexts.LanguageEntityId = languageId;
            ILWorkWithUsPageTexts.LanguageEntityId = languageId;
        }


        public ILQualityAndPipelinePageTexts ILQualityAndPipelinePageTexts { get; set; } = new ILQualityAndPipelinePageTexts();
        public ILRefProgramPageTexts ILRefProgramPageTexts { get; set; } = new ILRefProgramPageTexts();
        public ILWorkWithUsPageTexts ILWorkWithUsPageTexts { get; set; } = new ILWorkWithUsPageTexts();
    }
}

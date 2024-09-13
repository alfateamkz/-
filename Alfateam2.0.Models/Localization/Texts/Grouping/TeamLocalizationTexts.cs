using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Localization.Texts.HR;
using Alfateam2._0.Models.Localization.Texts.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.Grouping
{
    public class TeamLocalizationTexts : LocalizableModel
    {

        public TeamLocalizationTexts() : base()
        {

        }
        public TeamLocalizationTexts(int languageId) : base(languageId)
        {
            TeamMemberPageTexts.LanguageEntityId = languageId;
            TeamPageTexts.LanguageEntityId = languageId;
        }


        public int WebsiteLocalizationTextsId { get; set; }

        public TeamMemberPageTexts TeamMemberPageTexts { get; set; } = new TeamMemberPageTexts();
        public TeamPageTexts TeamPageTexts { get; set; } = new TeamPageTexts();
    }
}

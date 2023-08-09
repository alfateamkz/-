using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Localization.Items.Team;

namespace Alfateam.Website.API.Models.LocalizationEditModels.Team
{
    public class TeamGroupLocalizationEditModel : LocalizationEditModel<TeamGroupLocalization>
    {
        public string Title { get; set; }
    }
}

using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Localization.Items.Team;

namespace Alfateam.Website.API.Models.DTOLocalization.Team
{
    public class TeamGroupLocalizationDTO : DTOModel<TeamGroupLocalization>
    {
        public string Title { get; set; }
    }
}

using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.ContentItems;
using Alfateam2._0.Models.Localization.Items.Team;

namespace Alfateam.Website.API.Models.DTOLocalization.Team
{
    public class TeamMemberLocalizationDTO : LocalizationDTOModel<TeamMemberLocalization>
    {
        public string Name { get; set; }
        public string Surname { get; set; }


        public string Position { get; set; }
        public string ShortExpierence { get; set; }
        public string Quote { get; set; }


        public Content DetailContent { get; set; }
        public string? CVFilepath { get; set; }
    }
}

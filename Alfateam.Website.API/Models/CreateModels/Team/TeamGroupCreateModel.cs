using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Team;

namespace Alfateam.Website.API.Models.CreateModels.Team
{
    public class TeamGroupCreateModel : CreateModel<TeamGroup>
    {
        public string Title { get; set; }

        public int MainLanguageId { get; set; }
    }
}

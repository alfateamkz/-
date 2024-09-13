using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models.DTO.Team;
using Alfateam2._0.Models.Team;

namespace Alfateam.Website.API.Models.DTO.Team
{
    public class TeamGroupDTO : DTOModel<TeamGroup>
    {
        public string Title { get; set; }
        public List<TeamMemberDTO> Members { get; set; } = new List<TeamMemberDTO>();

        public int MainLanguageId { get; set; }
    }
}

using Alfateam.Website.API.Abstractions;
using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Models.DTO.Team;
using Alfateam2._0.Models.Team;

namespace Alfateam.Website.API.Models.DTO.Team
{
    public class TeamGroupDTO : DTOModel<TeamGroup>
    {
        public string Title { get; set; }
        public List<TeamMemberDTO> Members { get; set; } = new List<TeamMemberDTO>();


        [DTOFieldFor(DTOFieldForType.CreationOnly)]
        public int TeamStructureId { get; set; }

        public int MainLanguageId { get; set; }
    }
}

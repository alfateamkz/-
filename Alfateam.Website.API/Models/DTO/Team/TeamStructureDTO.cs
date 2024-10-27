using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models.DTO.Team;
using Alfateam2._0.Models.Team;

namespace Alfateam.Website.API.Models.DTO.Team
{
    public class TeamStructureDTO : AvailabilityDTOModel<TeamStructure>
    {
        public string Title { get; set; }

        [ForClientOnly]
        public List<TeamGroupDTO> Groups { get; set; } = new List<TeamGroupDTO>();
    }
}

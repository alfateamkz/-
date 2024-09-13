using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Extensions;
using Alfateam.Website.API.Models.DTO.Team;
using Alfateam2._0.Models.Team;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Website.API.Controllers.Website
{

    public class TeamController : AbsController
    {
        public TeamController(WebsiteDBContext db) : base(db)
        {
        }


        [HttpGet, Route("GetTeam")]
        public async Task<TeamStructureDTO> GetTeam()
        {
            var team = DB.TeamStructures.IncludeAvailability()
                                        .Include(o => o.Groups).ThenInclude(o => o.Members)
                                        .Include(o => o.Groups).ThenInclude(o => o.Localizations)
                                        .Include(o => o.Groups).ThenInclude(o => o.MainLanguage)
                                        .Include(o => o.Groups).ThenInclude(o => o.Members).ThenInclude(o => o.Localizations)
                                        .Include(o => o.Groups).ThenInclude(o => o.Members).ThenInclude(o => o.MainLanguage)
                                        .FirstOrDefault(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId));
            return TeamStructureDTO.CreateWithLocalization(team, LanguageId) as TeamStructureDTO;
        }

        [HttpGet, Route("GetTeamMember")]
        public async Task<TeamMemberDTO> GetTeamMember(int id)
        {
            var member = DB.TeamMembers.Include(o => o.DetailContent).ThenInclude(o => o.Items)
                                       .Include(o => o.Localizations).ThenInclude(o => o.DetailContent).ThenInclude(o => o.Items)
                                       .Include(o => o.MainLanguage)
                                       .FirstOrDefault(o => o.Id == id);
            return TeamMemberDTO.CreateWithLocalization(member, LanguageId) as TeamMemberDTO;
        }
    }
}

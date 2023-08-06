using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Extensions;
using Alfateam.Website.API.Models.ClientModels.Team;
using Alfateam2._0.Models.Team;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Website.API.Controllers.Website
{

    //TODO: в целом проверить инклюды локализаций и прочего

    public class TeamController : AbsController
    {
        public TeamController(WebsiteDBContext db) : base(db)
        {
        }


        [HttpGet, Route("GetTeam")]
        public async Task<TeamStructureClientModel> GetTeam()
        {
            var team = DB.TeamStructures.IncludeAvailability()
                                        .Include(o => o.Groups).ThenInclude(o => o.Members)
                                        .Include(o => o.Groups).ThenInclude(o => o.Localizations)
                                        .Include(o => o.Groups).ThenInclude(o => o.MainLanguage)
                                        .Include(o => o.Groups).ThenInclude(o => o.Members).ThenInclude(o => o.Localizations)
                                        .Include(o => o.Groups).ThenInclude(o => o.Members).ThenInclude(o => o.MainLanguage)
                                        .FirstOrDefault(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId));
            return TeamStructureClientModel.Create(team, LanguageId);
        }

        [HttpGet, Route("GetTeamMember")]
        public async Task<TeamMemberClientModel> GetTeamMember(int id)
        {
            var member = DB.TeamMembers.Include(o => o.DetailContent).ThenInclude(o => o.Items)
                                       .Include(o => o.Localizations).ThenInclude(o => o.DetailContent).ThenInclude(o => o.Items)
                                       .Include(o => o.MainLanguage)
                                       .FirstOrDefault(o => o.Id == id);
            return TeamMemberClientModel.Create(member, LanguageId);
        }
    }
}

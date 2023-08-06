using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
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
            //TODO: сделать получение команды в зависимости от страны, а также локализации

            var team = DB.TeamStructures.Include(o => o.Groups).ThenInclude(o => o.Members)
                                        .FirstOrDefault(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId));
            return TeamStructureClientModel.Create(team, LanguageId);
        }

        [HttpGet, Route("GetTeamMember")]
        public async Task<TeamMemberClientModel> GetTeamMember(int id)
        {
            var member = DB.TeamMembers.Include(o => o.DetailContent).ThenInclude(o => o.Items)
                                       .FirstOrDefault(o => o.Id == id);
            return TeamMemberClientModel.Create(member, LanguageId);
        }
    }
}

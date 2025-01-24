using Alfateam.Administration.Models.DTO.Stats;
using Alfateam.ForPubilcWebsites.API.Abstractions;
using Alfateam.ForPubilcWebsites.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.ForPubilcWebsites.API.Controllers
{
    public class StatsController : AbsController
    {
        public StatsController(ControllerParams @params) : base(@params)
        {
        }

        [HttpPut, Route("AddSiteVisit")]
        public async Task AddSiteVisit(WebsiteVisitDTO model)
        {
            model.VisitedByIdentifier = this.AlfateamUser?.Guid;
            DBService.TryCreateEntity(AdmininstrationDb.WebsiteVisits, model);
        }
    }
}

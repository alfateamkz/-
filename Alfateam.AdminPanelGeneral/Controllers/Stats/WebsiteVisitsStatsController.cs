using Alfateam.Administration.Models.DTO.Stats;
using Alfateam.Administration.Models.Stats;
using Alfateam.AdminPanelGeneral.API.Abstractions;
using Alfateam.AdminPanelGeneral.API.Models;
using Alfateam.AdminPanelGeneral.API.Models.Filters.Stats;
using Alfateam.AdminPanelGeneral.API.Models.Stats;
using Alfateam.Core;
using Alfateam2._0.Models.Stats;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.AdminPanelGeneral.API.Controllers.Stats
{
    public class WebsiteVisitsStatsController : AbsController
    {
        public WebsiteVisitsStatsController(ControllerParams @params) : base(@params)
        {
        }

        [HttpGet, Route("GetVisits")]
        public async Task<ItemsWithTotalCount<WebsiteVisitDTO>> GetVisits([FromQuery] WebsiteVisitsSearchFilter filter)
        {
            var allVisits = AdmininstrationDb.WebsiteVisits.Where(o => o.VisitedAt >= filter.From && o.VisitedAt <= filter.To);

            return DBService.GetManyWithTotalCount<WebsiteVisit, WebsiteVisitDTO>(allVisits, filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Fingerprint.Contains(filter.Query, StringComparison.OrdinalIgnoreCase)
                        || entity.IP.Contains(filter.Query, StringComparison.OrdinalIgnoreCase)
                        || entity.URL.Contains(filter.Query, StringComparison.OrdinalIgnoreCase)
                        || entity.UserAgent.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetVisitsByDay")]
        public async Task<IEnumerable<VisitsByDay>> GetVisitsByDay(DateTime from, DateTime to)
        {
            var allVisits = AdmininstrationDb.WebsiteVisits.Where(o => o.VisitedAt >= from && o.VisitedAt <= to);
            var grouped = allVisits.GroupBy(o => o.VisitedAt.Date);

            var visits = new List<VisitsByDay>();
            foreach (var group in grouped)
            {
                visits.Add(new VisitsByDay
                {
                    Date = group.Key,
                    Count = group.Count()
                });
            }


            return visits;
        }
    }
}

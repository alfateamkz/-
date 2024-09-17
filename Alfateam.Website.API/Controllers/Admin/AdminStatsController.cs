using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Core;
using Alfateam.Website.API.Models;
using Alfateam.Website.API.Models.DTO.Portfolios;
using Alfateam.Website.API.Models.DTO.Reviews;
using Alfateam.Website.API.Models.DTO.Stats;
using Alfateam.Website.API.Models.Filters.Admin;
using Alfateam.Website.API.Models.Stats;
using Alfateam2._0.Models.Reviews;
using Alfateam2._0.Models.Stats;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.Website.API.Controllers.Admin
{
    public class AdminStatsController : AbsAdminController
    {
        public AdminStatsController(ControllerParams @params) : base(@params)
        {
        }

        [HttpGet, Route("GetVisits")]
        public async Task<IEnumerable<SiteVisitDTO>> GetVisits(SiteVisitFilter filter)
        {
            var allVisits = DB.SiteVisits.Where(o => o.VisitedAt >= filter.From && o.VisitedAt <= filter.To);

            if (!string.IsNullOrEmpty(filter.IP))
            {
                allVisits = allVisits.Where(o => o.IP == filter.IP);
            }

            if (filter.CountryId != null)
            {
                allVisits = allVisits.Where(o => o.CountryId == filter.CountryId);
            }

            if (!string.IsNullOrEmpty(filter.Fingerprint))
            {
                allVisits = allVisits.Where(o => o.Fingerprint == filter.Fingerprint);
            }

            var items = allVisits.Skip(filter.Offset).Take(filter.Count).ToList();
            return new SiteVisitDTO().CreateDTOs(items).Cast<SiteVisitDTO>();
        }

        [HttpGet, Route("GetVisitsByDay")]
        public async Task<List<VisitsByDay>> GetVisits(DateTime from,DateTime to)
        {
            var allVisits = DB.SiteVisits.Where(o => o.VisitedAt >= from && o.VisitedAt <= to);
            var grouped = allVisits.GroupBy(o => o.VisitedAt.Date);

            var visits = new List<VisitsByDay>();
            foreach(var group in grouped)
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

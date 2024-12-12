using Alfateam.Core;
using Alfateam.Marketing.API.Abstractions;
using Alfateam.Marketing.API.Models;
using Alfateam.Marketing.API.Models.DTO.Websites;
using Alfateam.Marketing.API.Models.DTO.Websites.Stats;
using Alfateam.Marketing.API.Models.SearchFilters.Websites;
using Alfateam.Marketing.Models.Websites;
using Alfateam.Marketing.Models.Websites.Stats;
using Microsoft.AspNetCore.Mvc;
using WebsiteModel = Alfateam.Marketing.Models.Websites.Website;


namespace Alfateam.Marketing.API.Controllers.Websites
{
    public class WebsiteStatsController : AbsController
    {
        public WebsiteStatsController(ControllerParams @params) : base(@params)
        {
        }


        #region Статистика по сайтам

        [HttpGet, Route("GetWebsitePingStats")]
        public async Task<ItemsWithTotalCount<WebsiteOnlineInfoDTO>> GetWebsitePingStats(WebsitePingStatsSearchFilter filter)
        {
            var website = DBService.TryGetOne(GetAvailableWebsites(), filter.WebsiteId);

            var period = filter.Period.GetPeriod();
            var pingItems = DB.WebsiteOnlineInfo.Where(o => o.WebsiteId == filter.WebsiteId && o.CreatedAt >= period.From && o.CreatedAt <= period.To);

            return DBService.GetManyWithTotalCount<WebsiteOnlineInfo, WebsiteOnlineInfoDTO>(pingItems, filter.Offset, filter.Count);
        }


        #endregion










        #region Private methods

        private IEnumerable<WebsiteModel> GetAvailableWebsites()
        {
            return DB.Websites.Where(o => !o.IsDeleted && o.BusinessCompanyId == CompanyId);
        }


        #endregion
    }
}

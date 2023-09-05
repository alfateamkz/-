using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.ClientModels.General;
using Alfateam.CRM2_0.Models.EditModels.General;
using Alfateam.CRM2_0.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using TimeZone = Alfateam.CRM2_0.Models.General.TimeZone;

namespace Alfateam.CRM2_0.Controllers.Core
{
    public class TimeZonesController : AbsController
    {
        public TimeZonesController(ControllerParams @params) : base(@params)
        {
        }

        #region Часовые пояса

        [HttpGet, Route("GetTimezones")]
        public async Task<RequestResult> GetTimezones(int offset, int count = 20)
        {
            return GetMany<TimeZone, TimeZoneClientModel>(DB.TimeZones, offset, count);
        }

        [HttpGet, Route("GetTimezone")]
        [AccessActionFilter(roles: UserRole.President)]
        public async Task<RequestResult> GetTimezone(int id)
        {
            return TryGetModel(DB.TimeZones, id);
        }


        [HttpPost, Route("CreateTimezone")]
        [AccessActionFilter(roles: UserRole.President)]
        public async Task<RequestResult> CreateTimezone(TimeZoneEditModel model)
        {
            return TryCreateModel(DB.TimeZones, model);
        }


        [HttpPut, Route("UpdateTimezone")]
        [AccessActionFilter(roles: UserRole.President)]
        public async Task<RequestResult> UpdateTimezone(TimeZoneEditModel model)
        {
            return TryUpdateModel(DB.TimeZones, model);
        }

        [HttpDelete, Route("DeleteTimezone")]
        [AccessActionFilter(roles: UserRole.President)]
        public async Task<RequestResult> DeleteTimezone(int id)
        {
            return TryDeleteModel(DB.TimeZones, id);
        }

        #endregion
    }
}

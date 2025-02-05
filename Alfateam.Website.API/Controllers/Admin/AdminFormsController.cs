using Alfateam.Core;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models;
using Alfateam.Website.API.Models.DTO.Stats;
using Alfateam.Website.API.Models.Filters.Admin;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.Stats;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.Website.API.Controllers.Admin
{
    public class AdminFormsController : AbsAdminController
    {
        public AdminFormsController(ControllerParams @params) : base(@params)
        {
        }

        [HttpGet, Route("GetForms")]
        public async Task<ItemsWithTotalCount<SentFromWebsiteFormDTO>> GetForms([FromQuery] SentFormsFilter filter)
        {
            var forms = DB.SentFromWebsiteForms.Where(o => o.CreatedAt >= filter.From && o.CreatedAt <= filter.To);

            if (!string.IsNullOrEmpty(filter.IP))
            {
                forms = forms.Where(o => o.IP == filter.IP);
            }

            if (!string.IsNullOrEmpty(filter.Fingerprint))
            {
                forms = forms.Where(o => o.Fingerprint == filter.Fingerprint);
            }

            if (filter.Status != null)
            {
                forms = forms.Where(o => o.Status == filter.Status);
            }

            return DbService.GetManyWithTotalCount<SentFromWebsiteForm, SentFromWebsiteFormDTO>(forms, filter.Offset, filter.Count);
        }


        [HttpPut, Route("SetFormHandlingStatus")]
        public async Task SetFormHandlingStatus(int formId, SentFromWebsiteFormHandlingStatus status)
        {
            var form = DbService.TryGetOne(DB.SentFromWebsiteForms, formId);

            form.Status = status;
            DbService.UpdateEntity(DB.SentFromWebsiteForms, form);
        }
    }
}

using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.ClientModels.General;
using Alfateam.CRM2_0.Models.EditModels.Content.Events;
using Alfateam.CRM2_0.Models.EditModels.General;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.General;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.CRM2_0.Controllers.Core
{
    public class CountriesController : AbsController
    {
        public CountriesController(ControllerParams @params) : base(@params)
        {
        }

        #region Страны
          
        [HttpGet, Route("GetCountries")]
        public async Task<RequestResult> GetCountries(int offset, int count = 20)
        {
            return GetMany<Country, CountryClientModel>(DB.Countries, offset, count);
        }

        [HttpGet, Route("GetCountry")]
        [AccessActionFilter(roles: UserRole.President)]
        public async Task<RequestResult> GetCountry(int id)
        {
            return TryGetModel(DB.Countries, id);
        }


        [HttpPost, Route("CreateCountry")]
        [AccessActionFilter(roles: UserRole.President)]
        public async Task<RequestResult> CreateCountry(CountryEditModel model)
        {
            return TryCreateModel(DB.Countries, model);
        }


        [HttpPut, Route("UpdateCountry")]
        [AccessActionFilter(roles: UserRole.President)]
        public async Task<RequestResult> UpdateCountry(CountryEditModel model)
        {
            return TryUpdateModel(DB.Countries, model);
        }

        [HttpDelete, Route("DeleteCountry")]
        [AccessActionFilter(roles: UserRole.President)]
        public async Task<RequestResult> DeleteCountry(int id)
        {
            return TryDeleteModel(DB.Countries, id);
        }

        #endregion



 
    }
}

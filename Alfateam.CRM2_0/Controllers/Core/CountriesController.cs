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

        #region Правовые формы контрагентов



        [HttpGet, Route("GetLegalForms")]
        public async Task<RequestResult> GetLegalForms(int countryId, int offset, int count = 20)
        {
            return GetMany<LegalForm, LegalFormClientModel>(DB.LegalForms.Where(o => o.CountryId == countryId), offset, count);
        }


        [HttpGet, Route("GetLegalForm")]
        [AccessActionFilter(roles: UserRole.President)]
        public async Task<RequestResult> GetLegalForm(int id)
        {
            return TryGetModel(DB.LegalForms, id);
        }


        [HttpPost, Route("CreateCountry")]
        [AccessActionFilter(roles: UserRole.President)]
        public async Task<RequestResult> CreateLegalForm(int countryId, LegalFormEditModel model)
        {
            var country = DB.Countries.FirstOrDefault(o => o.Id == countryId && o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(country != null, 404, "Сущность с данным id не найдена"),
                () => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
                () =>
                {
                    var item = model.Create();
                    country.LegalForms.Add(item);
                    return UpdateModel(DB.Countries, country);
                }
            });
        }


        [HttpPut, Route("UpdateLegalForm")]
        [AccessActionFilter(roles: UserRole.President)]
        public async Task<RequestResult> UpdateLegalForm(LegalFormEditModel model)
        {
            return TryUpdateModel(DB.LegalForms, model);
        }

        [HttpDelete, Route("DeleteLegalForm")]
        [AccessActionFilter(roles: UserRole.President)]
        public async Task<RequestResult> DeleteLegalForm(int id)
        {
            return TryDeleteModel(DB.LegalForms, id);
        }
        #endregion

        #region Системы налогообложения


        #endregion
    }
}

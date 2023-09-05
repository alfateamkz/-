using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.ClientModels.General;
using Alfateam.CRM2_0.Models.EditModels.General;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.General;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.CRM2_0.Controllers.Core
{
    public class LegalFormsController : AbsController
    {
        public LegalFormsController(ControllerParams @params) : base(@params)
        {
        }

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
    }
}

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
    public class CurrenciesController : AbsController
    {
        public CurrenciesController(ControllerParams @params) : base(@params)
        {
        }

        #region Валюты

        [HttpGet, Route("GetCurrencies")]
        public async Task<RequestResult> GetCurrencies(int offset, int count = 20)
        {
            return GetMany<Currency, CurrencyClientModel>(DB.Currencies, offset, count);
        }

        [HttpGet, Route("GetCurrency")]
        [AccessActionFilter(roles: UserRole.President)]
        public async Task<RequestResult> GetCountry(int id)
        {
            return TryGetModel(DB.Currencies, id);
        }


        [HttpPost, Route("CreateCurrency")]
        [AccessActionFilter(roles: UserRole.President)]
        public async Task<RequestResult> CreateCurrency(CurrencyEditModel model)
        {
            return TryCreateModel(DB.Currencies, model);
        }


        [HttpPut, Route("UpdateCurrency")]
        [AccessActionFilter(roles: UserRole.President)]
        public async Task<RequestResult> UpdateCurrency(CurrencyEditModel model)
        {
            return TryUpdateModel(DB.Currencies, model);
        }

        [HttpDelete, Route("DeleteCurrency")]
        [AccessActionFilter(roles: UserRole.President)]
        public async Task<RequestResult> DeleteCurrency(int id)
        {
            return TryDeleteModel(DB.Currencies, id);
        }

        #endregion
    }
}

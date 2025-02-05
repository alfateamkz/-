using Alfateam.AdminPanelGeneral.API.Abstractions;
using Alfateam.AdminPanelGeneral.API.Models;
using Alfateam.Core;
using Alfateam.Sales.API.Models.DTO.General;
using Alfateam.Sales.Models.General;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.AdminPanelGeneral.API.Controllers.Products.Sales
{
    [Route("Products/Sales/[controller]")]
    public class SalesCurrenciesController : AbsController
    {
        public SalesCurrenciesController(ControllerParams @params) : base(@params)
        {
        }

        #region Валюты

        [HttpGet, Route("GetCurrencies")]
        public async Task<ItemsWithTotalCount<CurrencyDTO>> GetCurrencies([FromQuery] SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<Currency, CurrencyDTO>(GetAvailableCurrencies(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;

                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition &= entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }

                return condition;
            });
        }

        [HttpGet, Route("GetCurrency")]
        public async Task<CurrencyDTO> GetCurrency(int id)
        {
            return (CurrencyDTO)DBService.TryGetOne(GetAvailableCurrencies(), id, new CurrencyDTO());
        }


        [HttpPost, Route("CreateCurrency")]
        public async Task<CurrencyDTO> CreateCurrency(CurrencyDTO model)
        {
            return (CurrencyDTO)DBService.TryCreateEntity(SalesDb.Currencies, model);
        }

        [HttpPut, Route("UpdateCurrency")]
        public async Task<CurrencyDTO> UpdateCurrency(CurrencyDTO model)
        {
            var group = DBService.TryGetOne(GetAvailableCurrencies(), model.Id);
            return (CurrencyDTO)DBService.TryUpdateEntity(SalesDb.Currencies, model, group);
        }


        [HttpDelete, Route("DeleteCurrency")]
        public async Task DeleteCurrency(int id)
        {
            var group = DBService.TryGetOne(GetAvailableCurrencies(), id);
            DBService.TryDeleteEntity(SalesDb.Currencies, group);
        }

        #endregion









        #region Private methods
        private IEnumerable<Currency> GetAvailableCurrencies()
        {
            return SalesDb.Currencies.Where(o => !o.IsDeleted);
        }


        #endregion
    }
}

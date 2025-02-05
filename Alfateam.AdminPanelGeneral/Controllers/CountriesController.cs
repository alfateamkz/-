using Alfateam.Administration.Models.DTO.General;
using Alfateam.Administration.Models.General;
using Alfateam.AdminPanelGeneral.API.Abstractions;
using Alfateam.AdminPanelGeneral.API.Models;
using Alfateam.Core;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.AdminPanelGeneral.API.Controllers
{
    public class CountriesController : AbsController
    {
        public CountriesController(ControllerParams @params) : base(@params)
        {
        }

        #region Языки

        [HttpGet, Route("GetCountries")]
        public async Task<ItemsWithTotalCount<CountryDTO>> GetCountries(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<Country, CountryDTO>(GetAvailableCountries(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;

                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition = entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }

                return condition;
            });
        }

        [HttpGet, Route("GetCountry")]
        public async Task<CountryDTO> GetCountry(int id)
        {
            return (CountryDTO)DBService.TryGetOne(GetAvailableCountries(), id, new CountryDTO());
        }






        [HttpPost, Route("CreateCountry")]
        public async Task<CountryDTO> CreateCountry(CountryDTO model)
        {
            return (CountryDTO)DBService.TryCreateEntity(AdmininstrationDb.Countries, model,
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление языка", $"Добавлен язык {entity.Title}");
            });
        }

        [HttpPut, Route("UpdateCountry")]
        public async Task<CountryDTO> UpdateCountry(CountryDTO model)
        {
            var item = GetAvailableCountries().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (CountryDTO)DBService.TryUpdateEntity(AdmininstrationDb.Countries, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование языка", $"Отредактирован язык с id={item.Id}");
            });
        }

        [HttpDelete, Route("DeleteCountry")]
        public async Task DeleteCountry(int id)
        {
            var item = GetAvailableCountries().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(AdmininstrationDb.Countries, item);

            this.AddHistoryAction("Удаление языка", $"Удален язык {item.Title} с id={id}");
        }



        #endregion









        #region Private methods
        private IEnumerable<Country> GetAvailableCountries()
        {
            return AdmininstrationDb.Countries.Where(o => !o.IsDeleted);
        }

        #endregion
    }
}

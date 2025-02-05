using Alfateam.AdminPanelGeneral.API.Abstractions;
using Alfateam.AdminPanelGeneral.API.Models;
using Alfateam.Core;
using Alfateam.Telephony.API.Models.DTO.General;
using Alfateam.Telephony.Models.General;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.AdminPanelGeneral.API.Controllers.Products.Telephony
{
    [Route("Products/Telephony/[controller]")]
    public class TelephonyCountriesController : AbsController
    {
        public TelephonyCountriesController(ControllerParams @params) : base(@params)
        {
        }

        #region Страны

        [HttpGet, Route("GetCountries")]
        public async Task<ItemsWithTotalCount<CountryDTO>> GetCountries([FromQuery] SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<Country, CountryDTO>(GetAvailableCountries(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;

                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition &= entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
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
            return (CountryDTO)DBService.TryCreateEntity(TelephonyDb.Countries, model);
        }

        [HttpPut, Route("UpdateCountry")]
        public async Task<CountryDTO> UpdateCountry(CountryDTO model)
        {
            var group = DBService.TryGetOne(GetAvailableCountries(), model.Id);
            return (CountryDTO)DBService.TryUpdateEntity(TelephonyDb.Countries, model, group);
        }


        [HttpDelete, Route("DeleteCountry")]
        public async Task DeleteCountry(int id)
        {
            var group = DBService.TryGetOne(GetAvailableCountries(), id);
            DBService.TryDeleteEntity(TelephonyDb.Countries, group);
        }

        #endregion









        #region Private methods
        private IEnumerable<Country> GetAvailableCountries()
        {
            return TelephonyDb.Countries.Where(o => !o.IsDeleted);
        }


        #endregion
    }
}

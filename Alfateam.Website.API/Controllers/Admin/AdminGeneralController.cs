﻿using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Core;
using Alfateam.Website.API.Extensions;
using Alfateam.Website.API.Helpers;
using Alfateam.Website.API.Models.DTO.General;
using Alfateam.Website.API.Models.DTO.Events;
using Alfateam.Website.API.Models.DTOLocalization.General;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Localization.General;
using Alfateam2._0.Models.Localization.Items.Events;
using Alfateam2._0.Models.Shop;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Alfateam.Website.API.Models;
using Alfateam.Website.API.Models.DTOLocalization.Events;
using Alfateam.Website.API.Filters;
using Alfateam.Website.API.Filters.Access;
using Alfateam.Core.Enums;
using Alfateam.Core.Exceptions;
using Alfateam2._0.Models.ContentItems;
using Swashbuckle.AspNetCore.Annotations;
using Alfateam.Website.API.Models.DTO;
using Alfateam2._0.Models;
using Alfateam.Core;
using Alfateam.Website.API.Models.DTO.HR;

namespace Alfateam.Website.API.Controllers.Admin
{
    public class AdminGeneralController : AbsAdminController
    {

        public AdminGeneralController(ControllerParams @params) : base(@params)
        {
        }

        #region Страны


        [HttpGet, Route("GetCountries")]
        public async Task<ItemsWithTotalCount<CountryDTO>> GetCountries(int offset, int count = 20)
        {
            return DbService.GetManyWithTotalCount<Country, CountryDTO>(GetCountriesList(), offset, count);
        }
        [HttpGet, Route("GetCountriesFiltered")]
        public async Task<ItemsWithTotalCount<CountryDTO>> GetCountriesFiltered([FromQuery] SearchFilter filter)
        {
            return DbService.GetManyWithTotalCount<Country, CountryDTO>(GetCountriesList(), filter.Offset, filter.Count, (entity) =>
            {
                return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
            });
        }


        [HttpGet, Route("GetCountry")]
        public async Task<CountryDTO> GetCountry(int id)
        {
            return (CountryDTO)DbService.TryGetOne(GetCountriesList(), id, new CountryDTO());
        }

        [HttpGet, Route("GetCountryLocalizations")]
        public async Task<IEnumerable<CountryLocalizationDTO>> GetCountryLocalizations(int id)
        {
            var localizations = DB.CountryLocalizations.Include(o => o.LanguageEntity).Where(o => o.CountryId == id && !o.IsDeleted);
            var mainEntity = GetCountriesList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            return DbService.GetLocalizationModels(localizations, mainEntity, new CountryLocalizationDTO()).Cast<CountryLocalizationDTO>();
        }

        [HttpGet, Route("GetCountryLocalization")]
        public async Task<CountryLocalizationDTO> GetCountryLocalization(int id)
        {
            var localization = DB.CountryLocalizations.Include(o => o.LanguageEntity).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainEntity = GetCountriesList().FirstOrDefault(o => o.Id == localization?.CountryId && !o.IsDeleted);

            return (CountryLocalizationDTO)DbService.GetLocalizationModel(localization, mainEntity, new CountryLocalizationDTO());
        }




        [HttpPost, Route("CreateCountry")]
        [CheckContentAreaRights(ContentAccessModelType.General, 4)]
        public async Task<CountryDTO> CreateCountry(CountryDTO model)
        {
            return (CountryDTO)DbService.TryCreateEntity(DB.Countries, model);
        }
      
        [HttpPost, Route("CreateCountryLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.General, 3)]
        public async Task<CountryLocalizationDTO> CreateCountryLocalization(int itemId, CountryLocalizationDTO localization)
        {
            var mainEntity = GetCountriesList().FirstOrDefault(o => o.Id == itemId);
            return (CountryLocalizationDTO)DbService.TryCreateLocalizationEntity(DB.Countries, mainEntity, localization);
        }





        [HttpPut, Route("UpdateCountryMain")]
        [CheckContentAreaRights(ContentAccessModelType.General, 3)]
        public async Task<CountryDTO> UpdateCountryMain(CountryDTO model)
        {
            var item = GetCountriesList().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (CountryDTO)DbService.TryUpdateEntity(DB.Countries, model, item);
        }
     
        [HttpPut, Route("UpdateCountryLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.General, 3)]
        public async Task<CountryLocalizationDTO> UpdateCountryLocalization(CountryLocalizationDTO model)
        {
            var localization = DB.CountryLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            var mainEntity = GetCountriesList().FirstOrDefault(o => o.Id == localization.CountryId && !o.IsDeleted);

            return (CountryLocalizationDTO)DbService.TryUpdateLocalizationEntity(DB.CountryLocalizations, localization, model, mainEntity);
        }





        [HttpDelete, Route("DeleteCountry")]
        [CheckContentAreaRights(ContentAccessModelType.General, 5)]
        public async Task DeleteCountry(int id)
        {
            var item = GetCountriesList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DbService.TryDeleteEntity(DB.Countries, item);
        }

        [HttpDelete, Route("DeleteCountryLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.General, 5)]
        public async Task DeleteCountryLocalization(int id)
        {
            var item = DB.CountryLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainModel = DB.Countries.FirstOrDefault(o => o.Id == item.CountryId && !o.IsDeleted);

            DbService.TryDeleteLocalizationEntity(DB.CountryLocalizations, item, mainModel);
        }

        #endregion

        #region Языки


        [HttpGet, Route("GetLanguages")]
        public async Task<ItemsWithTotalCount<LanguageDTO>> GetLanguages(int offset, int count = 20)
        {
            return DbService.GetManyWithTotalCount<Language, LanguageDTO>(GetLanguagesList(), offset, count);
        }
        [HttpGet, Route("GetLanguagesFiltered")]
        public async Task<ItemsWithTotalCount<LanguageDTO>> GetLanguagesFiltered([FromQuery] SearchFilter filter)
        {
            return DbService.GetManyWithTotalCount<Language, LanguageDTO>(GetLanguagesList(), filter.Offset, filter.Count, (entity) =>
            {
                return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
            });
        }

        [HttpGet, Route("GetLanguage")]
        public async Task<LanguageDTO> GetLanguage(int id)
        {
            return (LanguageDTO)DbService.TryGetOne(GetLanguagesList(), id, new LanguageDTO());
        }


        [HttpGet, Route("GetLanguageLocalizations")]
        public async Task<IEnumerable<LanguageLocalizationDTO>> GetLanguageLocalizations(int id)
        {
            var localizations = DB.LanguageLocalizations.Include(o => o.LanguageEntity).Where(o => o.LanguageMainModelId == id && !o.IsDeleted);
            var mainEntity = GetLanguagesList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            return DbService.GetLocalizationModels(localizations, mainEntity, new LanguageLocalizationDTO()).Cast<LanguageLocalizationDTO>();
        }

        [HttpGet, Route("GetLanguageLocalization")]
        public async Task<LanguageLocalizationDTO> GetLanguageLocalization(int id)
        {
            var localization = DB.LanguageLocalizations.Include(o => o.LanguageEntity).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainEntity = GetLanguagesList().FirstOrDefault(o => o.Id == localization?.LanguageMainModelId && !o.IsDeleted);

            return (LanguageLocalizationDTO)DbService.GetLocalizationModel(localization, mainEntity, new LanguageLocalizationDTO());
        }






        [HttpPost, Route("CreateLanguage")]
        [CheckContentAreaRights(ContentAccessModelType.General, 4)]
        [SwaggerOperation(description: "Нужно загрузить изображение через форму с именем mainImg")]
        public async Task<LanguageDTO> CreateLanguage([FromForm(Name = "model")] LanguageDTO model)
        {
            return (LanguageDTO)DbService.TryCreateEntity(DB.Languages, model, (entity) =>
            {
                HandleLanguage(entity, DBModelFillMode.Create);
            });
        }
    
        [HttpPost, Route("CreateLanguageLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.General, 3)]
        public async Task<LanguageLocalizationDTO> CreateLanguageLocalization(int itemId, LanguageLocalizationDTO localization)
        {
            var mainEntity = GetLanguagesList().FirstOrDefault(o => o.Id == itemId);
            return (LanguageLocalizationDTO)DbService.TryCreateLocalizationEntity(DB.Languages, mainEntity, localization);
        }





        [HttpPut, Route("UpdateLanguageMain")]
        [CheckContentAreaRights(ContentAccessModelType.General, 3)]
        [SwaggerOperation(description: "Нужно загрузить изображение через форму с именем mainImg, если изменяем картинку")]
        public async Task<LanguageDTO> UpdateLanguageMain([FromForm(Name = "model")] LanguageDTO model)
        {
            var item = GetLanguagesList().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (LanguageDTO)DbService.TryUpdateEntity(DB.Languages, model, item, (entity) =>
            {
                HandleLanguage(entity, DBModelFillMode.Update);
            });
        }
   
        [HttpPut, Route("UpdateLanguageLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.General, 3)]
        public async Task<LanguageLocalizationDTO> UpdateLanguageLocalization(LanguageLocalizationDTO model)
        {
            var localization = DB.LanguageLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            var mainEntity = GetCountriesList().FirstOrDefault(o => o.Id == localization.LanguageMainModelId && !o.IsDeleted);

            return (LanguageLocalizationDTO)DbService.TryUpdateLocalizationEntity(DB.LanguageLocalizations, localization, model, mainEntity);
        }





        [HttpDelete, Route("DeleteLanguage")]
        [CheckContentAreaRights(ContentAccessModelType.General, 5)]
        public async Task DeleteLanguage(int id)
        {
            var item = GetLanguagesList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DbService.TryDeleteEntity(DB.Languages, item);
        }

        [HttpDelete, Route("DeleteLanguageLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.General, 5)]
        public async Task DeleteLanguageLocalization(int id)
        {
            var item = DB.LanguageLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainModel = DB.Languages.FirstOrDefault(o => o.Id == item.LanguageMainModelId && !o.IsDeleted);

            DbService.TryDeleteLocalizationEntity(DB.LanguageLocalizations, item, mainModel);
        }


        #endregion

        #region Валюты


        [HttpGet, Route("GetCurrencies")]
        public async Task<ItemsWithTotalCount<CurrencyDTO>> GetCurrencies(int offset, int count = 20)
        {
            return DbService.GetManyWithTotalCount<Currency, CurrencyDTO>(GetCurrenciesList(), offset, count);
        }
        [HttpGet, Route("GetCurrenciesFiltered")]
        public async Task<ItemsWithTotalCount<CurrencyDTO>> GetCurrenciesFiltered([FromQuery] SearchFilter filter)
        {
            return DbService.GetManyWithTotalCount<Currency, CurrencyDTO>(GetCurrenciesList(), filter.Offset, filter.Count, (entity) =>
            {
                return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
            });
        }

        [HttpGet, Route("GetCurrency")]
        public async Task<CurrencyDTO> GetCurrency(int id)
        {
            return (CurrencyDTO)DbService.TryGetOne(GetCurrenciesList(), id, new CurrencyDTO());
        }


        [HttpGet, Route("GetCurrencyLocalizations")]
        public async Task<IEnumerable<CurrencyLocalizationDTO>> GetCurrencyLocalizations(int id)
        {
            var localizations = DB.CurrencyLocalizations.Include(o => o.LanguageEntity).Where(o => o.CurrencyId == id && !o.IsDeleted);
            var mainEntity = GetCurrenciesList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            return DbService.GetLocalizationModels(localizations, mainEntity, new CurrencyLocalizationDTO()).Cast<CurrencyLocalizationDTO>();
        }

        [HttpGet, Route("GetCurrencyLocalization")]
        public async Task<CurrencyLocalizationDTO> GetCurrencyLocalization(int id)
        {
            var localization = DB.CurrencyLocalizations.Include(o => o.LanguageEntity).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainEntity = GetCurrenciesList().FirstOrDefault(o => o.Id == localization?.CurrencyId && !o.IsDeleted);

            return (CurrencyLocalizationDTO)DbService.GetLocalizationModel(localization, mainEntity, new CurrencyLocalizationDTO());
        }




        [HttpPost, Route("CreateCurrency")]
        [CheckContentAreaRights(ContentAccessModelType.General, 4)]
        public async Task<CurrencyDTO> CreateCurrency(CurrencyDTO model)
        {
            return (CurrencyDTO)DbService.TryCreateEntity(DB.Currencies, model);
        }
     
        [HttpPost, Route("CreateCurrencyLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.General, 3)]
        public async Task<CurrencyLocalizationDTO> CreateCurrencyLocalization(int itemId, CurrencyLocalizationDTO localization)
        {
            var mainEntity = GetCurrenciesList().FirstOrDefault(o => o.Id == itemId);
            return (CurrencyLocalizationDTO)DbService.TryCreateLocalizationEntity(DB.Currencies, mainEntity, localization);
        }




        [HttpPut, Route("UpdateCurrencyMain")]
        [CheckContentAreaRights(ContentAccessModelType.General, 3)]
        public async Task<CurrencyDTO> UpdateCurrencyMain(CurrencyDTO model)
        {
            var item = GetCurrenciesList().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (CurrencyDTO)DbService.TryUpdateEntity(DB.Currencies, model, item);
        }
       
        [HttpPut, Route("UpdateCurrencyLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.General, 3)]
        public async Task<CurrencyLocalizationDTO> UpdateCurrencyLocalization(CurrencyLocalizationDTO model)
        {
            var localization = DB.CurrencyLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            var mainEntity = GetCurrenciesList().FirstOrDefault(o => o.Id == localization.CurrencyId && !o.IsDeleted);

            return (CurrencyLocalizationDTO)DbService.TryUpdateLocalizationEntity(DB.CurrencyLocalizations, localization, model, mainEntity);
        }






        [HttpDelete, Route("DeleteCurrency")]
        [CheckContentAreaRights(ContentAccessModelType.General, 5)]
        public async Task DeleteCurrency(int id)
        {
            var item = GetCurrenciesList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DbService.TryDeleteEntity(DB.Currencies, item);
        }

        [HttpDelete, Route("DeleteCurrencyLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.General, 5)]
        public async Task DeleteCurrencyLocalization(int id)
        {
            var item = DB.CurrencyLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainModel = DB.Currencies.FirstOrDefault(o => o.Id == item.CurrencyId && !o.IsDeleted);

            DbService.TryDeleteLocalizationEntity(DB.CurrencyLocalizations, item, mainModel);
        }

        #endregion

        #region Часовые пояса


        [HttpGet, Route("GetTimezones")]
        public async Task<ItemsWithTotalCount<TimezoneDTO>> GetTimezones(int offset, int count = 20)
        {
            return DbService.GetManyWithTotalCount<Alfateam2._0.Models.General.TimeZone, TimezoneDTO>(GetTimezonesList(), offset, count);
        }
        [HttpGet, Route("GetTimezonesFiltered")]
        public async Task<ItemsWithTotalCount<TimezoneDTO>> GetTimezonesFiltered([FromQuery] SearchFilter filter)
        {
            return DbService.GetManyWithTotalCount<Alfateam2._0.Models.General.TimeZone, TimezoneDTO>(GetTimezonesList(), filter.Offset, filter.Count, (entity) =>
            {
                return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
            });
        }
        [HttpGet, Route("GetTimezone")]
        public async Task<TimezoneDTO> GetTimezone(int id)
        {
            return (TimezoneDTO)DbService.TryGetOne(GetTimezonesList(), id, new TimezoneDTO());
        }






        [HttpGet, Route("GetTimezoneLocalizations")]
        public async Task<IEnumerable<TimezoneLocalizationDTO>> GetTimezoneLocalizations(int id)
        {
            var localizations = DB.TimezoneLocalizations.Include(o => o.LanguageEntity).Where(o => o.TimeZoneId == id && !o.IsDeleted);
            var mainEntity = GetTimezonesList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            return DbService.GetLocalizationModels(localizations, mainEntity, new TimezoneLocalizationDTO()).Cast<TimezoneLocalizationDTO>();
        }

        [HttpGet, Route("GetTimezoneLocalization")]
        public async Task<TimezoneLocalizationDTO> GetTimezoneLocalization(int id)
        {
            var localization = DB.TimezoneLocalizations.Include(o => o.LanguageEntity).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainEntity = GetTimezonesList().FirstOrDefault(o => o.Id == localization?.TimeZoneId && !o.IsDeleted);

            return (TimezoneLocalizationDTO)DbService.GetLocalizationModel(localization, mainEntity, new TimezoneLocalizationDTO());
        }




      





        [HttpPost, Route("CreateTimezone")]
        [CheckContentAreaRights(ContentAccessModelType.General, 4)]
        public async Task<TimezoneDTO> CreateTimezone(TimezoneDTO model)
        {
            return (TimezoneDTO)DbService.TryCreateEntity(DB.TimeZones, model);
        }

        [HttpPost, Route("CreateTimezoneLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.General, 3)]
        public async Task<TimezoneLocalizationDTO> CreateTimezoneLocalization(int itemId, TimezoneLocalizationDTO localization)
        {
            var mainEntity = GetTimezonesList().FirstOrDefault(o => o.Id == itemId);
            return (TimezoneLocalizationDTO)DbService.TryCreateLocalizationEntity(DB.TimeZones, mainEntity, localization);
        }





        [HttpPut, Route("UpdateTimezone")]
        [CheckContentAreaRights(ContentAccessModelType.General, 3)]
        public async Task<TimezoneDTO> UpdateTimezone(TimezoneDTO model)
        {
            var item = GetTimezonesList().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (TimezoneDTO)DbService.TryUpdateEntity(DB.TimeZones, model, item);
        }

        [HttpPut, Route("UpdateTimezoneLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.General, 3)]
        public async Task<TimezoneLocalizationDTO> UpdateTimezoneLocalization(TimezoneLocalizationDTO model)
        {
            var localization = DB.TimezoneLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            var mainEntity = GetTimezonesList().FirstOrDefault(o => o.Id == localization.TimeZoneId && !o.IsDeleted);

            return (TimezoneLocalizationDTO)DbService.TryUpdateLocalizationEntity(DB.TimezoneLocalizations, localization, model, mainEntity);
        }





        [HttpDelete, Route("DeleteTimezone")]
        [CheckContentAreaRights(ContentAccessModelType.General, 5)]
        public async Task DeleteTimezone(int id)
        {
            var item = GetTimezonesList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DbService.TryDeleteEntity(DB.TimeZones, item);
        }

        [HttpDelete, Route("DeleteTimezoneLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.General, 5)]
        public async Task DeleteTimezoneLocalization(int id)
        {
            var item = DB.TimezoneLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainModel = DB.TimeZones.FirstOrDefault(o => o.Id == item.TimeZoneId && !o.IsDeleted);

            DbService.TryDeleteLocalizationEntity(DB.TimezoneLocalizations, item, mainModel);
        }




        #endregion









        #region Private handle methods

        private void HandleLanguage(Language entity, DBModelFillMode mode)
        {
            const string formFilename = "mainImg";

            if ((mode == DBModelFillMode.Update && FilesService.IsFileUploaded(formFilename))
                || mode == DBModelFillMode.Create)
            {
                entity.IconPath = FilesService.TryUploadFile(formFilename, FileType.Image);
            }
        }

        #endregion

        #region Private get included methods
        private IEnumerable<Country> GetCountriesList()
        {
            return DB.Countries.Include(o => o.Localizations).ThenInclude(o => o.LanguageEntity)
                               .Include(o => o.MainLanguage)
                               .Include(o => o.Languages)
                               .Include(o => o.Currencies)
                               .Include(o => o.OfficialMainLanguage)
                               .Where(o => !o.IsDeleted)
                               .ToList();
        }
        private IEnumerable<Language> GetLanguagesList()
        {
            return DB.Languages.Include(o => o.Localizations).ThenInclude(o => o.LanguageEntity)
                               .Include(o => o.MainLanguage)
                               .Where(o => !o.IsDeleted)
                               .ToList();
        }
        private IEnumerable<Currency> GetCurrenciesList()
        {
            return DB.Currencies.Include(o => o.Localizations).ThenInclude(o => o.LanguageEntity)
                                .Include(o => o.MainLanguage)
                                .Where(o => !o.IsDeleted)
                                .ToList();
        }

        private IEnumerable<Alfateam2._0.Models.General.TimeZone> GetTimezonesList()
        {
            return DB.TimeZones.Include(o => o.Localizations).ThenInclude(o => o.LanguageEntity)
                               .Where(o => !o.IsDeleted)
                               .ToList();
        }

        #endregion

    }
}

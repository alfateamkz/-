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

namespace Alfateam.Website.API.Controllers.Admin
{
    public class AdminGeneralController : AbsAdminController
    {

        public AdminGeneralController(WebsiteDBContext db, IWebHostEnvironment appEnv) : base(db, appEnv)
        {
        }

        #region Страны

        [HttpGet, Route("GetCountries")]
        public async Task<RequestResult<IEnumerable<CountryDTO>>> GetCountries()
        {
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<IEnumerable<CountryDTO>> (new[]
            {
                () => CheckSession(session),
                () => RequestResult.FromBoolean(IsInAdminRole(session.User), 403, "У данного пользователя нет прав на получение объектов"),
                () => {
                   var clientItems = CountryDTO.CreateItemsWithLocalization(GetCountriesList(), LanguageId) as IEnumerable<CountryDTO>;
                   return RequestResult<IEnumerable<CountryDTO>>.AsSuccess(clientItems);
                }
            });
        }

        [HttpGet, Route("GetCountry")]
        public async Task<RequestResult<Country>> GetCountry(int id)
        {
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<Country>(new[]
            {
                () => CheckSession(session),
                () => RequestResult.FromBoolean(IsInAdminRole(session.User), 403, "У данного пользователя нет прав на получение объектов"),
                () => TryGetOne(GetCountriesList(),id)
            });
        }
      
        [HttpGet, Route("GetCountryLocalization")]
        public async Task<RequestResult<CountryLocalization>> GetCountryLocalization(int id)
        {
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<CountryLocalization>(new[]
            {
                () => CheckSession(session),
                () => RequestResult.FromBoolean(IsInAdminRole(session.User), 403, "У данного пользователя нет прав на получение объектов"),
                () => TryGetOne(DB.CountryLocalizations.Include(o => o.LanguageEntity).Where(o => !o.IsDeleted), id),
            });
        }




        [HttpPost, Route("CreateCountry")]
        public async Task<RequestResult<Country>> CreateCountry(Country item)
        {
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<Country>(new[]
            {
                () => CheckSession(session),
                () => CheckContentAreaRights(session,ContentAccessModelType.General,4),
                () => RequestResult.FromBoolean(item.IsValid(), 400, "Проверьте корректность заполненных значений"),
                () => CreateModel(DB.Countries,item)
            });
        }
      
        [HttpPost, Route("CreateCountryLocalization")]
        public async Task<RequestResult<CountryLocalization>> CreateCountryLocalization(int itemId, CountryLocalization localization)
        {
            var mainEntity = GetCountriesList().FirstOrDefault(o => o.Id == itemId);
            var session = GetSessionWithRoleInclude();
            
            return TryFinishAllRequestes<CountryLocalization>(new[]
            {
                () => CheckSession(session),
                () => CheckContentAreaRights(session,ContentAccessModelType.General,4),
                () => RequestResult.FromBoolean(localization.IsValid(), 400, "Проверьте корректность заполненных значений"),
                () =>
                {
                     mainEntity.Localizations.Add(localization);
                     return UpdateModel(DB.Countries,mainEntity);
                }
            });
        }





        [HttpPut, Route("UpdateCountryMain")]
        public async Task<RequestResult<Country>> UpdateCountryMain(CountryDTO model)
        {
            var item = GetCountriesList().FirstOrDefault(o => o.Id == model.Id);
            var session = GetSessionWithRoleInclude();

            return TryFinishAllRequestes<Country>(new[]
            {
                () => RequestResult.FromBoolean(item != null,404,"Сущность с данным id не найдена"),
                () => CheckSession(session),
                () => CheckContentAreaRights(session,ContentAccessModelType.General,2),
                () => RequestResult.FromBoolean(item.IsValid(), 400, "Проверьте корректность заполненных значений"),
                () => RequestResult.FromBoolean(DB.Languages.Any(o => o.Id == model.MainLanguageId && !o.IsDeleted), 400, "Языка с данным id не существует"),
                () =>
                {
                    model.FillDBModel(item,GetLanguagesList().ToList(), DBModelFillMode.Update);
                    return RequestResult.AsSuccess();
                },
                () => UpdateModel(DB.Countries, item)
            });
        }
     
        [HttpPut, Route("UpdateCountryLocalization")]
        public async Task<RequestResult<CountryLocalization>> UpdateCountryLocalization(CountryLocalizationDTO model)
        {
            var localization = DB.CountryLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            var session = GetSessionWithRoleInclude();

            return TryFinishAllRequestes<CountryLocalization>(new[]
            {
                () => RequestResult.FromBoolean(localization != null,404,"Сущность с данным id не найдена"),
                () => CheckSession(session),
                () => CheckContentAreaRights(session,ContentAccessModelType.General,3),
                () => RequestResult.FromBoolean(localization.IsValid(), 400, "Проверьте корректность заполненных значений"),
                () => UpdateModel(DB.CountryLocalizations,model,localization)
            });
        }





        [HttpDelete, Route("DeleteCountry")]
        public async Task<RequestResult> DeleteCountry(int id)
        {
            var item = GetCountriesList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (item == null)
            {
                return RequestResult.AsError(404, "Запись по данному id не найдена");
            }

            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes(new []
            {
                () => CheckSession(session),
                () => CheckContentAreaRights(session, ContentAccessModelType.General, 5),
                () => DeleteModel(DB.Countries,item)
            });
        }

        [HttpDelete, Route("DeleteCountryLocalization")]
        public async Task<RequestResult> DeleteCountryLocalization(int id)
        {
            var item = DB.CountryLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (item == null)
            {
                return RequestResult.AsError(404, "Запись по данному id не найдена");
            }

            return TryFinishAllRequestes(new[]
            {
                () => CheckLocalizationBeforeDelete(GetCountriesList(), item.CountryId, ContentAccessModelType.General),
                () => DeleteModel(DB.CountryLocalizations, item, false)
            });
        }

        #endregion

        #region Языки

        [HttpGet, Route("GetLanguages")]
        public async Task<RequestResult<IEnumerable<LanguageDTO>>> GetLanguages()
        {
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<IEnumerable<LanguageDTO>>(new[]
            {
                () => CheckSession(session),
                () => RequestResult.FromBoolean(IsInAdminRole(session.User), 403, "У данного пользователя нет прав на получение объектов"),
                () => {
                   var clientItems = LanguageDTO.CreateItemsWithLocalization(GetLanguagesList(), LanguageId) as IEnumerable<LanguageDTO>;
                   return RequestResult<IEnumerable<LanguageDTO>>.AsSuccess(clientItems);
                }
            });
        }
     
        [HttpGet, Route("GetLanguage")]
        public async Task<RequestResult<Language>> GetLanguage(int id)
        {
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<Language>(new[]
            {
                () => CheckSession(session),
                () => RequestResult.FromBoolean(IsInAdminRole(session.User), 403, "У данного пользователя нет прав на получение объектов"),
                () => TryGetOne(GetLanguagesList(),id)
            });
        }

        [HttpGet, Route("GetLanguageLocalization")]
        public async Task<RequestResult<LanguageLocalization>> GetLanguageLocalization(int id)
        {
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<LanguageLocalization>(new[]
            {
                () => CheckSession(session),
                () => RequestResult.FromBoolean(IsInAdminRole(session.User), 403, "У данного пользователя нет прав на получение объектов"),
                () => TryGetOne(DB.LanguageLocalizations.Include(o => o.LanguageEntity).Where(o => !o.IsDeleted), id),
            });
        }






        [HttpPost, Route("CreateLanguage")]
        public async Task<RequestResult<Language>> CreateLanguage(Language item)
        {
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<Language>(new[]
            {
                () => CheckSession(session),
                () => CheckContentAreaRights(session,ContentAccessModelType.General,4),
                () => RequestResult.FromBoolean(item.IsValid(), 400, "Проверьте корректность заполненных значений"),
                () => CreateModel(DB.Languages,item),
                () =>
                {
                    var websiteLocalization = new Alfateam2._0.Models.Localization.Texts.Grouping.WebsiteLocalizationTexts(item.Id);
                    CreateModel(DB.WebsiteLocalizationTexts,websiteLocalization);
                    StaticFilesHelper.CreateStaticLocalizationsFile(websiteLocalization);

                    return RequestResult<Language>.AsSuccess(item);
                }
            });
        }
    
        [HttpPost, Route("CreateLanguageLocalization")]
        public async Task<RequestResult<LanguageLocalization>> CreateLanguageLocalization(int itemId, LanguageLocalization localization)
        {
            var mainEntity = GetLanguagesList().FirstOrDefault(o => o.Id == itemId);
            var session = GetSessionWithRoleInclude();

            return TryFinishAllRequestes<LanguageLocalization>(new[]
            {
                () => CheckSession(session),
                () => CheckContentAreaRights(session,ContentAccessModelType.General,4),
                () => RequestResult.FromBoolean(localization.IsValid(), 400, "Проверьте корректность заполненных значений"),
                () =>
                {
                     mainEntity.Localizations.Add(localization);
                     return UpdateModel(DB.Languages,mainEntity);
                }
            });
        }





        [HttpPut, Route("UpdateLanguageMain")]
        public async Task<RequestResult<Language>> UpdateLanguageMain(LanguageDTO model)
        {
            var item = GetLanguagesList().FirstOrDefault(o => o.Id == model.Id);
            var session = GetSessionWithRoleInclude();

            return TryFinishAllRequestes<Language>(new[]
            {
                () => RequestResult.FromBoolean(item != null,404,"Сущность с данным id не найдена"),
                () => CheckSession(session),
                () => CheckContentAreaRights(session,ContentAccessModelType.General,2),
                () => RequestResult.FromBoolean(item.IsValid(), 400, "Проверьте корректность заполненных значений"),
                () => RequestResult.FromBoolean(DB.Languages.Any(o => o.Id == model.MainLanguageId && !o.IsDeleted), 400, "Языка с данным id не существует"),
                () => UpdateModel(DB.Languages,model,item)
            });
        }
   
        [HttpPut, Route("UpdateLanguageLocalization")]
        public async Task<RequestResult<LanguageLocalization>> UpdateCurrencyLocalization(LanguageLocalizationDTO model)
        {
            var localization = DB.LanguageLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            var session = GetSessionWithRoleInclude();

            return TryFinishAllRequestes<LanguageLocalization>(new[]
            {
                () => RequestResult.FromBoolean(localization != null,404,"Сущность с данным id не найдена"),
                () => CheckSession(session),
                () => CheckContentAreaRights(session,ContentAccessModelType.General,3),
                () => RequestResult.FromBoolean(localization.IsValid(), 400, "Проверьте корректность заполненных значений"),
                () => UpdateModel(DB.LanguageLocalizations,model,localization)
            });
        }





        [HttpDelete, Route("DeleteLanguage")]
        public async Task<RequestResult> DeleteLanguage(int id)
        {
            var item = GetLanguagesList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (item == null)
            {
                return RequestResult.AsError(404, "Запись по данному id не найдена");
            }

            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes(new[]
            {
                () => CheckSession(session),
                () => CheckContentAreaRights(session, ContentAccessModelType.General, 5),
                () => DeleteModel(DB.Languages,item)
            });
        }

        [HttpDelete, Route("DeleteLanguageLocalization")]
        public async Task<RequestResult> DeleteLanguageLocalization(int id)
        {
            var item = DB.LanguageLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (item == null)
            {
                return RequestResult.AsError(404, "Запись по данному id не найдена");
            }

            return TryFinishAllRequestes(new[]
            {
                () => CheckLocalizationBeforeDelete(GetCountriesList(), item.LanguageMainModelId, ContentAccessModelType.General),
                () => DeleteModel(DB.LanguageLocalizations, item, false)
            });
        }


        #endregion

        #region Валюты

        [HttpGet, Route("GetCurrencies")]
        public async Task<RequestResult<IEnumerable<CurrencyDTO>>> GetCurrencies()
        {
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<IEnumerable<CurrencyDTO>>(new[]
            {
                () => CheckSession(session),
                () => RequestResult.FromBoolean(IsInAdminRole(session.User), 403, "У данного пользователя нет прав на получение объектов"),
                () => {
                   var clientItems = CurrencyDTO.CreateItemsWithLocalization(GetCurrenciesList(), LanguageId) as IEnumerable<CurrencyDTO>;
                   return RequestResult<IEnumerable<CurrencyDTO>>.AsSuccess(clientItems);
                }
            });
        }
  
        [HttpGet, Route("GetCurrency")]
        public async Task<RequestResult<Currency>> GetCurrency(int id)
        {
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<Currency>(new[]
            {
                () => CheckSession(session),
                () => RequestResult.FromBoolean(IsInAdminRole(session.User), 403, "У данного пользователя нет прав на получение объектов"),
                () => TryGetOne(GetCurrenciesList(),id)
            });
        }
        
        [HttpGet, Route("GetCurrencyLocalization")]
        public async Task<RequestResult<CurrencyLocalization>> GetCurrencyLocalization(int id)
        {
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<CurrencyLocalization>(new[]
            {
                () => CheckSession(session),
                () => RequestResult.FromBoolean(IsInAdminRole(session.User), 403, "У данного пользователя нет прав на получение объектов"),
                () => TryGetOne(DB.CurrencyLocalizations.Include(o => o.LanguageEntity).Where(o => !o.IsDeleted), id),
            });
        }




        [HttpPost, Route("CreateCurrency")]
        public async Task<RequestResult<Currency>> CreateCurrency(Currency item)
        {
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<Currency>(new[]
            {
                () => CheckSession(session),
                () => CheckContentAreaRights(session,ContentAccessModelType.General,4),
                () => RequestResult.FromBoolean(item.IsValid(), 400, "Проверьте корректность заполненных значений"),
                () => CreateModel(DB.Currencies,item)
            });
        }
     
        [HttpPost, Route("CreateCurrencyLocalization")]
        public async Task<RequestResult<CurrencyLocalization>> CreateCurrencyLocalization(int itemId, CurrencyLocalization localization)
        {
            var mainEntity = GetCurrenciesList().FirstOrDefault(o => o.Id == itemId);
            var session = GetSessionWithRoleInclude();
 
            return TryFinishAllRequestes<CurrencyLocalization>(new[]
            {
                () => CheckSession(session),
                () => CheckContentAreaRights(session,ContentAccessModelType.General,4),
                () => RequestResult.FromBoolean(localization.IsValid(), 400, "Проверьте корректность заполненных значений"),
                () =>
                {
                     mainEntity.Localizations.Add(localization);
                     return UpdateModel(DB.Currencies,mainEntity);
                }
            });
        }




        [HttpPut, Route("UpdateCurrencyMain")]
        public async Task<RequestResult<Currency>> UpdateCurrencyMain(CurrencyDTO model)
        {
            var item = GetCurrenciesList().FirstOrDefault(o => o.Id == model.Id);
            var session = GetSessionWithRoleInclude();

            return TryFinishAllRequestes<Currency>(new[]
            {
                () => RequestResult.FromBoolean(item != null,404,"Сущность с данным id не найдена"),
                () => CheckSession(session),
                () => CheckContentAreaRights(session,ContentAccessModelType.General,2),
                () => RequestResult.FromBoolean(item.IsValid(), 400, "Проверьте корректность заполненных значений"),
                () => RequestResult.FromBoolean(DB.Languages.Any(o => o.Id == model.MainLanguageId && !o.IsDeleted), 400, "Языка с данным id не существует"),
                () => UpdateModel(DB.Currencies,model,item)
            });
        }
       
        [HttpPut, Route("UpdateCurrencyLocalization")]
        public async Task<RequestResult<CurrencyLocalization>> UpdateCurrencyLocalization(CurrencyLocalizationDTO model)
        {
            var localization = DB.CurrencyLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            var session = GetSessionWithRoleInclude();

            return TryFinishAllRequestes<CurrencyLocalization>(new[]
            {
                () => RequestResult.FromBoolean(localization != null,404,"Сущность с данным id не найдена"),
                () => CheckSession(session),
                () => CheckContentAreaRights(session,ContentAccessModelType.General,3),
                () => RequestResult.FromBoolean(localization.IsValid(), 400, "Проверьте корректность заполненных значений"),
                () => UpdateModel(DB.CurrencyLocalizations,model,localization)
            });
        }






        [HttpDelete, Route("DeleteCurrency")]
        public async Task<RequestResult> DeleteCurrency(int id)
        {
            var item = GetCurrenciesList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (item == null)
            {
                return RequestResult.AsError(404, "Запись по данному id не найдена");
            }

            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes(new[]
            {
                () => CheckSession(session),
                () => CheckContentAreaRights(session, ContentAccessModelType.General, 5),
                () => DeleteModel(DB.Currencies,item)
            });
        }

        [HttpDelete, Route("DeleteCurrencyLocalization")]
        public async Task<RequestResult> DeleteCurrencyLocalization(int id)
        {
            var item = DB.CurrencyLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (item == null)
            {
                return RequestResult.AsError(404, "Запись по данному id не найдена");
            }

            return TryFinishAllRequestes(new[]
            {
                () => CheckLocalizationBeforeDelete(GetCurrenciesList(), item.CurrencyId, ContentAccessModelType.General),
                () => DeleteModel(DB.CurrencyLocalizations, item, false)
            });
        }

        #endregion




        #region Private get included methods
        private IQueryable<Country> GetCountriesList()
        {
            return DB.Countries.Include(o => o.Localizations).ThenInclude(o => o.LanguageEntity)
                               .Include(o => o.MainLanguage)
                               .Include(o => o.Languages)
                               .Include(o => o.OfficialMainLanguage)
                               .Where(o => !o.IsDeleted);
        }
        private IQueryable<Language> GetLanguagesList()
        {
            return DB.Languages.Include(o => o.Localizations).ThenInclude(o => o.LanguageEntity)
                               .Include(o => o.MainLanguage)
                               .Where(o => !o.IsDeleted);
        }
        private IQueryable<Currency> GetCurrenciesList()
        {
            return DB.Currencies.Include(o => o.Localizations).ThenInclude(o => o.LanguageEntity)
                                .Include(o => o.MainLanguage)
                                .Where(o => !o.IsDeleted);
        }

        #endregion

    }
}

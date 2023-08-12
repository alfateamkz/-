using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Enums;
using Alfateam.Website.API.Extensions;
using Alfateam.Website.API.Models.ClientModels.Events;
using Alfateam.Website.API.Models.Core;
using Alfateam.Website.API.Models.EditModels.Events;
using Alfateam.Website.API.Models.EditModels.General;
using Alfateam.Website.API.Models.LocalizationEditModels.Events;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.Events;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Localization.Items.Events;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Website.API.Controllers.Admin
{
    public class AdminEventsController : AbsAdminController
    {
        public AdminEventsController(WebsiteDBContext db, IWebHostEnvironment appEnv) : base(db, appEnv)
        {
           
        }


        #region События

        [HttpGet, Route("GetEvents")]
        public async Task<RequestResult<IEnumerable<EventClientModel>>> GetEvents(int offset, int count = 20)
        {
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<IEnumerable<EventClientModel>>(new Func<RequestResult>[]
            {
                () => CheckContentAreaRights(session, ContentAccessModelType.Events, 1),
                () => {
                    var items = GetAvailableModels(session.User, GetEventCategoriesList(), offset, count);
                    var models = EventClientModel.CreateItems(items.Cast<Event>(), LanguageId);
                    return RequestResult<IEnumerable<EventClientModel>>.AsSuccess(models);
                }
            });
        }

        [HttpGet, Route("GetEvent")]
        public async Task<RequestResult<Event>> GetEvent(int id)
        {
            return TryGetOne(GetEventsList(), id, ContentAccessModelType.Events);
        }

        [HttpGet, Route("GetEventLocalization")]
        public async Task<RequestResult<EventLocalization>> GetEventLocalization(int id)
        {
            var localization = DB.EventLocalizations.Include(o => o.Language).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (localization == null) return RequestResult<EventLocalization>.AsError(404, "Сущность с данным id не найдена");

            var mainEntity = GetEventFormatsList().FirstOrDefault(o => o.Id == localization.EventId && !o.IsDeleted);
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<EventLocalization>(new Func<RequestResult>[]
            {
                () => RequestResult.FromBoolean(mainEntity != null, 500, "Внутренняя ошибка"),
                () => CheckContentAreaRights(session, mainEntity, ContentAccessModelType.Events, 1),
                () => RequestResult<EventLocalization>.AsSuccess(localization)
            });
        }




        [HttpPost, Route("CreateEvent")]
        public async Task<RequestResult<Event>> CreateEvent(Event item)
        {
            return await TryCreate(DB.Events, item, ContentAccessModelType.Events, async () => await CheckAndPrepareEventBeforeCreate(item));
        }
     
        [HttpPost, Route("CreateEventLocalization")]
        public async Task<RequestResult<EventLocalization>> CreateEventLocalization(int itemId, EventLocalization localization)
        {
            var mainEntity = GetEventsList().FirstOrDefault(o => o.Id == itemId);
            return TryFinishAllRequestes<EventLocalization>(new[]
            {
                () => CheckLocalizationModelBeforeCreate(localization, mainEntity, ContentAccessModelType.Events),
                () => CheckAndPrepareEventLocalizationBeforeCreate(localization).Result,
                () =>
                {
                    mainEntity.Localizations.Add(localization);
                    return UpdateModel(DB.Events,mainEntity);
                }
            });
        }



        [HttpPut, Route("UpdateEventMain")]
        public async Task<RequestResult<Event>> UpdateEventMain(EventMainEditModel model)
        {
            var item = GetEventsList().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<Event>(new[]
            {
                () => RequestResult.FromBoolean(item != null,404, "Сущность по данному id не найдена"),
                () => CheckContentAreaRights(session, item, ContentAccessModelType.Events, 2),
                () => RequestResult.FromBoolean(model.IsValid(), 400, "Не заполнены все необходимые поля. Сверьтесь с документацией и попробуйте еще раз"),
                () => RequestResult.FromBoolean(DB.Languages.Any(o => o.Id == model.MainLanguageId && !o.IsDeleted),404, "Языка с данным id не существует"),
                () => CheckAndPrepareEventMainBeforeUpdate(item, model).Result,
                () => UpdateModel(DB.Events, model, item)
            });
        }

        [HttpPost, Route("UpdateEventLocalization")]
        public async Task<RequestResult<EventLocalization>> UpdateEventLocalization(EventLocalizationEditModel model)
        {
            var localization = DB.EventLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);  
            return TryFinishAllRequestes<EventLocalization>(new[]
            {
                () => RequestResult.FromBoolean(localization != null,404, "Локализация с данным id не найдена"),
                () => CheckLocalizationModelBeforeUpdate(GetEventsList(), model, localization.EventId, ContentAccessModelType.Events),
                () => CheckAndPrepareEventLocalizationBeforeUpdate(localization).Result,
                () => UpdateModel(DB.EventLocalizations, model, localization)
            });
        }







        [HttpDelete, Route("DeleteEvent")]
        public async Task<RequestResult> DeleteEvent(int id)
        {
            var item = GetEventsList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(item != null,404, "Категория по данному id не найдена"),
                () => TryDelete(DB.Events, item, ContentAccessModelType.Events)
            });
        }

        [HttpDelete, Route("DeleteEventLocalization")]
        public async Task<RequestResult> DeleteEventLocalization(int id)
        {
            var item = DB.EventLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(item != null,404, "Запись по данному id не найдена"),
                () => CheckLocalizationModelBeforeDelete(GetEventFormatsList(), item.EventId, ContentAccessModelType.Events),
                () => DeleteModel(DB.EventLocalizations, item, false)
            });
        }


        #endregion 

        #region Категории событий

        [HttpGet, Route("GetEventCategories")]
        public async Task<RequestResult<IEnumerable<EventCategoryClientModel>>> GetEventCategories(int offset, int count = 20)
        {
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<IEnumerable<EventCategoryClientModel>>(new Func<RequestResult>[]
            {
                () => CheckContentAreaRights(session, ContentAccessModelType.Events, 1),
                () => {
                    var items = GetAvailableModels(session.User, GetEventCategoriesList(), offset, count);
                    var models = EventCategoryClientModel.CreateItems(items.Cast<EventCategory>(), LanguageId);
                    return RequestResult<IEnumerable<EventCategoryClientModel>>.AsSuccess(models);
                }
            });
        }

        [HttpGet, Route("GetEventCategory")]
        public async Task<RequestResult<EventCategory>> GetEventCategory(int id)
        {
            return TryGetOne(GetEventCategoriesList(), id, ContentAccessModelType.Events);
        }
    
        [HttpGet, Route("GetEventCategoryLocalization")]
        public async Task<RequestResult<EventCategoryLocalization>> GetEventCategoryLocalization(int id)
        {
            var localization = DB.EventCategoryLocalizations.Include(o => o.Language).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (localization == null) return RequestResult<EventCategoryLocalization>.AsError(404, "Сущность с данным id не найдена");

            var mainEntity = GetEventFormatsList().FirstOrDefault(o => o.Id == localization.EventCategoryId && !o.IsDeleted);
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<EventCategoryLocalization>(new Func<RequestResult>[]
            {
                () => RequestResult.FromBoolean(mainEntity != null, 500, "Внутренняя ошибка"),
                () => CheckContentAreaRights(session, mainEntity, ContentAccessModelType.Events, 1),
                () => RequestResult<EventCategoryLocalization>.AsSuccess(localization)
            });
        }





        [HttpPost, Route("CreateEventCategory")]
        public async Task<RequestResult<EventCategory>> CreateEventCategory(EventCategory item)
        {
            return TryCreate(DB.EventCategories, item, ContentAccessModelType.Events);
        }

        [HttpPost, Route("CreateEventCategoryLocalization")]
        public async Task<RequestResult<EventCategoryLocalization>> CreateEventCategoryLocalization(int itemId, EventCategoryLocalization localization)
        {
            var mainEntity = GetEventCategoriesList().FirstOrDefault(o => o.Id == itemId);
            return TryFinishAllRequestes<EventCategoryLocalization>(new[]
            {
                () => CheckLocalizationModelBeforeCreate(localization, mainEntity, ContentAccessModelType.Events),
                () =>
                {
                    mainEntity.Localizations.Add(localization);
                    UpdateModel(DB.EventCategories, mainEntity);
                    return RequestResult<EventCategoryLocalization>.AsSuccess(localization);
                }
            });
        }




        [HttpPut, Route("UpdateEventCategoryMain")]
        public async Task<RequestResult<EventCategory>> UpdateEventCategoryMain(EventCategoryMainEditModel model)
        {
            var item = GetEventCategoriesList().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return TryFinishAllRequestes<EventCategory>(new[]
            {
                () => CheckMainModelBeforeUpdate(item, model,ContentAccessModelType.Events),
                () => RequestResult.FromBoolean(DB.Languages.Any(o => o.Id == model.MainLanguageId && !o.IsDeleted),
                                                    404, "Языка с данным id не существует"),
                () => UpdateModel(DB.EventCategories, model, item)
            });
        }

        [HttpPut, Route("UpdateEventCategoryLocalization")]
        public async Task<RequestResult<EventCategoryLocalization>> UpdatePostCategoryLocalization(EventCategoryLocalizationEditModel model)
        {
            var localization = DB.EventCategoryLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return TryFinishAllRequestes<EventCategoryLocalization>(new[]
            {
                () => RequestResult.FromBoolean(localization != null,404, "Локализация с данным id не найдена"),
                () => CheckLocalizationModelBeforeUpdate(GetEventCategoriesList(), model, localization.EventCategoryId, ContentAccessModelType.Events),
                () => UpdateModel(DB.EventCategoryLocalizations, model, localization)
            });
        }






        [HttpDelete, Route("DeleteEventCategory")]
        public async Task<RequestResult> DeleteEventCategory(int id)
        {
            var item = GetEventCategoriesList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(item != null,404, "Категория по данному id не найдена"),
                () => TryDelete(DB.EventCategories, item, ContentAccessModelType.Events)
            });
        }

        [HttpDelete, Route("DeleteEventCategoryLocalization")]
        public async Task<RequestResult> DeleteEventCategoryLocalization(int id)
        {
            var item = DB.EventCategoryLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(item != null,404, "Запись по данному id не найдена"),
                () => CheckLocalizationModelBeforeDelete(GetEventFormatsList(), item.EventCategoryId, ContentAccessModelType.Events),
                () => DeleteModel(DB.EventCategoryLocalizations, item, false)
            });
        }

        #endregion

        #region Форматы событий

        [HttpGet, Route("GetEventFormats")]
        public async Task<RequestResult<IEnumerable<EventFormatClientModel>>> GetEventFormats(int offset, int count = 20)
        {
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<IEnumerable<EventFormatClientModel>>(new Func<RequestResult>[]
            {
                () => CheckContentAreaRights(session, ContentAccessModelType.Events, 1),
                () => {
                    var items = GetAvailableModels(session.User, GetEventFormatsList(), offset, count);
                    var models = EventFormatClientModel.CreateItems(items.Cast<EventFormat>(), LanguageId);
                    return RequestResult<IEnumerable<EventFormatClientModel>>.AsSuccess(models);
                }
            });
        }

        [HttpGet, Route("GetEventFormat")]
        public async Task<RequestResult<EventFormat>> GetEventFormat(int id)
        {
            return TryGetOne(GetEventFormatsList(), id, ContentAccessModelType.Events);
        }

        [HttpGet, Route("GetEventFormatLocalization")]
        public async Task<RequestResult<EventFormatLocalization>> GetEventFormatLocalization(int id)
        {
            var localization = DB.EventFormatLocalizations.Include(o => o.Language).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (localization == null) return RequestResult<EventFormatLocalization>.AsError(404, "Сущность с данным id не найдена");

            var mainEntity = GetEventFormatsList().FirstOrDefault(o => o.Id == localization.EventFormatId && !o.IsDeleted);
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<EventFormatLocalization>(new Func<RequestResult>[]
            {
                () => RequestResult.FromBoolean(mainEntity != null, 500, "Внутренняя ошибка"),
                () => CheckContentAreaRights(session, mainEntity, ContentAccessModelType.Events, 1),
                () => RequestResult<EventFormatLocalization>.AsSuccess(localization)
            });
        }




        [HttpPost, Route("CreateEventFormat")]
        public async Task<RequestResult<EventFormat>> CreateEventFormat(EventFormat item)
        {
            return TryCreate(DB.EventFormats, item, ContentAccessModelType.Events);
        }
     
        [HttpPost, Route("CreateEventFormatLocalization")]
        public async Task<RequestResult<EventFormatLocalization>> CreateEventFormatLocalization(int itemId, EventFormatLocalization localization)
        {
            var mainEntity = GetEventFormatsList().FirstOrDefault(o => o.Id == itemId);
            return TryFinishAllRequestes<EventFormatLocalization>(new[]
            {
                () => CheckLocalizationModelBeforeCreate(localization, mainEntity, ContentAccessModelType.Events),
                () =>
                {
                    mainEntity.Localizations.Add(localization);
                    UpdateModel(DB.EventFormats, mainEntity);
                    return RequestResult<EventFormatLocalization>.AsSuccess(localization);
                }
            });
        }





        [HttpPut, Route("UpdateEventFormatMain")]
        public async Task<RequestResult<EventFormat>> UpdateEventFormatMain(EventFormatMainEditModel model)
        {
            var item = GetEventFormatsList().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return TryFinishAllRequestes<EventFormat>(new[]
            {
                () => CheckMainModelBeforeUpdate(item, model,ContentAccessModelType.Events),
                () => RequestResult.FromBoolean(DB.Languages.Any(o => o.Id == model.MainLanguageId && !o.IsDeleted),
                                                    404, "Языка с данным id не существует"),
                () => UpdateModel(DB.EventFormats, model, item)
            });
        }

        [HttpPut, Route("UpdateEventFormatLocalization")]
        public async Task<RequestResult<EventFormatLocalization>> UpdateEventFormatLocalization(EventFormatLocalizationEditModel model)
        {
            var localization = DB.EventFormatLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return TryFinishAllRequestes<EventFormatLocalization>(new[]
            {
                () => RequestResult.FromBoolean(localization != null,404, "Локализация с данным id не найдена"),
                () => CheckLocalizationModelBeforeUpdate(GetEventCategoriesList(), model, localization.EventFormatId, ContentAccessModelType.Events),
                () => UpdateModel(DB.EventFormatLocalizations, model, localization)
            });
        }
   
      




        [HttpDelete, Route("DeleteEventFormat")]
        public async Task<RequestResult> DeleteEventFormat(int id)
        {
            var item = GetEventFormatsList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(item != null,404, "Категория по данному id не найдена"),
                () => TryDelete(DB.EventFormats, item, ContentAccessModelType.Events)
            });
        }

        [HttpDelete, Route("DeleteEventFormatLocalization")]
        public async Task<RequestResult> DeleteEventFormatLocalization(int id)
        {
            var item = DB.EventFormatLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(item != null,404, "Запись по данному id не найдена"),
                () => CheckLocalizationModelBeforeDelete(GetEventFormatsList(), item.EventFormatId, ContentAccessModelType.Events),
                () => DeleteModel(DB.EventFormatLocalizations, item, false)
            });
        }


        #endregion


        [HttpPut, Route("UpdateAvailability")]
        public async Task<RequestResult<Availability>> UpdateAvailability(AvailabilityEditModel model)
        {
            bool hasThisModel = false;

            var user = GetSessionWithRoleInclude().User;
            hasThisModel |= GetAvailableModels(user, DB.Events.IncludeAvailability()).Any(o => o.AvailabilityId == model.Id && !o.IsDeleted);
            hasThisModel |= GetAvailableModels(user, DB.EventCategories.IncludeAvailability()).Any(o => o.AvailabilityId == model.Id && !o.IsDeleted);
            hasThisModel |= GetAvailableModels(user, DB.EventFormats.IncludeAvailability()).Any(o => o.AvailabilityId == model.Id && !o.IsDeleted);

            if (!hasThisModel)
            {
                return new RequestResult<Availability>().SetError(403, "У данного пользователя нет прав на редактирование матрицы доступности");
            }

            return TryUpdateAvailability(model, ContentAccessModelType.Events);
        }




        #region Private prepare methods

        private async Task<RequestResult> CheckAndPrepareEventBeforeCreate(Event item)
        {
            if(!DB.EventFormats.Any(o => o.Id == item.FormatId && !o.IsDeleted))
            {
                return RequestResult.AsError(400, "Формат события с данным id не найден");
            }
            else if (!DB.EventCategories.Any(o => o.Id == item.CategoryId && !o.IsDeleted))
            {
                return RequestResult.AsError(400, "Категория события с данным id не найден");
            }
            else if (!DB.TimeZones.Any(o => o.Id == item.TimeZoneId && !o.IsDeleted))
            {
                return RequestResult.AsError(400, "Часовой пояс с данным id не найден");
            }

            //Загрузка главной картинки
            var mainFileUploadResult = await TryUploadFile("mainImg", FileType.Image);
            if (!mainFileUploadResult.Success)
            {
                return mainFileUploadResult;
            }
            item.ImgPath = mainFileUploadResult.Value;

            foreach(var localization in item.Localizations)
            {
                var localizationCheckResult = await CheckAndPrepareEventLocalizationBeforeCreate(localization);
                if (!localizationCheckResult.Success)
                {
                    return localizationCheckResult;
                }
            }

            return RequestResult.AsSuccess();
        }
        private async Task<RequestResult> CheckAndPrepareEventMainBeforeUpdate(Event item,EventMainEditModel model)
        {
            if (!DB.EventFormats.Any(o => o.Id == model.FormatId && !o.IsDeleted))
            {
                return RequestResult.AsError(400, "Формат события с данным id не найден");
            }
            else if (!DB.EventCategories.Any(o => o.Id == model.CategoryId && !o.IsDeleted))
            {
                return RequestResult.AsError(400, "Категория события с данным id не найден");
            }
            else if (!DB.TimeZones.Any(o => o.Id == model.TimeZoneId && !o.IsDeleted))
            {
                return RequestResult.AsError(400, "Часовой пояс с данным id не найден");
            }


            if (item.ImgPath != model.ImgPath)
            {
                //Загрузка главной картинки
                var mainFileUploadResult = await TryUploadFile("mainImg", FileType.Image);
                if (!mainFileUploadResult.Success)
                {
                    return new RequestResult().FillFromRequestResult(mainFileUploadResult);
                }
                item.ImgPath = mainFileUploadResult.Value;
            }

            return RequestResult.AsSuccess();
        }


        private async Task<RequestResult> CheckAndPrepareEventLocalizationBeforeCreate(EventLocalization localization)
        {
            if (!localization.IsValid())
            {
                return RequestResult.AsError(400, "Проверьте корректность заполения полей локализации события");
            }
            if(!DB.Languages.Any(o => o.Id == localization.LanguageId && !o.IsDeleted))
            {
                return RequestResult.AsError(400, "Язык с данным id не существует");
            }


            //Загрузка главной картинки
            var mainFileUploadResult = await TryUploadFile($"localization_{localization.LanguageId}_mainImg", FileType.Image);
            if (!mainFileUploadResult.Success)
            {
                return mainFileUploadResult;
            }
            localization.ImgPath = mainFileUploadResult.Value;

            return RequestResult.AsSuccess();
        }
        private async Task<RequestResult> CheckAndPrepareEventLocalizationBeforeUpdate(EventLocalization localization)
        {
            if (!localization.IsValid())
            {
                return RequestResult.AsError(400, "Проверьте корректность заполения полей локализации события");
            }
            if (!DB.Languages.Any(o => o.Id == localization.LanguageId && !o.IsDeleted))
            {
                return RequestResult.AsError(400, "Язык с данным id не существует");
            }

            string formFileName = $"localization_{localization.LanguageId}_mainImg";
            if (Request.Form.Files.Any(o => o.Name == formFileName))
            {
                //Загрузка главной картинки
                var mainFileUploadResult = await TryUploadFile(formFileName, FileType.Image);
                if (!mainFileUploadResult.Success)
                {
                    return mainFileUploadResult;
                }
                localization.ImgPath = mainFileUploadResult.Value;
            }

          
            return RequestResult.AsSuccess();
        }


        #endregion

        #region Private get included methods
        private IQueryable<Event> GetEventsList()
        {
            return DB.Events.IncludeAvailability()
                            .Include(o => o.TimeZone)
                            .Include(o => o.Category).ThenInclude(o => o.MainLanguage)
                            .Include(o => o.Category).ThenInclude(o => o.Localizations).ThenInclude(o => o.Language)
                            .Include(o => o.Format).ThenInclude(o => o.MainLanguage)
                            .Include(o => o.Format).ThenInclude(o => o.Localizations).ThenInclude(o => o.Language)
                            .Include(o => o.Localizations).ThenInclude(o => o.Language)
                            .Include(o => o.MainLanguage)
                            .Where(o => !o.IsDeleted);
        }
        private IQueryable<EventCategory> GetEventCategoriesList()
        {
            return DB.EventCategories.IncludeAvailability()
                                     .Include(o => o.Localizations).ThenInclude(o => o.Language)
                                     .Include(o => o.MainLanguage)
                                     .Where(o => !o.IsDeleted);
        }
        private IQueryable<EventFormat> GetEventFormatsList()
        {
            return DB.EventFormats.IncludeAvailability()
                                  .Include(o => o.Localizations).ThenInclude(o => o.Language)
                                  .Include(o => o.MainLanguage)
                                  .Where(o => !o.IsDeleted);
        }

        #endregion

    }
}

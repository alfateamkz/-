using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Enums;
using Alfateam.Website.API.Extensions;
using Alfateam.Website.API.Models.ClientModels.Events;
using Alfateam.Website.API.Models.ClientModels.Posts;
using Alfateam.Website.API.Models.Core;
using Alfateam.Website.API.Models.EditModels.Events;
using Alfateam.Website.API.Models.EditModels.General;
using Alfateam.Website.API.Models.LocalizationEditModels.Events;
using Alfateam.Website.API.Models.LocalizationEditModels.Posts;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.Events;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Localization.Items.Events;
using Alfateam2._0.Models.Localization.Items.Portfolios;
using Alfateam2._0.Models.Localization.Items.Posts;
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
            var res = new RequestResult<IEnumerable<EventClientModel>>();

            var tryGetManyResponse = TryGetMany(GetEventsList(), ContentAccessModelType.Events, offset, count);
            if (!tryGetManyResponse.Success)
            {
                return res.FillFromRequestResult(tryGetManyResponse);
            }

            var models = EventClientModel.CreateItems(tryGetManyResponse.Value.ToList(), LanguageId);
            return res.SetSuccess(models);
        }

        [HttpGet, Route("GetEvent")]
        public async Task<RequestResult<Event>> GetEvent(int id)
        {
            return TryGetOne(GetEventsList(), id, ContentAccessModelType.Events);
        }
        [HttpGet, Route("GetEventLocalization")]
        public async Task<RequestResult<EventLocalization>> GetEventLocalization(int id)
        {
            var localization = DB.EventLocalizations.Include(o => o.Language)
                                                    .FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (localization == null)
            {
                return new RequestResult<EventLocalization>().SetError(404, "Локализация с данным id не найдена");
            }

            //Проверяем, есть ли доступ у пользователя к главной сущности
            var checkAccessResult = TryGetOne(GetEventsList(), localization.EventId, ContentAccessModelType.Events);
            if (!checkAccessResult.Success)
            {
                return new RequestResult<EventLocalization>().FillFromRequestResult(checkAccessResult);
            }

            return new RequestResult<EventLocalization>().SetSuccess(localization);
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

            var baseCheckResult = CheckLocalizationModelBeforeCreate(localization, mainEntity, ContentAccessModelType.Events);
            if (!baseCheckResult.Success)
            {
                return new RequestResult<EventLocalization>().FillFromRequestResult(baseCheckResult);
            }
            var finalCheckResult = await CheckAndPrepareEventLocalization(localization);
            if (!finalCheckResult.Success)
            {
                return new RequestResult<EventLocalization>().FillFromRequestResult(finalCheckResult);
            }



            mainEntity.Localizations.Add(localization);
            DB.Events.Update(mainEntity);
            DB.SaveChanges();

            return new RequestResult<EventLocalization>().SetSuccess(localization);
        }



        [HttpPut, Route("UpdateEventMain")]
        public async Task<RequestResult<Event>> UpdateEventMain(EventMainEditModel model)
        {
            var res = new RequestResult<Event>();

            if (!DB.Languages.Any(o => o.Id == model.MainLanguageId && !o.IsDeleted))
            {
                return res.SetError(404, "Языка с данным id не существует");
            }



            var baseCheckResult = CheckMainModelBeforeUpdate(GetEventsList(), model, ContentAccessModelType.Events);
            if (!baseCheckResult.Success)
            {
                return baseCheckResult;
            }
            var item = baseCheckResult.Value;

            var fullCheckResult = await CheckAndPrepareEventBeforeUpdate(item, model);
            if (!fullCheckResult.Success)
            {
                return res.FillFromRequestResult(fullCheckResult);
            }


            return UpdateModel(DB.Events, model, item);
        }

        [HttpPost, Route("UpdateEventLocalization")]
        public async Task<RequestResult<EventLocalization>> UpdateEventLocalization(EventLocalizationEditModel model)
        {
            var res = new RequestResult<EventLocalization>();

            var localization = DB.EventLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            if (localization == null)
            {
                return res.SetError(404, "Локализация с данным id не найдена");
            }

            var checkResult = CheckLocalizationModelBeforeUpdate(GetEventsList(), model, localization.EventId, ContentAccessModelType.Events);
            if (!checkResult.Success)
            {
                return res.FillFromRequestResult(checkResult);
            }

            if(localization.ImgPath != model.ImgPath)
            {
                //Загрузка главной картинки
                var mainFileUploadResult = await TryUploadFile($"localization_{localization.LanguageId}_mainImg", FileType.Image);
                if (!mainFileUploadResult.Success)
                {
                    return res.FillFromRequestResult(mainFileUploadResult);
                }
                localization.ImgPath = mainFileUploadResult.Value;
            }

            return UpdateModel(DB.EventLocalizations, model, localization);
        }







        [HttpDelete, Route("DeleteEvent")]
        public async Task<RequestResult> DeleteEvent(int id)
        {
            var res = new RequestResult();

            var item = GetEventsList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (item == null)
            {
                return res.SetError(404, "Запись по данному id не найдена");
            }

            return TryDelete(DB.Events, item, ContentAccessModelType.Events);
        }

        [HttpDelete, Route("DeleteEventLocalization")]
        public async Task<RequestResult> DeleteEventLocalization(int id)
        {
            var res = new RequestResult();

            var item = DB.EventLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (item == null)
            {
                return res.SetError(404, "Запись по данному id не найдена");
            }
            var checkResult = CheckLocalizationModelBeforeDelete(GetEventsList(), item.EventId, ContentAccessModelType.Events);
            if (!checkResult.Success)
            {
                return checkResult;
            }

            return DeleteModel(DB.EventLocalizations, item, false);
        }


        #endregion 

        #region Категории событий

        [HttpGet, Route("GetEventCategories")]
        public async Task<RequestResult<IEnumerable<EventCategoryClientModel>>> GetEventCategories(int offset, int count = 20)
        {
            var res = new RequestResult<IEnumerable<EventCategoryClientModel>>();

            var tryGetManyResponse = TryGetMany(GetEventCategoriesList(), ContentAccessModelType.Events, offset, count);
            if (!tryGetManyResponse.Success)
            {
                return res.FillFromRequestResult(tryGetManyResponse);
            }

            var models = EventCategoryClientModel.CreateItems(tryGetManyResponse.Value.ToList(), LanguageId);
            return res.SetSuccess(models);
        }

        [HttpGet, Route("GetEventCategory")]
        public async Task<RequestResult<EventCategory>> GetEventCategory(int id)
        {
            return TryGetOne(GetEventCategoriesList(), id, ContentAccessModelType.Events);
        }
        [HttpGet, Route("GetEventCategoryLocalization")]
        public async Task<RequestResult<EventCategoryLocalization>> GetEventCategoryLocalization(int id)
        {
            var localization = DB.EventCategoryLocalizations.Include(o => o.Language)
                                                            .FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (localization == null)
            {
                return new RequestResult<EventCategoryLocalization>().SetError(404, "Локализация с данным id не найдена");
            }

            //Проверяем, есть ли доступ у пользователя к главной сущности
            var checkAccessResult = TryGetOne(GetEventCategoriesList(), localization.EventCategoryId, ContentAccessModelType.Events);
            if (!checkAccessResult.Success)
            {
                return new RequestResult<EventCategoryLocalization>().FillFromRequestResult(checkAccessResult);
            }

            return new RequestResult<EventCategoryLocalization>().SetSuccess(localization);
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

            var checkResult = CheckLocalizationModelBeforeCreate(localization, mainEntity, ContentAccessModelType.Events);
            if (!checkResult.Success)
            {
                return new RequestResult<EventCategoryLocalization>().FillFromRequestResult(checkResult);
            }

            mainEntity.Localizations.Add(localization);
            DB.EventCategories.Update(mainEntity);
            DB.SaveChanges();

            return new RequestResult<EventCategoryLocalization>().SetSuccess(localization);
        }




        [HttpPut, Route("UpdateEventCategoryMain")]
        public async Task<RequestResult<EventCategory>> UpdateEventCategoryMain(EventCategoryMainEditModel model)
        {
            var res = new RequestResult<EventCategory>();

            var baseCheckResult = CheckMainModelBeforeUpdate(GetEventCategoriesList(), model, ContentAccessModelType.Events);
            if (!baseCheckResult.Success) return baseCheckResult;
            var item = baseCheckResult.Value;


            if (!DB.Languages.Any(o => o.Id == model.MainLanguageId && !o.IsDeleted))
            {
                return res.SetError(404, "Языка с данным id не существует");
            }
            else
            {
                return UpdateModel(DB.EventCategories, model, item);
            }
        }

        [HttpPut, Route("UpdateEventCategoryLocalization")]
        public async Task<RequestResult<EventCategoryLocalization>> UpdatePostCategoryLocalization(EventCategoryLocalizationEditModel model)
        {
            var res = new RequestResult<EventCategoryLocalization>();

            var localization = DB.EventCategoryLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            if (localization == null)
            {
                return res.SetError(404, "Локализация с данным id не найдена");
            }

            var checkResult = CheckLocalizationModelBeforeUpdate(GetEventCategoriesList(), model, localization.EventCategoryId, ContentAccessModelType.Events);
            if (!checkResult.Success)
            {
                return res.FillFromRequestResult(checkResult);
            }

            return UpdateModel(DB.EventCategoryLocalizations, model, localization);
        }






        [HttpDelete, Route("DeleteEventCategory")]
        public async Task<RequestResult> DeleteEventCategory(int id)
        {
            var res = new RequestResult();

            var item = GetEventCategoriesList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (item == null)
            {
                return res.SetError(404, "Запись по данному id не найдена");
            }

            return TryDelete(DB.EventCategories, item, ContentAccessModelType.Events);
        }

        [HttpDelete, Route("DeleteEventCategoryLocalization")]
        public async Task<RequestResult> DeleteEventCategoryLocalization(int id)
        {
            var res = new RequestResult();

            var item = DB.EventCategoryLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (item == null)
            {
                return res.SetError(404, "Запись по данному id не найдена");
            }
            var checkResult = CheckLocalizationModelBeforeDelete(GetEventCategoriesList(), item.EventCategoryId, ContentAccessModelType.Events);
            if (!checkResult.Success)
            {
                return checkResult;
            }

            return DeleteModel(DB.EventCategoryLocalizations, item, false);
        }

        #endregion

        #region Форматы событий

        [HttpGet, Route("GetEventFormats")]
        public async Task<RequestResult<IEnumerable<EventFormatClientModel>>> GetEventFormats(int offset, int count = 20)
        {
            var res = new RequestResult<IEnumerable<EventFormatClientModel>>();

            var tryGetManyResponse = TryGetMany(GetEventFormatsList(), ContentAccessModelType.Events, offset, count);
            if (!tryGetManyResponse.Success)
            {
                return res.FillFromRequestResult(tryGetManyResponse);
            }

            var models = EventFormatClientModel.CreateItems(tryGetManyResponse.Value.ToList(), LanguageId);
            return res.SetSuccess(models);
        }

        [HttpGet, Route("GetEventFormat")]
        public async Task<RequestResult<EventFormat>> GetEventFormat(int id)
        {
            return TryGetOne(GetEventFormatsList(), id, ContentAccessModelType.Events);
        }

        [HttpGet, Route("GetEventFormatLocalization")]
        public async Task<RequestResult<EventFormatLocalization>> GetEventFormatLocalization(int id)
        {
            var localization = DB.EventFormatLocalizations.Include(o => o.Language)
                                                          .FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (localization == null)
            {
                return new RequestResult<EventFormatLocalization>().SetError(404, "Локализация с данным id не найдена");
            }

            //Проверяем, есть ли доступ у пользователя к главной сущности
            var checkAccessResult = TryGetOne(GetEventFormatsList(), localization.EventFormatId, ContentAccessModelType.Events);
            if (!checkAccessResult.Success)
            {
                return new RequestResult<EventFormatLocalization>().FillFromRequestResult(checkAccessResult);
            }

            return new RequestResult<EventFormatLocalization>().SetSuccess(localization);
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

            var checkResult = CheckLocalizationModelBeforeCreate(localization, mainEntity, ContentAccessModelType.Events);
            if (!checkResult.Success)
            {
                return new RequestResult<EventFormatLocalization>().FillFromRequestResult(checkResult);
            }

            mainEntity.Localizations.Add(localization);
            DB.EventFormats.Update(mainEntity);
            DB.SaveChanges();

            return new RequestResult<EventFormatLocalization>().SetSuccess(localization);
        }





        [HttpPut, Route("UpdateEventFormatMain")]
        public async Task<RequestResult<EventFormat>> UpdateEventFormatMain(EventFormatMainEditModel model)
        {
            var res = new RequestResult<EventFormat>();

            var baseCheckResult = CheckMainModelBeforeUpdate(GetEventFormatsList(), model, ContentAccessModelType.Events);
            if (!baseCheckResult.Success) return baseCheckResult;
            var item = baseCheckResult.Value;


            if (!DB.Languages.Any(o => o.Id == model.MainLanguageId && !o.IsDeleted))
            {
                return res.SetError(404, "Языка с данным id не существует");
            }
            else
            {
                return UpdateModel(DB.EventFormats, model, item);
            }
        }

        [HttpPut, Route("UpdateEventFormatLocalization")]
        public async Task<RequestResult<EventFormatLocalization>> UpdateEventFormatLocalization(EventFormatLocalizationEditModel model)
        {
            var res = new RequestResult<EventFormatLocalization>();

            var localization = DB.EventFormatLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            if (localization == null)
            {
                return res.SetError(404, "Локализация с данным id не найдена");
            }

            var checkResult = CheckLocalizationModelBeforeUpdate(GetEventCategoriesList(), model, localization.EventFormatId, ContentAccessModelType.Events);
            if (!checkResult.Success)
            {
                return res.FillFromRequestResult(checkResult);
            }

            return UpdateModel(DB.EventFormatLocalizations, model, localization);
        }
   
      




        [HttpDelete, Route("DeleteEventFormat")]
        public async Task<RequestResult> DeleteEventFormat(int id)
        {
            var res = new RequestResult();

            var item = GetEventFormatsList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (item == null)
            {
                return res.SetError(404, "Запись по данному id не найдена");
            }

            return TryDelete(DB.EventFormats, item, ContentAccessModelType.Events);
        }

        [HttpDelete, Route("DeleteEventFormatLocalization")]
        public async Task<RequestResult> DeleteEventFormatLocalization(int id)
        {
            var res = new RequestResult();

            var item = DB.EventFormatLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (item == null)
            {
                return res.SetError(404, "Запись по данному id не найдена");
            }
            var checkResult = CheckLocalizationModelBeforeDelete(GetEventFormatsList(), item.EventFormatId, ContentAccessModelType.Events);
            if (!checkResult.Success)
            {
                return checkResult;
            }

            return DeleteModel(DB.EventFormatLocalizations, item, false);
        }


        #endregion


        [HttpPut, Route("UpdateAvailability")]
        public async Task<RequestResult<Availability>> UpdateAvailability(AvailabilityEditModel model)
        {
            bool hasThisModel = false;
            hasThisModel |= DB.Events.Any(o => o.AvailabilityId == model.Id && !o.IsDeleted);
            hasThisModel |= DB.EventCategories.Any(o => o.AvailabilityId == model.Id && !o.IsDeleted);
            hasThisModel |= DB.EventFormats.Any(o => o.AvailabilityId == model.Id && !o.IsDeleted);

            if (!hasThisModel)
            {
                return new RequestResult<Availability>().SetError(403, "У данного пользователя нет прав на редактирование матрицы доступности");
            }

            return TryUpdateAvailability(model, ContentAccessModelType.Events);
        }


        #region Private methods

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
                var localizationCheckResult = await CheckAndPrepareEventLocalization(localization);
                if (!localizationCheckResult.Success)
                {
                    return localizationCheckResult;
                }
            }

            return RequestResult.AsSuccess();
        }
        private async Task<RequestResult> CheckAndPrepareEventBeforeUpdate(Event item,EventMainEditModel model)
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


        private async Task<RequestResult> CheckAndPrepareEventLocalization(EventLocalization localization)
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

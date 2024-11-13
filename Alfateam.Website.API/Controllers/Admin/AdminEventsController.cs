using Alfateam.CRM2_0.Models.Security;
using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Core;
using Alfateam.Website.API.Enums;
using Alfateam.Core.Exceptions;
using Alfateam.Website.API.Extensions;
using Alfateam.Website.API.Filters;
using Alfateam.Website.API.Filters.Access;
using Alfateam.Website.API.Models;
using Alfateam.Website.API.Models.DTO.Events;
using Alfateam.Website.API.Models.DTO.General;
using Alfateam.Website.API.Models.DTOLocalization;
using Alfateam.Website.API.Models.DTOLocalization.Events;
using Alfateam.Core.Results.StatusCodes;
using Alfateam.Website.API.Services;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.Events;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Localization.Items.Events;
using Microsoft.AspNetCore.Mvc;
using Alfateam.Core.Enums;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Net;
using Alfateam.Website.API.Filters.AdminSearch;
using Alfateam.Core;
using Alfateam.Website.API.Models.DTO;
using Alfateam2._0.Models;

namespace Alfateam.Website.API.Controllers.Admin
{
    public class AdminEventsController : AbsAdminController
    {
        public AdminEventsController(ControllerParams @params) : base(@params)
        {
        }



        #region События



        [HttpGet, Route("GetEvents")]
        [CheckContentAreaRights(ContentAccessModelType.Events, 1)]
        public async Task<ItemsWithTotalCount<EventDTO>> GetEvents(int offset, int count = 20)
        {
            return DbService.GetManyWithTotalCount<Event, EventDTO>(GetAvailableEvents(), offset, count);
        }

        [HttpGet, Route("GetEventsFiltered")]
        [CheckContentAreaRights(ContentAccessModelType.Events, 1)]
        public async Task<ItemsWithTotalCount<EventDTO>> GetEventsFiltered([FromQuery] EventsSearchFilter filter)
        {
            return DbService.GetManyWithTotalCount<Event, EventDTO>(filter.Filter(GetAvailableEvents()), filter.Offset, filter.Count, (entity) =>
            {
                return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
            });
        }


        [HttpGet, Route("GetEvent")]
        [CheckContentAreaRights(ContentAccessModelType.Events, 1)]
        public async Task<EventDTO> GetEvent(int id)
        {
            return (EventDTO)DbService.TryGetOne(GetAvailableEvents(), id, new EventDTO());
        }




        [HttpGet, Route("GetEventLocalizations")]
        [CheckContentAreaRights(ContentAccessModelType.Events, 1)]
        public async Task<IEnumerable<EventLocalizationDTO>> GetEventLocalizations(int id)
        {
            var localizations = DB.EventLocalizations.Include(o => o.LanguageEntity).Where(o => o.EventId == id && !o.IsDeleted);
            var mainEntity = GetAvailableEvents().FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            return DbService.GetLocalizationModels(localizations, mainEntity, new EventLocalizationDTO()).Cast<EventLocalizationDTO>();
        }


        [HttpGet, Route("GetEventLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Events, 1)]
        public async Task<EventLocalizationDTO> GetEventLocalization(int id)
        {
            var localization = DB.EventLocalizations.Include(o => o.LanguageEntity).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainEntity = GetAvailableEvents().FirstOrDefault(o => o.Id == localization?.EventId && !o.IsDeleted);

            return (EventLocalizationDTO)DbService.GetLocalizationModel(localization, mainEntity, new EventLocalizationDTO());
        }




        [SwaggerOperation(description: "Нужно загрузить изображение через форму с именем mainImg")]
        [HttpPost, Route("CreateEvent")]
        [CheckContentAreaRights(ContentAccessModelType.Events, 4)]
        public async Task<EventDTO> CreateEvent([FromForm(Name = "model")] EventDTO model)
        {
            return (EventDTO)DbService.TryCreateAvailabilityEntity(DB.Events, model, this.Session, (entity) =>
            {
                HandleEventModel(entity, DBModelFillMode.Create);
            });
        }

        [SwaggerOperation(description: "Нужно загрузить изображение через форму с именем localization_{languageEntityId}_mainImg")]
        [HttpPost, Route("CreateEventLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Events, 3)]
        public async Task<EventLocalizationDTO> CreateEventLocalization(int itemId, [FromForm(Name = "localization")] EventLocalizationDTO localization)
        {
            var mainEntity = GetAvailableEvents().FirstOrDefault(o => o.Id == itemId);
            return (EventLocalizationDTO)DbService.TryCreateLocalizationEntity(DB.Events, mainEntity, localization, (entity) =>
            {
                HandleEventLocalizationModel(entity, DBModelFillMode.Create);
            });
        }




        [SwaggerOperation(description: "Нужно загрузить изображение через форму с именем mainImg, если изменяем картинку")]
        [HttpPut, Route("UpdateEventMain")]
        [CheckContentAreaRights(ContentAccessModelType.Events, 3)]
        public async Task<EventDTO> UpdateEventMain([FromForm(Name = "model")] EventDTO model)
        {
            var item = GetAvailableEvents().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (EventDTO)DbService.TryUpdateEntity(DB.Events, model, item, (entity) =>
            {
                HandleEventModel(entity, DBModelFillMode.Update);
            });
        }

        [SwaggerOperation(description: "Нужно загрузить изображение через форму с именем localization_{languageEntityId}_mainImg, если изменяем картинку")]
        [HttpPost, Route("UpdateEventLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Events, 3)]
        public async Task<EventLocalizationDTO> UpdateEventLocalization([FromForm(Name = "model")] EventLocalizationDTO model)
        {
            var localization = DB.EventLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            var mainEntity = GetAvailableEvents().FirstOrDefault(o => o.Id == localization.EventId && !o.IsDeleted);

            return (EventLocalizationDTO)DbService.TryUpdateLocalizationEntity(DB.EventLocalizations, localization, model, mainEntity, (entity) =>
            {
                HandleEventLocalizationModel(entity, DBModelFillMode.Update);
            });
        }







        [HttpDelete, Route("DeleteEvent")]
        [CheckContentAreaRights(ContentAccessModelType.Events, 5)]
        public async Task DeleteEvent(int id)
        {
            var item = GetAvailableEvents().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DbService.TryDeleteEntity(DB.Events, item);
        }

        [HttpDelete, Route("DeleteEventLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Events, 5)]
        public async Task DeleteEventLocalization(int id)
        {
            var item = DB.EventLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainModel = GetAvailableEvents().FirstOrDefault(o => o.Id == item.EventId && !o.IsDeleted);

            DbService.TryDeleteLocalizationEntity(DB.EventLocalizations, item, mainModel);
        }


        #endregion

        #region Категории событий



        [HttpGet, Route("GetEventCategories")]
        [CheckContentAreaRights(ContentAccessModelType.Events, 1)]
        public async Task<ItemsWithTotalCount<EventCategoryDTO>> GetEventCategories(int offset, int count = 20)
        {
            return DbService.GetManyWithTotalCount<EventCategory, EventCategoryDTO>(GetAvailableEventCategories(), offset, count);
        }

        [HttpGet, Route("GetEventCategoriesFiltered")]
        [CheckContentAreaRights(ContentAccessModelType.Events, 1)]
        public async Task<ItemsWithTotalCount<EventCategoryDTO>> GetEventCategoriesFiltered([FromQuery] SearchFilter filter)
        {
            return DbService.GetManyWithTotalCount<EventCategory, EventCategoryDTO>(GetAvailableEventCategories(), filter.Offset, filter.Count, (entity) =>
            {
                return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
            });
        }


        [HttpGet, Route("GetEventCategory")]
        [CheckContentAreaRights(ContentAccessModelType.Events, 1)]
        public async Task<EventCategoryDTO> GetEventCategory(int id)
        {
            return (EventCategoryDTO)DbService.TryGetOne(GetAvailableEventCategories(), id, new EventCategoryDTO());
        }

        [HttpGet, Route("GetEventCategoryLocalizations")]
        [CheckContentAreaRights(ContentAccessModelType.Events, 1)]
        public async Task<IEnumerable<EventCategoryLocalizationDTO>> GetEventCategoryLocalizations(int id)
        {
            var localizations = DB.EventCategoryLocalizations.Include(o => o.LanguageEntity).Where(o => o.EventCategoryId == id && !o.IsDeleted);
            var mainEntity = GetAvailableEventCategories().FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            return DbService.GetLocalizationModels(localizations, mainEntity, new EventCategoryLocalizationDTO()).Cast<EventCategoryLocalizationDTO>();
        }

        [HttpGet, Route("GetEventCategoryLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Events, 1)]
        public async Task<EventCategoryLocalizationDTO> GetEventCategoryLocalization(int id)
        {
            var localization = DB.EventCategoryLocalizations.Include(o => o.LanguageEntity).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainEntity = GetAvailableEventCategories().FirstOrDefault(o => o.Id == localization?.EventCategoryId && !o.IsDeleted);

            return (EventCategoryLocalizationDTO)DbService.GetLocalizationModel(localization, mainEntity, new EventCategoryLocalizationDTO());
        }






        [HttpPost, Route("CreateEventCategory")]
        [CheckContentAreaRights(ContentAccessModelType.Events, 4)]
        public async Task<EventCategoryDTO> CreateEventCategory(EventCategoryDTO model)
        {
            return (EventCategoryDTO)DbService.TryCreateAvailabilityEntity(DB.EventCategories, model, this.Session);
        }

        [HttpPost, Route("CreateEventCategoryLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Events, 3)]
        public async Task<EventCategoryLocalizationDTO> CreateEventCategoryLocalization(int itemId, EventCategoryLocalizationDTO localization)
        {
            var mainEntity = GetAvailableEventCategories().FirstOrDefault(o => o.Id == itemId);
            return (EventCategoryLocalizationDTO)DbService.TryCreateLocalizationEntity(DB.EventCategories, mainEntity, localization);
        }






        [HttpPut, Route("UpdateEventCategoryMain")]
        [CheckContentAreaRights(ContentAccessModelType.Events, 3)]
        public async Task<EventCategoryDTO> UpdateEventCategoryMain(EventCategoryDTO model)
        {
            var item = GetAvailableEventCategories().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (EventCategoryDTO)DbService.TryUpdateEntity(DB.EventCategories, model, item);
        }


        [HttpPut, Route("UpdateEventCategoryLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Events, 3)]
        public async Task<EventCategoryLocalizationDTO> UpdateEventCategoryLocalization(EventCategoryLocalizationDTO model)
        {
            var localization = DB.EventCategoryLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            var mainEntity = GetAvailableEventCategories().FirstOrDefault(o => o.Id == localization.EventCategoryId && !o.IsDeleted);

            return (EventCategoryLocalizationDTO)DbService.TryUpdateLocalizationEntity(DB.EventCategoryLocalizations, localization, model, mainEntity);
        }








        [HttpDelete, Route("DeleteEventCategory")]
        [CheckContentAreaRights(ContentAccessModelType.Events, 5)]
        public async Task DeleteEventCategory(int id)
        {
            var item = GetAvailableEventCategories().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DbService.TryDeleteEntity(DB.EventCategories, item);
        }


        [HttpDelete, Route("DeleteEventCategoryLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Events, 5)]
        public async Task DeleteEventCategoryLocalization(int id)
        {
            var item = DB.EventCategoryLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainModel = DB.EventCategories.FirstOrDefault(o => o.Id == item.EventCategoryId && !o.IsDeleted);

            DbService.TryDeleteLocalizationEntity(DB.EventCategoryLocalizations, item, mainModel);
        }

        #endregion

        #region Форматы событий


        [HttpGet, Route("GetEventFormatsCount")]
        public async Task<int> GetEventFormatsCount()
        {
            return GetAvailableEventFormats().Count();
        }



        [HttpGet, Route("GetEventFormats")]
        [CheckContentAreaRights(ContentAccessModelType.Events, 1)]
        public async Task<ItemsWithTotalCount<EventFormatDTO>> GetEventFormats(int offset, int count = 20)
        {
            return DbService.GetManyWithTotalCount<EventFormat, EventFormatDTO>(GetAvailableEventFormats(), offset, count);
        }
        [HttpGet, Route("GetEventFormatsFiltered")]
        [CheckContentAreaRights(ContentAccessModelType.Events, 1)]
        public async Task<ItemsWithTotalCount<EventFormatDTO>> GetEventFormatsFiltered([FromQuery] SearchFilter filter)
        {
            return DbService.GetManyWithTotalCount<EventFormat, EventFormatDTO>(GetAvailableEventFormats(), filter.Offset, filter.Count, (entity) =>
            {
                return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
            });
        }


        [HttpGet, Route("GetEventFormat")]
        [CheckContentAreaRights(ContentAccessModelType.Events, 1)]
        public async Task<EventFormatDTO> GetEventFormat(int id)
        {
            return (EventFormatDTO)DbService.TryGetOne(GetAvailableEventFormats(), id, new EventFormatDTO());
        }


        [HttpGet, Route("GetEventFormatLocalizations")]
        [CheckContentAreaRights(ContentAccessModelType.Events, 1)]
        public async Task<IEnumerable<EventFormatLocalizationDTO>> GetEventFormatLocalizations(int id)
        {
            var localizations = DB.EventFormatLocalizations.Include(o => o.LanguageEntity).Where(o => o.EventFormatId == id && !o.IsDeleted);
            var mainEntity = GetAvailableEventFormats().FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            return DbService.GetLocalizationModels(localizations, mainEntity, new EventFormatLocalizationDTO()).Cast<EventFormatLocalizationDTO>();
        }

        [HttpGet, Route("GetEventFormatLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Events, 1)]
        public async Task<EventFormatLocalizationDTO> GetEventFormatLocalization(int id)
        {
            var localization = DB.EventFormatLocalizations.Include(o => o.LanguageEntity).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainEntity = GetAvailableEventFormats().FirstOrDefault(o => o.Id == localization?.EventFormatId && !o.IsDeleted);

            return (EventFormatLocalizationDTO)DbService.GetLocalizationModel(localization, mainEntity, new EventFormatLocalizationDTO());
        }




        [HttpPost, Route("CreateEventFormat")]
        [CheckContentAreaRights(ContentAccessModelType.Events, 4)]
        public async Task<EventFormatDTO> CreateEventFormat(EventFormatDTO model)
        {
            return (EventFormatDTO)DbService.TryCreateAvailabilityEntity(DB.EventFormats, model, this.Session);
        }
     
        [HttpPost, Route("CreateEventFormatLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Events, 3)]
        public async Task<EventFormatLocalizationDTO> CreateEventFormatLocalization(int itemId, EventFormatLocalizationDTO localization)
        {
            var mainEntity = GetAvailableEventFormats().FirstOrDefault(o => o.Id == itemId);
            return (EventFormatLocalizationDTO)DbService.TryCreateLocalizationEntity(DB.EventFormats, mainEntity, localization);
        }





        [HttpPut, Route("UpdateEventFormatMain")]
        [CheckContentAreaRights(ContentAccessModelType.Events, 3)]
        public async Task<EventFormatDTO> UpdateEventFormatMain(EventFormatDTO model)
        {
            var item = GetAvailableEventFormats().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (EventFormatDTO)DbService.TryUpdateEntity(DB.EventFormats, model, item);
        }


        [HttpPut, Route("UpdateEventFormatLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Events, 3)]
        public async Task<EventFormatLocalizationDTO> UpdateEventFormatLocalization(EventFormatLocalizationDTO model)
        {
            var localization = DB.EventFormatLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            var mainEntity = GetAvailableEventFormats().FirstOrDefault(o => o.Id == localization.EventFormatId && !o.IsDeleted);

            return (EventFormatLocalizationDTO)DbService.TryUpdateLocalizationEntity(DB.EventFormatLocalizations, localization, model, mainEntity);
        }
   
      






        [HttpDelete, Route("DeleteEventFormat")]
        [CheckContentAreaRights(ContentAccessModelType.Events, 5)]
        public async Task DeleteEventFormat(int id)
        {
            var item = GetAvailableEventFormats().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DbService.TryDeleteEntity(DB.EventFormats, item);
        }


        [HttpDelete, Route("DeleteEventFormatLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Events, 5)]
        public async Task DeleteEventFormatLocalization(int id)
        {
            var item = DB.EventFormatLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainModel = DB.EventFormats.FirstOrDefault(o => o.Id == item.EventFormatId && !o.IsDeleted);

            DbService.TryDeleteLocalizationEntity(DB.EventFormatLocalizations, item, mainModel);
        }


        #endregion


        [HttpPut, Route("UpdateAvailability")]
        [CheckContentAreaRights(ContentAccessModelType.Events, 2)]
        public async Task<AvailabilityDTO> UpdateAvailability(AvailabilityDTO model)
        {
            bool hasThisModel = false;

            hasThisModel |= DbService.GetAvailableModels(this.Session.User, DB.Events.IncludeAvailability())
                                     .Any(o => o.AvailabilityId == model.Id && !o.IsDeleted);
            hasThisModel |= DbService.GetAvailableModels(this.Session.User, DB.EventCategories.IncludeAvailability())
                                     .Any(o => o.AvailabilityId == model.Id && !o.IsDeleted);
            hasThisModel |= DbService.GetAvailableModels(this.Session.User, DB.EventFormats.IncludeAvailability())
                                     .Any(o => o.AvailabilityId == model.Id && !o.IsDeleted);

            if (!hasThisModel)
            {
                throw new Exception403("У данного пользователя нет прав на редактирование матрицы доступности");
            }

            return DbService.TryUpdateAvailability(model, this.Session);
        }







        #region Private get available methods
        private IEnumerable<Event> GetAvailableEvents()
        {
            return DbService.GetAvailableModels(this.Session.User, GetEventsList()).Cast<Event>();
        }
        private IEnumerable<EventCategory> GetAvailableEventCategories()
        {
            return DbService.GetAvailableModels(this.Session.User, GetEventCategoriesList()).Cast<EventCategory>();
        }
        private IEnumerable<EventFormat> GetAvailableEventFormats()
        {
            return DbService.GetAvailableModels(this.Session.User, GetEventFormatsList()).Cast<EventFormat>();
        }

        #endregion

        #region Private prepare methods

        private void HandleEventModel(Event entity, DBModelFillMode mode)
        {
            const string formFilename = "mainImg";

            if (!DB.EventFormats.Any(o => o.Id == entity.FormatId && !o.IsDeleted))
            {
                throw new Exception400("Формат события с данным id не найден");
            }
            else if (!DB.EventCategories.Any(o => o.Id == entity.CategoryId && !o.IsDeleted))
            {
                throw new Exception400("Категория событий с данным id не найдена");
            }
            else if (!DB.TimeZones.Any(o => o.Id == entity.TimeZoneId && !o.IsDeleted))
            {
                throw new Exception400("Часовой пояс с данным id не найден");
            }

            if((mode == DBModelFillMode.Update && FilesService.IsFileUploaded(formFilename))
                || mode == DBModelFillMode.Create)
            {
                entity.ImgPath = FilesService.TryUploadFile(formFilename, FileType.Image);
            }


        }
        private void HandleEventLocalizationModel(EventLocalization entity, DBModelFillMode mode)
        {
            string formFilename = $"localization_{entity.LanguageEntityId}_mainImg";
         
            if (!DB.Languages.Any(o => o.Id == entity.LanguageEntityId && !o.IsDeleted))
            {
                throw new Exception400("Язык с данным id не существует");
            }


            if ((mode == DBModelFillMode.Update && FilesService.IsFileUploaded(formFilename))
               || mode == DBModelFillMode.Create)
            {
                entity.ImgPath = FilesService.TryUploadFile(formFilename, FileType.Image);
            }
        }

        #endregion

        #region Private get included methods
        private IQueryable<Event> GetEventsList()
        {
            return DB.Events.IncludeAvailability()
                            .Include(o => o.TimeZone)
                            .Include(o => o.Category).ThenInclude(o => o.MainLanguage)
                            .Include(o => o.Category).ThenInclude(o => o.Localizations).ThenInclude(o => o.LanguageEntity)
                            .Include(o => o.Format).ThenInclude(o => o.MainLanguage)
                            .Include(o => o.Format).ThenInclude(o => o.Localizations).ThenInclude(o => o.LanguageEntity)
                            .Include(o => o.Localizations).ThenInclude(o => o.LanguageEntity)
                            .Include(o => o.MainLanguage)
                            .Where(o => !o.IsDeleted);
        }
        private IQueryable<EventCategory> GetEventCategoriesList()
        {
            return DB.EventCategories.IncludeAvailability()
                                     .Include(o => o.Localizations).ThenInclude(o => o.LanguageEntity)
                                     .Include(o => o.MainLanguage)
                                     .Where(o => !o.IsDeleted);
        }
        private IQueryable<EventFormat> GetEventFormatsList()
        {
            return DB.EventFormats.IncludeAvailability()
                                  .Include(o => o.Localizations).ThenInclude(o => o.LanguageEntity)
                                  .Include(o => o.MainLanguage)
                                  .Where(o => !o.IsDeleted);
        }

        #endregion

    }
}

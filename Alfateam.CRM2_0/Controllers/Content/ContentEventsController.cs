using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Enums;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.ClientModels.Content.Events;
using Alfateam.CRM2_0.Models.ClientModels.Content.Videos;
using Alfateam.CRM2_0.Models.Content.Events;
using Alfateam.CRM2_0.Models.Content.Videos;
using Alfateam.CRM2_0.Models.EditModels.Content.Events;
using Alfateam.CRM2_0.Models.EditModels.Content.Videos;
using Alfateam.CRM2_0.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.CRM2_0.Controllers.Content
{
    [AccessActionFilter(roles: UserRole.ContentMaker)]
    public class ContentEventsController : AbsController
    {
        public ContentEventsController(ControllerParams @params) : base(@params)
        {
        }

        #region События
        [HttpGet, Route("GetEvents")]
        public async Task<RequestResult> GetEvents(int offset, int count = 20)
        {
            return GetAvailableMany<Event, EventClientModel>(DB.Events, offset, count);
        }

        [HttpGet, Route("GetEditableEvents")]
        [AccessActionFilter(roles: UserRole.ContentMaker)]
        public async Task<RequestResult> GetEditableEvents(int offset, int count = 20)
        {
            return GetAvailableEditableMany<Event, EventClientModel>(DB.Events, offset, count);
        }

        [HttpGet, Route("GetEventCategory")]
        [AccessActionFilter(roles: UserRole.ContentMaker)]
        public async Task<RequestResult> GetEvent(int id)
        {
            return TryGetContentModel(DB.Events, id);
        }



        [HttpPost, Route("CreateEvent")]
        [AccessActionFilter(roles: UserRole.ContentMaker)]
        public async Task<RequestResult> CreateEvent(EventEditModel model)
        {
            return TryCreateContentModel("Events", model, PrepareEventBeforeCreate);
        }



        [HttpPut, Route("UpdateEvent")]
        [AccessActionFilter(roles: UserRole.ContentMaker)]
        public async Task<RequestResult> UpdateEvent(EventEditModel model)
        {
            return TryUpdateContentModel(DB.Events, model, PrepareEventBeforeUpdate);
        }




        [HttpDelete, Route("DeleteEvent")]
        [AccessActionFilter(roles: UserRole.ContentMaker)]
        public async Task<RequestResult> DeleteEvent(int id)
        {
            return TryDeleteContentModel(DB.Events, id);
        }



        #endregion

        #region Категории событий

        [HttpGet, Route("GetEventCategories")]
        public async Task<RequestResult> GetEventCategories(int offset, int count = 20)
        {
            return GetAvailableMany<EventCategory, EventCategoryClientModel>(DB.EventCategories, offset, count);
        }

        [HttpGet, Route("GetEditableEventCategories")]
        [AccessActionFilter(roles: UserRole.ContentMaker)]
        public async Task<RequestResult> GetEditableEventCategories(int offset, int count = 20)
        {
            return GetAvailableEditableMany<EventCategory, EventCategoryClientModel>(DB.EventCategories, offset, count);
        }

        [HttpGet, Route("GetEventCategory")]
        [AccessActionFilter(roles: UserRole.ContentMaker)]
        public async Task<RequestResult> GetEventCategory(int id)
        {
            return TryGetContentModel(DB.EventCategories, id);
        }




        [HttpPost, Route("CreateEventCategory")]
        [AccessActionFilter(roles: UserRole.ContentMaker)]
        public async Task<RequestResult> CreateEventCategory(EventCategoryEditModel model)
        {
            return TryCreateContentModel("EventCategories", model);
        }



        [HttpPut, Route("UpdateEventCategory")]
        [AccessActionFilter(roles: UserRole.ContentMaker)]
        public async Task<RequestResult> UpdateEventCategory(EventCategoryEditModel model)
        {
            return TryUpdateContentModel(DB.EventCategories, model);
        }


        [HttpDelete, Route("DeleteEventCategory")]
        [AccessActionFilter(roles: UserRole.ContentMaker)]
        public async Task<RequestResult> DeleteEventCategory(int id)
        {
            return TryDeleteContentModel(DB.EventCategories, id);
        }

        #endregion

        #region Форматы событий

        [HttpGet, Route("GetEventFormats")]
        public async Task<RequestResult> GetEventFormats(int offset, int count = 20)
        {
            return GetAvailableMany<EventFormat, EventFormatClientModel>(DB.EventFormats, offset, count);
        }

        [HttpGet, Route("GetEditableEventFormats")]
        [AccessActionFilter(roles: UserRole.ContentMaker)]
        public async Task<RequestResult> GetEditableEventFormats(int offset, int count = 20)
        {
            return GetAvailableEditableMany<EventFormat, EventFormatClientModel>(DB.EventFormats, offset, count);
        }

        [HttpGet, Route("GetEventFormat")]
        [AccessActionFilter(roles: UserRole.ContentMaker)]
        public async Task<RequestResult> GetEventFormat(int id)
        {
            return TryGetContentModel(DB.EventFormats, id);
        }




        [HttpPost, Route("CreateEventFormat")]
        [AccessActionFilter(roles: UserRole.ContentMaker)]
        public async Task<RequestResult> CreateEventFormat(EventFormatEditModel model)
        {
            return TryCreateContentModel("EventFormats", model);
        }



        [HttpPut, Route("UpdateEventFormat")]
        [AccessActionFilter(roles: UserRole.ContentMaker)]
        public async Task<RequestResult> UpdateEventFormat(EventFormatEditModel model)
        {
            return TryUpdateContentModel(DB.EventFormats, model);
        }


        [HttpDelete, Route("DeleteEventFormat")]
        [AccessActionFilter(roles: UserRole.ContentMaker)]
        public async Task<RequestResult> DeleteEventFormat(int id)
        {
            return TryDeleteContentModel(DB.EventFormats, id);
        }

        #endregion





        #region Private prepare methods

        private RequestResult PrepareEventBeforeCreate(Event item)
        {
            return UploadEventMainImg(item).Result;
        }
        private RequestResult PrepareEventBeforeUpdate(Event item)
        {
            if(Request.Form.Files.Any(o => o.Name == "mainImg"))
            {
                return UploadEventMainImg(item).Result;
            }
            return RequestResult.AsSuccess();
        }

        private async Task<RequestResult> UploadEventMainImg(Event item)
        {
            var uploadResult = TryUploadFile("mainImg", FileType.Image).Result;
            if (uploadResult.Success)
            {
                item.ImgPath = uploadResult.Value;
            }

            return uploadResult;
        }

        #endregion
    }
}

using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Enums;
using Alfateam.Core.Exceptions;
using Alfateam.Website.API.Extensions;
using Alfateam.Website.API.Filters.Access;
using Alfateam.Website.API.Models;
using Alfateam.Website.API.Models.DTO.Events;
using Alfateam.Website.API.Models.DTO.Posts;
using Alfateam.Website.API.Models.DTO.ServicePages;
using Alfateam.Website.API.Models.DTO.Shop;
using Alfateam.Website.API.Models.DTOLocalization;
using Alfateam.Website.API.Models.DTOLocalization.Events;
using Alfateam.Website.API.Models.DTOLocalization.Posts;
using Alfateam2._0.Models.Enums;
using Alfateam.Core.Enums;
using Alfateam2._0.Models.Localization.Items;
using Alfateam2._0.Models.ServicePages;
using Alfateam2._0.Models.Shop;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace Alfateam.Website.API.Controllers.Admin
{
    public class AdminServicePagesController : AbsAdminController
    {
        public AdminServicePagesController(ControllerParams @params) : base(@params)
        {
        }
         
        #region Страницы услуг и их локализации

        [HttpGet, Route("GetServicePages")]
        [CheckContentAreaRights(ContentAccessModelType.Services, 1)]
        public async Task<IEnumerable<ServicePageDTO>> GetServicePages(int offset, int count = 20)
        {
            var items = GetAvailableServicePages().Skip(offset).Take(count);
            return new ServicePageDTO().CreateDTOs(items).Cast<ServicePageDTO>();
        }

        [HttpGet, Route("GetServicePagesFiltered")]
        [CheckContentAreaRights(ContentAccessModelType.Services, 1)]
        public async Task<IEnumerable<ServicePageDTO>> GetServicePagesFiltered([FromQuery] SearchFilter filter)
        {
            var items = filter.FilterBase(GetAvailableServicePages(), (item) => item.MainBlockHeader);
            return new ServicePageDTO().CreateDTOs(items).Cast<ServicePageDTO>();
        }


        [HttpGet, Route("GetServicePage")]
        [CheckContentAreaRights(ContentAccessModelType.Services, 1)]
        public async Task<ServicePageDTO> GetServicePage(int id)
        {
            return (ServicePageDTO)DbService.TryGetOne(GetAvailableServicePages(), id, new ServicePageDTO());
        }



        [HttpGet, Route("GetServicePageLocalizations")]
        [CheckContentAreaRights(ContentAccessModelType.Services, 1)]
        public async Task<IEnumerable<ServicePageLocalizationDTO>> GetServicePageLocalizations(int id)
        {
            var localizations = GetServicePageLocalizationsIncluded().Where(o => o.ServicePageId == id && !o.IsDeleted);
            var mainEntity = GetAvailableServicePages().FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            return DbService.GetLocalizationModels(localizations, mainEntity, new ServicePageLocalizationDTO()).Cast<ServicePageLocalizationDTO>();
        }

        [HttpGet, Route("GetServicePageLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Services, 1)]
        public async Task<ServicePageLocalizationDTO> GetServicePageLocalization(int id)
        {
            var localization = GetServicePageLocalizationsIncluded().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainEntity = GetAvailableServicePages().FirstOrDefault(o => o.Id == localization?.ServicePageId && !o.IsDeleted);

            return (ServicePageLocalizationDTO)DbService.GetLocalizationModel(localization, mainEntity, new ServicePageLocalizationDTO());
        }





        [HttpPost, Route("CreateServicePage")]
        [CheckContentAreaRights(ContentAccessModelType.Services, 4)]
        [SwaggerOperation(description: "Нужно загрузить главную картинку через форму с именем mainBlockImg")]
        public async Task<ServicePageDTO> CreateServicePage([FromForm(Name = "model")] ServicePageDTO model)
        {
            return (ServicePageDTO)DbService.TryCreateAvailabilityEntity(DB.ServicePages, model, this.Session, async (entity) =>
            {
                await HandleServicePage(entity, DBModelFillMode.Create);
            });
        }
        [HttpPost, Route("CreateServicePageLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Services, 3)]
        public async Task<ServicePageLocalizationDTO> CreateServicePageLocalization(int itemId, ServicePageLocalizationDTO localization)
        {
            var mainEntity = GetAvailableServicePages().FirstOrDefault(o => o.Id == itemId);
            return (ServicePageLocalizationDTO)DbService.TryCreateLocalizationEntity(DB.ServicePages, mainEntity, localization);
        }





        [HttpPut, Route("UpdateServicePageMain")]
        [CheckContentAreaRights(ContentAccessModelType.Services, 3)]
        [SwaggerOperation(description: "Нужно загрузить главную картинку через форму с именем mainBlockImg, если изменяем изображение")]
        public async Task<ServicePageDTO> UpdateServicePageMain([FromForm(Name = "model")] ServicePageDTO model)
        {
            var item = GetAvailableServicePages().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (ServicePageDTO)DbService.TryUpdateEntity(DB.ServicePages, model, item, async (entity) =>
            {
                await HandleServicePage(entity, DBModelFillMode.Update);
            });
        }

        [HttpPut, Route("UpdateServicePageLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Services, 3)]
        public async Task<ServicePageLocalizationDTO> UpdateServicePageLocalization(ServicePageLocalizationDTO model)
        {
            var localization = DB.ServicePageLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            var mainEntity = GetAvailableServicePages().FirstOrDefault(o => o.Id == localization.ServicePageId && !o.IsDeleted);

            return (ServicePageLocalizationDTO)DbService.TryUpdateLocalizationEntity(DB.ServicePageLocalizations, localization, model, mainEntity);
        }





        [HttpDelete, Route("DeleteServicePage")]
        [CheckContentAreaRights(ContentAccessModelType.Services, 5)]
        public async Task DeleteServicePage(int id)
        {
            var item = GetAvailableServicePages().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DbService.TryDeleteEntity(DB.ServicePages, item);
        }

        [HttpDelete, Route("DeleteServicePageLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Services, 5)]
        public async Task DeleteServicePageLocalization(int id)
        {
            var item = DB.ServicePageLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainModel = GetAvailableServicePages().FirstOrDefault(o => o.Id == item.ServicePageId && !o.IsDeleted);

            DbService.TryDeleteLocalizationEntity(DB.ServicePageLocalizations, item, mainModel);
        }

        #endregion

        #region Фейковые отзывы на страницы услуг

        [HttpGet, Route("GetReview")]
        [CheckContentAreaRights(ContentAccessModelType.Services, 1)]
        public async Task<ServicePageFakeReviewDTO> GetReview(IdFor mainEntityIdFor, int mainEntityId, int itemId)
        {
            var item = DbService.TryGetOne(DB.ServicePageFakeReviews, itemId);

            CheckFrom(mainEntityIdFor, mainEntityId);
            return (ServicePageFakeReviewDTO)new ServicePageFakeReviewDTO().CreateDTO(item);
        }


        [HttpPost, Route("CreateReview")]
        [CheckContentAreaRights(ContentAccessModelType.Services, 4)]
        [SwaggerOperation(description: "Нужно загрузить аватар через форму с именем avatarImg")]
        public async Task<ServicePageFakeReviewDTO> CreateReview(IdFor mainEntityIdFor, int mainEntityId, [FromForm(Name = "model")] ServicePageFakeReviewDTO model)
        {
            CheckFrom(mainEntityIdFor, mainEntityId);
            return (ServicePageFakeReviewDTO)DbService.TryCreateEntity(DB.ServicePageFakeReviews, model, async (entity) =>
            {
                switch (mainEntityIdFor)
                {
                    case IdFor.MainEntity:
                        entity.ServicePageId = mainEntityId;
                        break;
                    case IdFor.Localization:
                        entity.ServicePageLocalizationId = mainEntityId;
                        break;
                }

                await HandleServicePageReview(entity, DBModelFillMode.Create);
            });
        }



        [HttpPut, Route("UpdateReview")]
        [CheckContentAreaRights(ContentAccessModelType.Services, 3)]
        [SwaggerOperation(description: "Нужно загрузить аватар через форму с именем avatarImg, если изменяем аватар")]
        public async Task<ServicePageFakeReviewDTO> UpdateReview(IdFor mainEntityIdFor, int mainEntityId, [FromForm(Name = "model")] ServicePageFakeReviewDTO model)
        {
            var item = DB.ServicePageFakeReviews.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);

            CheckFrom(mainEntityIdFor, mainEntityId);
            return (ServicePageFakeReviewDTO)DbService.TryUpdateEntity(DB.ServicePageFakeReviews, model, item, async (entity) =>
            {
                await HandleServicePageReview(entity, DBModelFillMode.Update);
            });
        }



        [HttpDelete, Route("DeleteReview")]
        [CheckContentAreaRights(ContentAccessModelType.Services, 5)]
        public async Task DeleteReview(IdFor mainEntityIdFor, int mainEntityId, int id)
        {
            var item = DB.ServicePageFakeReviews.FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            CheckFrom(mainEntityIdFor, mainEntityId);
            DbService.TryDeleteEntity(DB.ServicePageFakeReviews, item);
        }


        #endregion

        #region Лента примеров услуг

        [HttpGet, Route("GetServiceRibbonItem")]
        [CheckContentAreaRights(ContentAccessModelType.Services, 1)]
        public async Task<ServicePageServiceRibbonItemDTO> GetServiceRibbonItem(IdFor mainEntityIdFor, int mainEntityId, int itemId)
        {
            var item = DbService.TryGetOne(DB.ServicePageServiceRibbonItems, itemId);

            CheckFrom(mainEntityIdFor, mainEntityId);
            return (ServicePageServiceRibbonItemDTO)new ServicePageServiceRibbonItemDTO().CreateDTO(item);
        }




        [HttpPost, Route("CreateServiceRibbonItem")]
        [CheckContentAreaRights(ContentAccessModelType.Services, 4)]
        public async Task<ServicePageServiceRibbonItemDTO> CreateServiceRibbonItem(IdFor mainEntityIdFor, int mainEntityId, ServicePageServiceRibbonItemDTO model)
        {
            CheckFrom(mainEntityIdFor, mainEntityId);
            return (ServicePageServiceRibbonItemDTO)DbService.TryCreateEntity(DB.ServicePageServiceRibbonItems, model, (entity) =>
            {
                switch (mainEntityIdFor)
                {
                    case IdFor.MainEntity:
                        entity.ServicePageId = mainEntityId;
                        break;
                    case IdFor.Localization:
                        entity.ServicePageLocalizationId = mainEntityId;
                        break;
                }
            });
        }



        [HttpPut, Route("UpdateServiceRibbonItem")]
        [CheckContentAreaRights(ContentAccessModelType.Services, 3)]
        public async Task<ServicePageServiceRibbonItemDTO> UpdateServiceRibbonItem(IdFor mainEntityIdFor, int mainEntityId, ServicePageServiceRibbonItemDTO model)
        {
            var item = DB.ServicePageServiceRibbonItems.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);

            CheckFrom(mainEntityIdFor, mainEntityId);
            return (ServicePageServiceRibbonItemDTO)DbService.TryUpdateEntity(DB.ServicePageServiceRibbonItems, model, item);
        }




        [HttpDelete, Route("DeleteServiceRibbonItem")]
        [CheckContentAreaRights(ContentAccessModelType.Services, 5)]
        public async Task DeleteServiceRibbonItem(IdFor mainEntityIdFor, int mainEntityId, int id)
        {
            var item = DB.ServicePageServiceRibbonItems.FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            CheckFrom(mainEntityIdFor, mainEntityId);
            DbService.TryDeleteEntity(DB.ServicePageServiceRibbonItems, item);
        }

        #endregion

        #region Иконки технологий (стека) разработки

        [HttpPost, Route("AddStackIcon")]
        [CheckContentAreaRights(ContentAccessModelType.Services, 4)]
        [SwaggerOperation(description: "Нужно загрузить изображение через форму с именем mainImg")]
        public async Task AddStackIcon(int servicePageId)
        {
            var page = GetAvailableServicePages().FirstOrDefault(o => o.Id == servicePageId && !o.IsDeleted);
            if (page == null)
            {
                throw new Exception404("Сущность по данному id не найдена");
            }

            await HandleServicePageAddStackIcon(page);
            DbService.UpdateEntity(DB.ServicePages, page);
        }


        [HttpDelete, Route("DeleteStackIcon")]
        [CheckContentAreaRights(ContentAccessModelType.Services, 5)]
        public async Task DeleteStackIcon(int servicePageId, int iconId)
        {
            var page = GetAvailableServicePages().FirstOrDefault(o => o.Id == servicePageId && !o.IsDeleted);
            var icon = page?.StackIcons?.FirstOrDefault(o => o.Id == iconId);
            if (page == null || icon == null)
            {
                throw new Exception404("Сущность по данному id не найдена");
            }

            FilesService.DeleteFile(icon.ImgPath);
            page.StackIcons.Remove(icon);
            DbService.UpdateEntity(DB.ServicePages, page);
        }

        #endregion









        #region Private check access methods
        private void CheckFrom(IdFor mainEntityIdFor, int mainEntityId)
        {
            switch (mainEntityIdFor)
            {
                case IdFor.MainEntity:
                    CheckFromServicePage(mainEntityId);
                    break;
                case IdFor.Localization:
                    CheckFromServicePageLocalization(mainEntityId);
                    break;
            }
        }
        private void CheckFromServicePage(int? pageId)
        {
            var page = GetAvailableServicePages().FirstOrDefault(o => o.Id == pageId && !o.IsDeleted);
            if (pageId == null || page == null)
            {
                throw new Exception404("Сущность по данному id не найдена");
            }
        }
        private void CheckFromServicePageLocalization(int? localizationId)
        {
            var localization = GetServicePageLocalizationsIncluded().FirstOrDefault(o => o.Id == localizationId && !o.IsDeleted);
            if (localizationId == null || localization == null)
            {
                throw new Exception404("Сущность по данному id не найдена");
            }
            CheckFromServicePage(localization.ServicePageId);
        }

        #endregion

        #region Private prepare methods



        private async Task HandleServicePage(ServicePage entity, DBModelFillMode mode)
        {
            const string formFilename = "mainBlockImg";

            if ((mode == DBModelFillMode.Update && FilesService.IsFileUploaded(formFilename))
              || mode == DBModelFillMode.Create)
            {
                entity.MainBlockImgPath = await FilesService.TryUploadFile(formFilename, FileType.Image);
            }
        }
        private async Task HandleServicePageAddStackIcon(ServicePage entity)
        {
            const string formFilename = "mainImg";

            entity.StackIcons.Add(new ServicePageStackIcon
            {
                ImgPath = await FilesService.TryUploadFile(formFilename, FileType.Image),
            });
        }
        private async Task HandleServicePageReview(ServicePageFakeReview entity, DBModelFillMode mode)
        {
            const string formFilename = "avatarImg";

            if ((mode == DBModelFillMode.Update && FilesService.IsFileUploaded(formFilename))
               || mode == DBModelFillMode.Create)
            {
                entity.CustomerAvatarPath = await FilesService.TryUploadFile(formFilename, FileType.Image);
            }
        }

        #endregion

        #region Private get available methods
        private IEnumerable<ServicePage> GetAvailableServicePages()
        {
            return DbService.GetAvailableModels(this.Session.User, GetServicePagesList()).Cast<ServicePage>();
        }

        #endregion

        #region Private get included methods
        private IEnumerable<ServicePage> GetServicePagesList()
        {
            return DB.ServicePages.IncludeAvailability()
                                  .Include(o => o.Localizations).ThenInclude(o => o.LanguageEntity)
                                  .Include(o => o.Localizations).ThenInclude(o => o.ServiceRibbonItems)
                                  .Include(o => o.Localizations).ThenInclude(o => o.Reviews)
                                  .Include(o => o.MainLanguage)
                                  .Include(o => o.ServiceRibbonItems)
                                  .Include(o => o.StackIcons)
                                  .Include(o => o.Reviews)
                                  .Where(o => !o.IsDeleted)
                                  .ToList();
        }
        private IEnumerable<ServicePageLocalization> GetServicePageLocalizationsIncluded()
        {
            return DB.ServicePageLocalizations.Include(o => o.LanguageEntity)
                                              .Include(o => o.ServiceRibbonItems)
                                              .Include(o => o.Reviews)
                                              .Where(o => !o.IsDeleted)
                                              .ToList();
        }

        #endregion
    }
}

using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Core;
using Alfateam.Website.API.Enums;
using Alfateam.Website.API.Extensions;
using Alfateam.Website.API.Models.DTO;
using Alfateam.Website.API.Models.DTO.Posts;
using Alfateam.Website.API.Models.DTO.Shop;
using Alfateam.Website.API.Models.DTO.General;
using Alfateam.Website.API.Models.DTOLocalization;
using Alfateam.Website.API.Models.DTOLocalization.Posts;
using Alfateam2._0.Models;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Localization.Items;
using Alfateam2._0.Models.Localization.Items.Posts;
using Alfateam2._0.Models.Localization.Items.Shop;
using Alfateam2._0.Models.Shop;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Alfateam.Website.API.Models;
using Alfateam.Website.API.Filters.Access;
using Alfateam2._0.Models.ContentItems;
using Alfateam2._0.Models.Localization.Items.HR;
using Alfateam.Website.API.Models.DTO.HR;
using Alfateam.Website.API.Models.DTOLocalization.HR;
using Alfateam.Core.Exceptions;
using Alfateam.Core.Enums;
using Swashbuckle.AspNetCore.Annotations;

namespace Alfateam.Website.API.Controllers.Admin
{
    public class AdminPartnersController : AbsAdminController
    {
        public AdminPartnersController(ControllerParams @params) : base(@params)
        {
        }

        #region Партнеры

        [HttpGet, Route("GetPartners")]
        [CheckContentAreaRights(ContentAccessModelType.Partners, 1)]
        public async Task<IEnumerable<PartnerDTO>> GetPartners(int offset, int count = 20)
        {
            var items = GetAvailablePartners().Skip(offset).Take(count);
            return new PartnerDTO().CreateDTOs(items).Cast<PartnerDTO>();
        }

        [HttpGet, Route("GetPartner")]
        [CheckContentAreaRights(ContentAccessModelType.Partners, 1)]
        public async Task<PartnerDTO> GetPartner(int id)
        {
            return (PartnerDTO)DbService.TryGetOne(GetAvailablePartners(), id, new PartnerDTO());
        }


        [HttpGet, Route("GetPartnerLocalizations")]
        [CheckContentAreaRights(ContentAccessModelType.Partners, 1)]
        public async Task<IEnumerable<PartnerLocalizationDTO>> GetPartnerLocalizations(int id)
        {
            var localizations = DB.PartnerLocalizations.Include(o => o.LanguageEntity).Where(o => o.PartnerId == id && !o.IsDeleted);
            var mainEntity = GetAvailablePartners().FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            return DbService.GetLocalizationModels(localizations, mainEntity, new PartnerLocalizationDTO()).Cast<PartnerLocalizationDTO>();
        }

        [HttpGet, Route("GetPartnerLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Partners, 1)]
        public async Task<PartnerLocalizationDTO> GetPartnerLocalization(int id)
        {
            var localization = DB.PartnerLocalizations.Include(o => o.LanguageEntity).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainEntity = GetAvailablePartners().FirstOrDefault(o => o.Id == localization?.PartnerId && !o.IsDeleted);

            return (PartnerLocalizationDTO)DbService.GetLocalizationModel(localization, mainEntity, new PartnerLocalizationDTO());
        }








        [HttpPost, Route("CreatePartner")]
        [CheckContentAreaRights(ContentAccessModelType.Partners, 4)]
        [SwaggerOperation(description: "Нужно загрузить логотип через форму с именем logoImg")]
        public async Task<PartnerDTO> CreatePartner(PartnerDTO model)
        {
            return (PartnerDTO)DbService.TryCreateAvailabilityEntity(DB.Partners, model, this.Session, async (entity) =>
            {
                await HandlePartner(entity, DBModelFillMode.Create, null);
            });
        }

        [HttpPost, Route("CreatePartnerLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Partners, 3)]
        public async Task<PartnerLocalizationDTO> CreatePartnerLocalization(int itemId, PartnerLocalizationDTO localization)
        {
            var mainEntity = GetAvailablePartners().FirstOrDefault(o => o.Id == itemId);
            return (PartnerLocalizationDTO)DbService.TryCreateLocalizationEntity(DB.Partners, mainEntity, localization, async (entity) =>
            {
                await HandlePartnerLocalization(entity, DBModelFillMode.Create, null);
            });
        }






        [HttpPut, Route("UpdatePartnerMain")]
        [CheckContentAreaRights(ContentAccessModelType.Partners, 3)]
        [SwaggerOperation(description: "Нужно загрузить логотип через форму с именем logoImg, если изменяем картинку")]
        public async Task<PartnerDTO> UpdatePostCategoryMain(PartnerDTO model)
        {
            var item = GetAvailablePartners().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (PartnerDTO)DbService.TryUpdateEntity(DB.Partners, model, item, async (entity) =>
            {
                await HandlePartner(entity, DBModelFillMode.Update, model.Content);
            });
        }

        [HttpPut, Route("UpdatePartnerLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Partners, 3)]
        public async Task<PartnerLocalizationDTO> UpdatePartnerLocalization(PartnerLocalizationDTO model)
        {
            var localization = DB.PartnerLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            var mainEntity = GetAvailablePartners().FirstOrDefault(o => o.Id == localization.PartnerId && !o.IsDeleted);

            return (PartnerLocalizationDTO)DbService.TryUpdateLocalizationEntity(DB.PartnerLocalizations, localization, model, mainEntity, async (entity) =>
            {
                await HandlePartnerLocalization(entity, DBModelFillMode.Update, model.Content);
            });
        }




        [HttpDelete, Route("DeletePartner")]
        [CheckContentAreaRights(ContentAccessModelType.Partners, 5)]
        public async Task DeletePartner(int id)
        {
            var item = GetAvailablePartners().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DbService.TryDeleteEntity(DB.Partners, item);
        }


        [HttpDelete, Route("DeletePartnerLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Partners, 5)]
        public async Task DeletePartnerLocalization(int id)
        {
            var item = DB.PartnerLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainModel = DB.Partners.FirstOrDefault(o => o.Id == item.PartnerId && !o.IsDeleted);

            DbService.TryDeleteLocalizationEntity(DB.PartnerLocalizations, item, mainModel);
        }

        #endregion


        [HttpPut, Route("UpdateAvailability")]
        [CheckContentAreaRights(ContentAccessModelType.Partners, 2)]
        public async Task<AvailabilityDTO> UpdateAvailability(AvailabilityDTO model)
        {
            bool hasThisModel = false;

            hasThisModel |= DbService.GetAvailableModels(this.Session.User, DB.Partners.IncludeAvailability())
                                     .Any(o => o.AvailabilityId == model.Id && !o.IsDeleted);

            if (!hasThisModel)
            {
                throw new Exception403("У данного пользователя нет прав на редактирование матрицы доступности");
            }

            return DbService.TryUpdateAvailability(model, this.Session);
        }





        #region Private prepare methods

        private async Task HandlePartner(Partner entity, DBModelFillMode mode, Content newContentForUpdate)
        {
            const string formFilename = "logoImg";

            if ((mode == DBModelFillMode.Update && FilesService.IsFileUploaded(formFilename))
               || mode == DBModelFillMode.Create)
            {
                entity.LogoPath = await FilesService.TryUploadFile(formFilename, FileType.Image);
            }

            if (mode == DBModelFillMode.Create)
            {
                await FilesService.UploadContentMedia(entity.Content);
            }
            else if (mode == DBModelFillMode.Update && !entity.Content.AreSame(newContentForUpdate))
            {
                await FilesService.UpdateContentMedia(entity.Content, newContentForUpdate);
            }
        }
        private async Task HandlePartnerLocalization(PartnerLocalization entity, DBModelFillMode mode, Content newContentForUpdate)
        {
            if (mode == DBModelFillMode.Create)
            {
                await FilesService.UploadContentMedia(entity.Content);
            }
            else if (mode == DBModelFillMode.Update && !entity.Content.AreSame(newContentForUpdate))
            {
                await FilesService.UpdateContentMedia(entity.Content, newContentForUpdate);
            }
        }


        #endregion

        #region Private get available methods
        private IEnumerable<Partner> GetAvailablePartners()
        {
            return DbService.GetAvailableModels(this.Session.User, GetPartnersIncluded()).Cast<Partner>();
        }

        #endregion

        #region Private get included methods

        private IQueryable<Partner> GetPartnersIncluded()
        {
            return DB.Partners.IncludeAvailability()
                              .Include(o => o.Content).ThenInclude(o => o.Items)
                              .Include(o => o.Localizations).ThenInclude(o => o.Content).ThenInclude(o => o.Items)
                              .Include(o => o.Localizations).ThenInclude(o => o.LanguageEntity)
                              .Include(o => o.MainLanguage)
                              .Where(o => !o.IsDeleted);
        }

        #endregion
    }
}

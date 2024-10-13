using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Core;
using Alfateam.Website.API.Enums;
using Alfateam.Website.API.Extensions;
using Alfateam.Website.API.Models.DTO.Events;
using Alfateam.Website.API.Models.DTO.Portfolios;
using Alfateam.Website.API.Models.DTO.General;
using Alfateam.Website.API.Models.DTOLocalization.Events;
using Alfateam.Website.API.Models.DTOLocalization.Portfolios;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Localization.Items.Events;
using Alfateam2._0.Models.Localization.Items.Portfolios;
using Alfateam2._0.Models.Portfolios;
using Alfateam2._0.Models.Team;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Alfateam.Website.API.Models;
using Alfateam.Website.API.Filters.Access;
using Alfateam.Core.Exceptions;
using Alfateam.Core.Enums;
using Alfateam2._0.Models.ContentItems;
using Alfateam.Website.API.Models.DTO.HR;
using Alfateam.Website.API.Models.DTOLocalization.HR;
using Swashbuckle.AspNetCore.Annotations;

namespace Alfateam.Website.API.Controllers.Admin
{
    public class AdminPortfolioController : AbsAdminController
    {
        public AdminPortfolioController(ControllerParams @params) : base(@params)
        {
        }

        #region Портфолио

        [HttpGet, Route("GetPortfolios")]
        [CheckContentAreaRights(ContentAccessModelType.Portfolio, 1)]
        public async Task<IEnumerable<PortfolioDTO>> GetPortfolios(int offset, int count = 20)
        {
            var items = GetAvailablePortfolio().Skip(offset).Take(count);
            return new PortfolioDTO().CreateDTOs(items).Cast<PortfolioDTO>();
        }

        [HttpGet, Route("GetPortfolio")]
        [CheckContentAreaRights(ContentAccessModelType.Portfolio, 1)]
        public async Task<PortfolioDTO> GetPortfolio(int id)
        {
            return (PortfolioDTO)DbService.TryGetOne(GetAvailablePortfolio(), id, new PortfolioDTO());
        }

        [HttpGet, Route("GetPortfolioLocalizations")]
        [CheckContentAreaRights(ContentAccessModelType.Portfolio, 1)]
        public async Task<IEnumerable<PortfolioLocalizationDTO>> GetPortfolioLocalizations(int id)
        {
            var localization = DB.PortfolioLocalizations.Include(o => o.LanguageEntity).Where(o => o.PortfolioId == id && !o.IsDeleted);
            var mainEntity = GetAvailablePortfolio().FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            return DbService.GetLocalizationModels(localization, mainEntity, new PortfolioLocalizationDTO()).Cast<PortfolioLocalizationDTO>();
        }

        [HttpGet, Route("GetPortfolioLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Portfolio, 1)]
        public async Task<PortfolioLocalizationDTO> GetPortfolioLocalization(int id)
        {
            var localization = DB.PortfolioLocalizations.Include(o => o.LanguageEntity).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainEntity = GetAvailablePortfolio().FirstOrDefault(o => o.Id == localization?.PortfolioId && !o.IsDeleted);

            return (PortfolioLocalizationDTO)DbService.GetLocalizationModel(localization, mainEntity, new PortfolioLocalizationDTO());
        }




        [HttpPost, Route("CreatePortfolio")]
        [CheckContentAreaRights(ContentAccessModelType.Portfolio, 4)]
        [SwaggerOperation(description: "Нужно загрузить изображение через форму с именем mainImg")]
        public async Task<PortfolioDTO> CreatePortfolio([FromForm(Name = "model")] PortfolioDTO model)
        {
            return (PortfolioDTO)DbService.TryCreateAvailabilityEntity(DB.Portfolios, model, this.Session, async (entity) =>
            {
                await HandlePortfolio(entity, DBModelFillMode.Create, null);
            });
        }

        [HttpPost, Route("CreatePortfolioLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Portfolio, 3)]
        [SwaggerOperation(description: "Нужно загрузить изображение через форму с именем mainImg")]
        public async Task<PortfolioLocalizationDTO> CreatePortfolioLocalization(int itemId, [FromForm(Name = "localization")] PortfolioLocalizationDTO localization)
        {
            var mainEntity = GetAvailablePortfolio().FirstOrDefault(o => o.Id == itemId);
            return (PortfolioLocalizationDTO)DbService.TryCreateLocalizationEntity(DB.Portfolios, mainEntity, localization, async (entity) =>
            {
                await HandlePortfolioLocalization(entity, DBModelFillMode.Create, null);
            });
        }




        [HttpPut, Route("UpdatePortfolioMain")]
        [CheckContentAreaRights(ContentAccessModelType.Portfolio, 3)]
        [SwaggerOperation(description: "Нужно загрузить изображение через форму с именем mainImg, если изменяем картинку")]
        public async Task<PortfolioDTO> UpdatePortfolioMain([FromForm(Name = "model")] PortfolioDTO model)
        {
            var item = GetAvailablePortfolio().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (PortfolioDTO)DbService.TryUpdateEntity(DB.Portfolios, model, item, async (entity) =>
            {
                await HandlePortfolio(entity, DBModelFillMode.Update, model.Content);
            });
        }

        [HttpPut, Route("UpdatePortfolioLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Portfolio, 3)]
        [SwaggerOperation(description: "Нужно загрузить изображение через форму с именем mainImg, если изменяем картинку")]
        public async Task<PortfolioLocalizationDTO> UpdatePortfolioLocalization([FromForm(Name = "model")] PortfolioLocalizationDTO model)
        {
            var localization = DB.PortfolioLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            var mainEntity = GetAvailablePortfolio().FirstOrDefault(o => o.Id == localization.PortfolioId && !o.IsDeleted);

            return (PortfolioLocalizationDTO)DbService.TryUpdateLocalizationEntity(DB.PortfolioLocalizations, localization, model, mainEntity, async (entity) =>
            {
                await HandlePortfolioLocalization(entity, DBModelFillMode.Update, model.Content);
            });
        }






        [HttpDelete, Route("DeletePortfolio")]
        [CheckContentAreaRights(ContentAccessModelType.Portfolio, 5)]
        public async Task DeletePortfolio(int id)
        {
            var item = GetAvailablePortfolio().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DbService.TryDeleteEntity(DB.Portfolios, item);
        }

        [HttpDelete, Route("DeletePortfolioLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Portfolio, 5)]
        public async Task DeletePortfolioLocalization(int id)
        {
            var item = DB.PortfolioLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainModel = GetAvailablePortfolio().FirstOrDefault(o => o.Id == item.PortfolioId && !o.IsDeleted);

            DbService.TryDeleteLocalizationEntity(DB.PortfolioLocalizations, item, mainModel);
        }



        #endregion

        #region Категории портфолио

        [HttpGet, Route("GetPortfolioCategories")]
        [CheckContentAreaRights(ContentAccessModelType.Portfolio, 1)]
        public async Task<IEnumerable<PortfolioCategoryDTO>> GetPortfolioCategories(int offset, int count = 20)
        {
            var items = GetAvailablePortfolioCategories().Skip(offset).Take(count);
            return new PortfolioCategoryDTO().CreateDTOs(items).Cast<PortfolioCategoryDTO>();
        }

        [HttpGet, Route("GetPortfolioCategory")]
        [CheckContentAreaRights(ContentAccessModelType.Portfolio, 1)]
        public async Task<PortfolioCategoryDTO> GetPortfolioCategory(int id)
        {
            return (PortfolioCategoryDTO)DbService.TryGetOne(GetAvailablePortfolioCategories(), id, new PortfolioCategoryDTO());
        }

        [HttpGet, Route("GetPortfolioCategoryLocalizations")]
        [CheckContentAreaRights(ContentAccessModelType.Portfolio, 1)]
        public async Task<IEnumerable<PortfolioCategoryLocalizationDTO>> GetPortfolioCategoryLocalizations(int id)
        {
            var localizations = DB.PortfolioCategoryLocalizations.Include(o => o.LanguageEntity).Where(o => o.PortfolioCategoryId == id && !o.IsDeleted);
            var mainEntity = GetAvailablePortfolioCategories().FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            return DbService.GetLocalizationModels(localizations, mainEntity, new PortfolioCategoryLocalizationDTO()).Cast<PortfolioCategoryLocalizationDTO>();
        }

        [HttpGet, Route("GetPortfolioCategoryLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Portfolio, 1)]
        public async Task<PortfolioCategoryLocalizationDTO> GetPortfolioCategoryLocalization(int id)
        {
            var localization = DB.PortfolioCategoryLocalizations.Include(o => o.LanguageEntity).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainEntity = GetAvailablePortfolioCategories().FirstOrDefault(o => o.Id == localization?.PortfolioCategoryId && !o.IsDeleted);

            return (PortfolioCategoryLocalizationDTO)DbService.GetLocalizationModel(localization, mainEntity, new PortfolioCategoryLocalizationDTO());
        }

        




        [HttpPost, Route("CreatePortfolioCategory")]
        [CheckContentAreaRights(ContentAccessModelType.Portfolio, 4)]
        public async Task<PortfolioCategoryDTO> CreatePortfolioCategory(PortfolioCategoryDTO model)
        {
            return (PortfolioCategoryDTO)DbService.TryCreateAvailabilityEntity(DB.PortfolioCategories, model, this.Session);
        }

        [HttpPost, Route("CreatePortfolioCategoryLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Portfolio, 3)]
        public async Task<PortfolioCategoryLocalizationDTO> CreatePortfolioCategoryLocalization(int itemId, PortfolioCategoryLocalizationDTO localization)
        {
            var mainEntity = GetAvailablePortfolioCategories().FirstOrDefault(o => o.Id == itemId);
            return (PortfolioCategoryLocalizationDTO)DbService.TryCreateLocalizationEntity(DB.PortfolioCategories, mainEntity, localization);
        }





        [HttpPut, Route("UpdatePortfolioCategoryMain")]
        [CheckContentAreaRights(ContentAccessModelType.Portfolio, 3)]
        public async Task<PortfolioCategoryDTO> UpdatePortfolioCategoryMain(PortfolioCategoryDTO model)
        {
            var item = GetAvailablePortfolioCategories().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (PortfolioCategoryDTO)DbService.TryUpdateEntity(DB.PortfolioCategories, model, item);
        }
       
        [HttpPut, Route("UpdatePortfolioCategoryLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Portfolio, 3)]
        public async Task<PortfolioCategoryLocalizationDTO> UpdatePortfolioCategoryLocalization(PortfolioCategoryLocalizationDTO model)
        {
            var localization = DB.PortfolioCategoryLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            var mainEntity = GetAvailablePortfolioCategories().FirstOrDefault(o => o.Id == localization.PortfolioCategoryId && !o.IsDeleted);

            return (PortfolioCategoryLocalizationDTO)DbService.TryUpdateLocalizationEntity(DB.PortfolioCategoryLocalizations, localization, model, mainEntity);
        }






        [HttpDelete, Route("DeletePortfolioCategory")]
        [CheckContentAreaRights(ContentAccessModelType.Portfolio, 5)]
        public async Task DeletePortfolioCategory(int id)
        {
            var item = GetAvailablePortfolioCategories().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DbService.TryDeleteEntity(DB.PortfolioCategories, item);
        }

        [HttpDelete, Route("DeletePortfolioCategoryLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Portfolio, 5)]
        public async Task DeletePortfolioCategoryLocalization(int id)
        {
            var item = DB.PortfolioCategoryLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainModel = GetAvailablePortfolioCategories().FirstOrDefault(o => o.Id == item.PortfolioCategoryId && !o.IsDeleted);

            DbService.TryDeleteLocalizationEntity(DB.PortfolioCategoryLocalizations, item, mainModel);
        }

        #endregion

        #region Индустрии портфолио

        [HttpGet, Route("GetPortfolioIndustries")]
        [CheckContentAreaRights(ContentAccessModelType.Portfolio, 1)]
        public async Task<IEnumerable<PortfolioIndustryDTO>> GetPortfolioIndustries(int offset, int count = 20)
        {
            var items = GetAvailablePortfolioIndustries().Skip(offset).Take(count);
            return new PortfolioIndustryDTO().CreateDTOs(items).Cast<PortfolioIndustryDTO>();
        }

        [HttpGet, Route("GetPortfolioIndustry")]
        [CheckContentAreaRights(ContentAccessModelType.Portfolio, 1)]
        public async Task<PortfolioIndustryDTO> GetPortfolioIndustry(int id)
        {
            return (PortfolioIndustryDTO)DbService.TryGetOne(GetAvailablePortfolioIndustries(), id, new PortfolioIndustryDTO());
        }

        [HttpGet, Route("GetPortfolioIndustryLocalizations")]
        [CheckContentAreaRights(ContentAccessModelType.Portfolio, 1)]
        public async Task<IEnumerable<PortfolioIndustryLocalizationDTO>> GetPortfolioIndustryLocalizations(int id)
        {
            var localizations = DB.PortfolioIndustryLocalizations.Include(o => o.LanguageEntity).Where(o => o.PortfolioIndustryId == id && !o.IsDeleted);
            var mainEntity = GetAvailablePortfolioIndustries().FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            return DbService.GetLocalizationModels(localizations, mainEntity, new PortfolioIndustryLocalizationDTO()).Cast<PortfolioIndustryLocalizationDTO>();
        }

        [HttpGet, Route("GetPortfolioIndustryLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Portfolio, 1)]
        public async Task<PortfolioIndustryLocalizationDTO> GetPortfolioIndustryLocalization(int id)
        {
            var localization = DB.PortfolioIndustryLocalizations.Include(o => o.LanguageEntity).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainEntity = GetAvailablePortfolioIndustries().FirstOrDefault(o => o.Id == localization?.PortfolioIndustryId && !o.IsDeleted);

            return (PortfolioIndustryLocalizationDTO)DbService.GetLocalizationModel(localization, mainEntity, new PortfolioIndustryLocalizationDTO());
        }




        [HttpPost, Route("CreatePortfolioIndustry")]
        [CheckContentAreaRights(ContentAccessModelType.Portfolio, 4)]
        public async Task<PortfolioIndustryDTO> CreatePortfolioIndustry(PortfolioIndustryDTO model)
        {
            return (PortfolioIndustryDTO)DbService.TryCreateAvailabilityEntity(DB.PortfolioIndustries, model, this.Session);
        }

        [HttpPost, Route("CreatePortfolioIndustryLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Portfolio, 3)]
        public async Task<PortfolioIndustryLocalizationDTO> CreatePortfolioIndustryLocalization(int itemId, PortfolioIndustryLocalizationDTO localization)
        {
            var mainEntity = GetAvailablePortfolioIndustries().FirstOrDefault(o => o.Id == itemId);
            return (PortfolioIndustryLocalizationDTO)DbService.TryCreateLocalizationEntity(DB.PortfolioIndustries, mainEntity, localization);
        }






        [HttpPut, Route("UpdatePortfolioIndustryMain")]
        [CheckContentAreaRights(ContentAccessModelType.Portfolio, 3)]
        public async Task<PortfolioIndustryDTO> UpdatePortfolioIndustryMain(PortfolioIndustryDTO model)
        {
            var item = GetAvailablePortfolioIndustries().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (PortfolioIndustryDTO)DbService.TryUpdateEntity(DB.PortfolioIndustries, model, item);
        }
        
        [HttpPut, Route("UpdatePortfolioIndustryLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Portfolio, 3)]
        public async Task<PortfolioIndustryLocalizationDTO> UpdatePortfolioIndustryLocalization(PortfolioIndustryLocalizationDTO model)
        {
            var localization = DB.PortfolioIndustryLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            var mainEntity = GetAvailablePortfolioIndustries().FirstOrDefault(o => o.Id == localization.PortfolioIndustryId && !o.IsDeleted);

            return (PortfolioIndustryLocalizationDTO)DbService.TryUpdateLocalizationEntity(DB.PortfolioIndustryLocalizations, localization, model, mainEntity);
        }






        [HttpDelete, Route("DeletePortfolioIndustry")]
        [CheckContentAreaRights(ContentAccessModelType.Portfolio, 5)]
        public async Task DeletePortfolioIndustry(int id)
        {
            var item = GetAvailablePortfolioIndustries().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DbService.TryDeleteEntity(DB.PortfolioIndustries, item);
        }

        [HttpDelete, Route("DeletePortfolioIndustryLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Portfolio, 5)]
        public async Task DeletePortfolioIndustryLocalization(int id)
        {
            var item = DB.PortfolioIndustryLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainModel = GetAvailablePortfolioIndustries().FirstOrDefault(o => o.Id == item.PortfolioIndustryId && !o.IsDeleted);

            DbService.TryDeleteLocalizationEntity(DB.PortfolioIndustryLocalizations, item, mainModel);
        }



        #endregion


        [HttpPut, Route("UpdateAvailability")]
        [CheckContentAreaRights(ContentAccessModelType.Portfolio, 2)]
        public async Task<AvailabilityDTO> UpdateAvailability(AvailabilityDTO model)
        {
            bool hasThisModel = false;


            hasThisModel |= DbService.GetAvailableModels(this.Session.User, DB.Portfolios.IncludeAvailability())
                                     .Any(o => o.AvailabilityId == model.Id && !o.IsDeleted);
            hasThisModel |= DbService.GetAvailableModels(this.Session.User, DB.PortfolioCategories.IncludeAvailability())
                                     .Any(o => o.AvailabilityId == model.Id && !o.IsDeleted);
            hasThisModel |= DbService.GetAvailableModels(this.Session.User, DB.PortfolioIndustries.IncludeAvailability())
                                     .Any(o => o.AvailabilityId == model.Id && !o.IsDeleted);


            if (!hasThisModel)
            {
                throw new Exception403("У данного пользователя нет прав на редактирование матрицы доступности");
            }

            return DbService.TryUpdateAvailability(model, this.Session);
        }








        #region Private get available methods
        private IEnumerable<Portfolio> GetAvailablePortfolio()
        {
            return DbService.GetAvailableModels(this.Session.User, GetPortfoliosFullIncludedList()).Cast<Portfolio>();
        }
        private IEnumerable<PortfolioCategory> GetAvailablePortfolioCategories()
        {
            return DbService.GetAvailableModels(this.Session.User, GetPortfolioCategoriesList()).Cast<PortfolioCategory>();
        }
        private IEnumerable<PortfolioIndustry> GetAvailablePortfolioIndustries()
        {
            return DbService.GetAvailableModels(this.Session.User, GetPortfolioIndustriesList()).Cast<PortfolioIndustry>();
        }

        #endregion

        #region Private methods
        private async Task HandlePortfolio(Portfolio entity, DBModelFillMode mode, Content newContentForUpdate)
        {
            const string formFilename = "mainImg";

            if ((mode == DBModelFillMode.Update && FilesService.IsFileUploaded(formFilename))
                || mode == DBModelFillMode.Create)
            {
                entity.ImgPath = await FilesService.TryUploadFile(formFilename, FileType.Image);
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
        private async Task HandlePortfolioLocalization(PortfolioLocalization entity, DBModelFillMode mode, Content newContentForUpdate)
        {
            const string formFilename = "mainImg";

            if ((mode == DBModelFillMode.Update && FilesService.IsFileUploaded(formFilename))
                || mode == DBModelFillMode.Create)
            {
                entity.ImgPath = await FilesService.TryUploadFile(formFilename, FileType.Image);
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


        #endregion

        #region Private get included methods
        private IQueryable<Portfolio> GetPortfoliosList()
        {
            return DB.Portfolios.IncludeAvailability()
                                .Include(o => o.Category).ThenInclude(o => o.MainLanguage)
                                .Include(o => o.Category).ThenInclude(o => o.Localizations).ThenInclude(o => o.LanguageEntity)
                                .Include(o => o.Industry).ThenInclude(o => o.MainLanguage)
                                .Include(o => o.Industry).ThenInclude(o => o.Localizations).ThenInclude(o => o.LanguageEntity)
                                .Include(o => o.Localizations).ThenInclude(o => o.LanguageEntity)
                                .Include(o => o.MainLanguage)
                                .Where(o => !o.IsDeleted);
        }
        private IQueryable<Portfolio> GetPortfoliosFullIncludedList()
        {
            return DB.Portfolios.IncludeAvailability()
                                .Include(o => o.Category).ThenInclude(o => o.MainLanguage)
                                .Include(o => o.Category).ThenInclude(o => o.Localizations).ThenInclude(o => o.LanguageEntity)
                                .Include(o => o.Industry).ThenInclude(o => o.MainLanguage)
                                .Include(o => o.Industry).ThenInclude(o => o.Localizations).ThenInclude(o => o.LanguageEntity)
                                .Include(o => o.Localizations).ThenInclude(o => o.LanguageEntity)
                                .Include(o => o.Localizations).ThenInclude(o => o.Content).ThenInclude(o => o.Items)
                                .Include(o => o.Content).ThenInclude(o => o.Items)
                                .Include(o => o.MainLanguage)
                                .Where(o => !o.IsDeleted);
        }


        private IQueryable<PortfolioCategory> GetPortfolioCategoriesList()
        {
            return DB.PortfolioCategories.IncludeAvailability()
                                         .Include(o => o.Localizations).ThenInclude(o => o.LanguageEntity)
                                         .Include(o => o.MainLanguage)
                                         .Where(o => !o.IsDeleted);
        }
        private IQueryable<PortfolioIndustry> GetPortfolioIndustriesList()
        {
            return DB.PortfolioIndustries.IncludeAvailability()
                                         .Include(o => o.Localizations).ThenInclude(o => o.LanguageEntity)
                                         .Include(o => o.MainLanguage)
                                         .Where(o => !o.IsDeleted);
        }

        #endregion
    }
}

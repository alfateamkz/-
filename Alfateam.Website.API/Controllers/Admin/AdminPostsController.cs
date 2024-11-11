using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Core;
using Alfateam.Website.API.Enums;
using Alfateam.Website.API.Extensions;
using Alfateam.Website.API.Models.DTO.Posts;
using Alfateam.Website.API.Models.DTO.General;
using Alfateam.Website.API.Models.DTOLocalization.Posts;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Enums;
using Alfateam.Core.Enums;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Localization.Items;
using Alfateam2._0.Models.Localization.Items.Events;
using Alfateam2._0.Models.Localization.Items.Posts;
using Alfateam2._0.Models.Posts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using Alfateam.Website.API.Models;
using Alfateam.Website.API.Filters.Access;
using Alfateam.Website.API.Models.DTO.Portfolios;
using Alfateam2._0.Models.Portfolios;
using Alfateam.Website.API.Models.DTOLocalization.Portfolios;
using Alfateam.Core.Exceptions;
using Alfateam2._0.Models.ContentItems;
using Swashbuckle.AspNetCore.Annotations;
using Alfateam.Website.API.Filters.AdminSearch;

namespace Alfateam.Website.API.Controllers.Admin
{
    public class AdminPostsController : AbsAdminController
    {

        public AdminPostsController(ControllerParams @params) : base(@params)
        {
        }

        #region Новости


        [HttpGet, Route("GetPostsCount")]
        public async Task<int> GetPostsCount()
        {
            return GetAvailablePosts().Count();
        }


        [HttpGet, Route("GetPosts")]
        [CheckContentAreaRights(ContentAccessModelType.Posts, 1)]
        public async Task<IEnumerable<PostDTO>> GetPosts(int offset, int count = 20)
        {
            var items = GetAvailablePosts().Skip(offset).Take(count);
            return new PostDTO().CreateDTOs(items).Cast<PostDTO>();
        }

        [HttpGet, Route("GetPostsFiltered")]
        [CheckContentAreaRights(ContentAccessModelType.Posts, 1)]
        public async Task<IEnumerable<PostDTO>> GetPostsFiltered([FromQuery] PostsSearchFilter filter)
        {
            var items = filter.Filter(GetAvailablePosts(), (item) => item.Title);
            return new PostDTO().CreateDTOs(items).Cast<PostDTO>();
        }


        [HttpGet, Route("GetPost")]
        [CheckContentAreaRights(ContentAccessModelType.Posts, 1)]
        public async Task<PostDTO> GetPost(int id)
        {
            return (PostDTO)DbService.TryGetOne(GetAvailablePosts(), id, new PostDTO());
        }

        [HttpGet, Route("GetPostLocalizations")]
        [CheckContentAreaRights(ContentAccessModelType.Posts, 1)]
        public async Task<IEnumerable<PostLocalizationDTO>> GetPostLocalizations(int id)
        {
            var localizations = DB.PostLocalizations.Include(o => o.LanguageEntity).Where(o => o.PostId == id && !o.IsDeleted);
            var mainEntity = GetAvailablePosts().FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            return DbService.GetLocalizationModels(localizations, mainEntity, new PostLocalizationDTO()).Cast<PostLocalizationDTO>();
        }

        [HttpGet, Route("GetPostLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Posts, 1)]
        public async Task<PostLocalizationDTO> GetPostLocalization(int id)
        {
            var localization = DB.PostLocalizations.Include(o => o.LanguageEntity).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainEntity = GetAvailablePosts().FirstOrDefault(o => o.Id == localization?.PostId && !o.IsDeleted);

            return (PostLocalizationDTO)DbService.GetLocalizationModel(localization, mainEntity, new PostLocalizationDTO());
        }






        [HttpPost, Route("CreatePost")]
        [CheckContentAreaRights(ContentAccessModelType.Posts, 4)]
        [SwaggerOperation(description: "Нужно загрузить изображение через форму с именем mainImg")]
        public async Task<PostDTO> CreatePost([FromForm(Name = "model")] PostDTO model)
        {
            return (PostDTO)DbService.TryCreateAvailabilityEntity(DB.Posts, model, this.Session, (entity) =>
            {
                HandlePost(entity, DBModelFillMode.Create, null);
            });
        }

        [HttpPost, Route("CreatePostLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Posts, 3)]
        [SwaggerOperation(description: "Нужно загрузить изображение через форму с именем mainImg")]
        public async Task<PostLocalizationDTO> CreatePostLocalization(int itemId, [FromForm(Name = "localization")] PostLocalizationDTO localization)
        {
            var mainEntity = GetAvailablePosts().FirstOrDefault(o => o.Id == itemId);
            return (PostLocalizationDTO)DbService.TryCreateLocalizationEntity(DB.Posts, mainEntity, localization, (entity) =>
            {
                HandlePostLocalization(entity, DBModelFillMode.Create, null);
            });
        }




        [HttpPut, Route("UpdatePostMain")]
        [CheckContentAreaRights(ContentAccessModelType.Posts, 3)]
        [SwaggerOperation(description: "Нужно загрузить изображение через форму с именем mainImg, если изменяем картинку")]
        public async Task<PostDTO> UpdatePostMain([FromForm(Name = "model")] PostDTO model)
        {
            var item = GetAvailablePosts().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (PostDTO)DbService.TryUpdateEntity(DB.Posts, model, item, (entity) =>
            {
                HandlePost(entity, DBModelFillMode.Update, model.Content);
            });
        }

        [HttpPut, Route("UpdatePostLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Posts, 3)]
        [SwaggerOperation(description: "Нужно загрузить изображение через форму с именем mainImg, если изменяем картинку")]
        public async Task<PostLocalizationDTO> UpdatePostLocalization([FromForm(Name = "model")] PostLocalizationDTO model)
        {
            var localization = DB.PostLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            var mainEntity = GetAvailablePosts().FirstOrDefault(o => o.Id == localization.PostId && !o.IsDeleted);

            return (PostLocalizationDTO)DbService.TryUpdateLocalizationEntity(DB.PostLocalizations, localization, model, mainEntity, (entity) =>
            {
                HandlePostLocalization(entity, DBModelFillMode.Update, model.Content);
            });
        }





        [HttpDelete,Route("DeletePost")]
        [CheckContentAreaRights(ContentAccessModelType.Posts, 5)]
        public async Task DeletePost(int id)
        {
            var item = GetAvailablePosts().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DbService.TryDeleteEntity(DB.Posts, item);
        }

        [HttpDelete, Route("DeletePostLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Posts, 5)]
        public async Task DeletePostLocalization(int id)
        {
            var item = DB.PostLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainModel = GetAvailablePosts().FirstOrDefault(o => o.Id == item.PostId && !o.IsDeleted);

            DbService.TryDeleteLocalizationEntity(DB.PostLocalizations, item, mainModel);
        }

        #endregion

        #region Категории новостей

        [HttpGet, Route("GetPostCategoriesCount")]
        public async Task<int> GetPostCategoriesCount()
        {
            return GetAvailablePostCategories().Count();
        }


        [HttpGet, Route("GetPostCategories")]
        [CheckContentAreaRights(ContentAccessModelType.Posts, 1)]
        public async Task<IEnumerable<PostCategoryDTO>> GetPostCategories(int offset, int count = 20)
        {
            var items = GetAvailablePostCategories().Skip(offset).Take(count);
            return new PostCategoryDTO().CreateDTOs(items).Cast<PostCategoryDTO>();
        }

        [HttpGet, Route("GetPostCategoriesFiltered")]
        [CheckContentAreaRights(ContentAccessModelType.Posts, 1)]
        public async Task<IEnumerable<PostCategoryDTO>> GetPostCategoriesFiltered([FromQuery] SearchFilter filter)
        {
            var items = filter.FilterBase(GetAvailablePostCategories(), (item) => item.Title);
            return new PostCategoryDTO().CreateDTOs(items).Cast<PostCategoryDTO>();
        }

        [HttpGet, Route("GetPostCategory")]
        [CheckContentAreaRights(ContentAccessModelType.Posts, 1)]
        public async Task<PostCategoryDTO> GetPostCategory(int id)
        {
            return (PostCategoryDTO)DbService.TryGetOne(GetAvailablePostCategories(), id, new PostCategoryDTO());
        }

        [HttpGet, Route("GetPostCategoryLocalizations")]
        [CheckContentAreaRights(ContentAccessModelType.Posts, 1)]
        public async Task<IEnumerable<PostCategoryLocalizationDTO>> GetPostCategoryLocalizations(int id)
        {
            var localizations = DB.PostCategoryLocalizations.Include(o => o.LanguageEntity).Where(o => o.PostCategoryId == id && !o.IsDeleted);
            var mainEntity = GetAvailablePostCategories().FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            return DbService.GetLocalizationModels(localizations, mainEntity, new PostCategoryLocalizationDTO()).Cast<PostCategoryLocalizationDTO>();
        }

        [HttpGet, Route("GetPostCategoryLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Posts, 1)]
        public async Task<PostCategoryLocalizationDTO> GetPostCategoryLocalization(int id)
        {
            var localization = DB.PostCategoryLocalizations.Include(o => o.LanguageEntity).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainEntity = GetAvailablePostCategories().FirstOrDefault(o => o.Id == localization?.PostCategoryId && !o.IsDeleted);

            return (PostCategoryLocalizationDTO)DbService.GetLocalizationModel(localization, mainEntity, new PostCategoryLocalizationDTO());
        }




        [HttpPost, Route("CreatePostCategory")]
        [CheckContentAreaRights(ContentAccessModelType.Posts, 4)]
        public async Task<PostCategoryDTO> CreatePostCategory(PostCategoryDTO model)
        {
            return (PostCategoryDTO)DbService.TryCreateAvailabilityEntity(DB.PostCategories, model, this.Session);
        }
    
        [HttpPost, Route("CreatePostCategoryLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Posts, 3)]
        public async Task<PostCategoryLocalizationDTO> CreatePostCategoryLocalization(int itemId, PostCategoryLocalizationDTO localization)
        {
            var mainEntity = GetAvailablePostCategories().FirstOrDefault(o => o.Id == itemId);
            return (PostCategoryLocalizationDTO)DbService.TryCreateLocalizationEntity(DB.PostCategories, mainEntity, localization);
        }





        [HttpPut, Route("UpdatePostCategoryMain")]
        [CheckContentAreaRights(ContentAccessModelType.Posts, 3)]
        public async Task<PostCategoryDTO> UpdatePostCategoryMain(PostCategoryDTO model)
        {
            var item = GetAvailablePostCategories().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (PostCategoryDTO)DbService.TryUpdateEntity(DB.PostCategories, model, item);
        }

        [HttpPut, Route("UpdatePostCategoryLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Posts, 3)]
        public async Task<PostCategoryLocalizationDTO> UpdatePostCategoryLocalization(PostCategoryLocalizationDTO model)
        {
            var localization = DB.PostCategoryLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            var mainEntity = GetAvailablePostCategories().FirstOrDefault(o => o.Id == localization.PostCategoryId && !o.IsDeleted);

            return (PostCategoryLocalizationDTO)DbService.TryUpdateLocalizationEntity(DB.PostCategoryLocalizations, localization, model, mainEntity);
        }





        [HttpDelete, Route("DeletePostCategory")]
        [CheckContentAreaRights(ContentAccessModelType.Posts, 5)]
        public async Task DeletePostCategory(int id)
        {
            var item = GetAvailablePostCategories().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DbService.TryDeleteEntity(DB.PostCategories, item);
        }

        [HttpDelete, Route("DeletePostCategoryLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Posts, 5)]
        public async Task DeletePostCategoryLocalization(int id)
        {
            var item = DB.PostCategoryLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainModel = GetAvailablePostCategories().FirstOrDefault(o => o.Id == item.PostCategoryId && !o.IsDeleted);

            DbService.TryDeleteLocalizationEntity(DB.PostCategoryLocalizations, item, mainModel);
        }


        #endregion

        #region Индустрии новостей

        [HttpGet, Route("GetPostIndustriesCount")]
        public async Task<int> GetPostIndustriesCount()
        {
            return GetAvailablePostIndustries().Count();
        }


        [HttpGet, Route("GetPostIndustries")]
        [CheckContentAreaRights(ContentAccessModelType.Posts, 1)]
        public async Task<IEnumerable<PostIndustryDTO>> GetPostIndustries(int offset, int count = 20)
        {
            var items = GetAvailablePostIndustries().Skip(offset).Take(count);
            return new PostIndustryDTO().CreateDTOs(items).Cast<PostIndustryDTO>();
        }

        [HttpGet, Route("GetPostIndustriesFiltered")]
        [CheckContentAreaRights(ContentAccessModelType.Posts, 1)]
        public async Task<IEnumerable<PostIndustryDTO>> GetPostIndustriesFiltered([FromQuery] SearchFilter filter)
        {
            var items = filter.FilterBase(GetAvailablePostIndustries(), (item) => item.Title);
            return new PostIndustryDTO().CreateDTOs(items).Cast<PostIndustryDTO>();
        }

        [HttpGet, Route("GetPostIndustry")]
        [CheckContentAreaRights(ContentAccessModelType.Posts, 1)]
        public async Task<PostIndustryDTO> GetPostIndustry(int id)
        {
            return (PostIndustryDTO)DbService.TryGetOne(GetAvailablePostIndustries(), id, new PostIndustryDTO());
        }

        [HttpGet, Route("GetPostIndustryLocalizations")]
        [CheckContentAreaRights(ContentAccessModelType.Posts, 1)]
        public async Task<IEnumerable<PostIndustryLocalizationDTO>> GetPostIndustryLocalizations(int id)
        {
            var localizations = DB.PostIndustryLocalizations.Include(o => o.LanguageEntity).Where(o => o.PostIndustryId == id && !o.IsDeleted);
            var mainEntity = GetAvailablePostIndustries().FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            return DbService.GetLocalizationModels(localizations, mainEntity, new PostIndustryLocalizationDTO()).Cast<PostIndustryLocalizationDTO>();
        }

        [HttpGet, Route("GetPostIndustryLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Posts, 1)]
        public async Task<PostIndustryLocalizationDTO> GetPostIndustryLocalization(int id)
        {
            var localization = DB.PostIndustryLocalizations.Include(o => o.LanguageEntity).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainEntity = GetAvailablePostIndustries().FirstOrDefault(o => o.Id == localization?.PostIndustryId && !o.IsDeleted);

            return (PostIndustryLocalizationDTO)DbService.GetLocalizationModel(localization, mainEntity, new PostIndustryLocalizationDTO());
        }




        [HttpPost, Route("CreatePostIndustry")]
        [CheckContentAreaRights(ContentAccessModelType.Posts, 4)]
        public async Task<PostIndustryDTO> CreatePostIndustry(PostIndustryDTO model)
        {
            return (PostIndustryDTO)DbService.TryCreateAvailabilityEntity(DB.PostIndustries, model, this.Session);
        }
   
        [HttpPost, Route("CreatePostIndustryLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Posts, 3)]
        public async Task<PostIndustryLocalizationDTO> CreatePostIndustryLocalization(int itemId, PostIndustryLocalizationDTO localization)
        {
            var mainEntity = GetAvailablePostIndustries().FirstOrDefault(o => o.Id == itemId);
            return (PostIndustryLocalizationDTO)DbService.TryCreateLocalizationEntity(DB.PostIndustries, mainEntity, localization);
        }




        [HttpPut, Route("UpdatePostIndustryMain")]
        [CheckContentAreaRights(ContentAccessModelType.Posts, 3)]
        public async Task<PostIndustryDTO> UpdatePostIndustryMain(PostIndustryDTO model)
        {
            var item = GetAvailablePostIndustries().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (PostIndustryDTO)DbService.TryUpdateEntity(DB.PostIndustries, model, item);
        }

        [HttpPut, Route("UpdatePostIndustryLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Posts, 3)]
        public async Task<PostIndustryLocalizationDTO> UpdatePostIndustryLocalization(PostIndustryLocalizationDTO model)
        {
            var localization = DB.PostIndustryLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            var mainEntity = GetAvailablePostIndustries().FirstOrDefault(o => o.Id == localization.PostIndustryId && !o.IsDeleted);

            return (PostIndustryLocalizationDTO)DbService.TryUpdateLocalizationEntity(DB.PostIndustryLocalizations, localization, model, mainEntity);
        }






        [HttpDelete, Route("DeletePostIndustry")]
        [CheckContentAreaRights(ContentAccessModelType.Posts, 5)]
        public async Task DeletePostIndustry(int id)
        {
            var item = GetAvailablePostIndustries().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DbService.TryDeleteEntity(DB.PostIndustries, item);
        }

        [HttpDelete, Route("DeletePostIndustryLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Posts, 5)]
        public async Task DeletePostIndustryLocalization(int id)
        {
            var item = DB.PostIndustryLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainModel = GetAvailablePostIndustries().FirstOrDefault(o => o.Id == item.PostIndustryId && !o.IsDeleted);

            DbService.TryDeleteLocalizationEntity(DB.PostIndustryLocalizations, item, mainModel);
        }


        #endregion


        [HttpPut, Route("UpdateAvailability")]
        [CheckContentAreaRights(ContentAccessModelType.Posts, 2)]
        public async Task<AvailabilityDTO> UpdateAvailability(AvailabilityDTO model)
        {   
            bool hasThisModel = false;

            hasThisModel |= DbService.GetAvailableModels(this.Session.User, DB.Posts.IncludeAvailability())
                                     .Any(o => o.AvailabilityId == model.Id && !o.IsDeleted);
            hasThisModel |= DbService.GetAvailableModels(this.Session.User, DB.PostCategories.IncludeAvailability())
                                     .Any(o => o.AvailabilityId == model.Id && !o.IsDeleted);
            hasThisModel |= DbService.GetAvailableModels(this.Session.User, DB.PostIndustries.IncludeAvailability())
                                     .Any(o => o.AvailabilityId == model.Id && !o.IsDeleted);


            if (!hasThisModel)
            {
                throw new Exception403("У данного пользователя нет прав на редактирование матрицы доступности");
            }

            return DbService.TryUpdateAvailability(model, this.Session);
        }





        #region Private prepare methods

        private void HandlePost(Post entity, DBModelFillMode mode, Content newContentForUpdate)
        {
            const string formFilename = "mainImg";

            if (!DB.PostCategories.Any(o => o.Id == entity.CategoryId && !o.IsDeleted))
            {
                throw new Exception400("Категории с данным id не существует");
            }
            else if (!DB.PostIndustries.Any(o => o.Id == entity.IndustryId && !o.IsDeleted))
            {
                throw new Exception400("Индустрии с данным id не существует");
            }

 
            if ((mode == DBModelFillMode.Update && FilesService.IsFileUploaded(formFilename))
                || mode == DBModelFillMode.Create)
            {
                entity.ImgPath = FilesService.TryUploadFile(formFilename, FileType.Image);
            }

            if (mode == DBModelFillMode.Create)
            {
                FilesService.UploadContentMedia(entity.Content);
            }
            else if (mode == DBModelFillMode.Update && !entity.Content.AreSame(newContentForUpdate))
            {
                FilesService.UpdateContentMedia(entity.Content, newContentForUpdate);
            }
        }
        private void HandlePostLocalization(PostLocalization entity, DBModelFillMode mode, Content newContentForUpdate)
        {
            const string formFilename = "mainImg";

            if ((mode == DBModelFillMode.Update && FilesService.IsFileUploaded(formFilename))
                || mode == DBModelFillMode.Create)
            {
                entity.ImgPath = FilesService.TryUploadFile(formFilename, FileType.Image);
            }

            if (mode == DBModelFillMode.Create)
            {
                FilesService.UploadContentMedia(entity.Content);
            }
            else if (mode == DBModelFillMode.Update && !entity.Content.AreSame(newContentForUpdate))
            {
                FilesService.UpdateContentMedia(entity.Content, newContentForUpdate);
            }
        }


        #endregion

        #region Private get available methods
        private IEnumerable<Post> GetAvailablePosts()
        {
            return DbService.GetAvailableModels(this.Session.User, GetFullIncludedPosts()).Cast<Post>();
        }
        private IEnumerable<PostCategory> GetAvailablePostCategories()
        {
            return DbService.GetAvailableModels(this.Session.User, GetPostCategoriesList()).Cast<PostCategory>();
        }
        private IEnumerable<PostIndustry> GetAvailablePostIndustries()
        {
            return DbService.GetAvailableModels(this.Session.User, GetPostPostIndustriesList()).Cast<PostIndustry>();
        }

        #endregion

        #region Private get included methods 
        private IQueryable<Post> GetPosts()
        {
            return DB.Posts.IncludeAvailability()
                            .Include(o => o.Category).ThenInclude(o => o.Localizations)
                            .Include(o => o.Industry).ThenInclude(o => o.Localizations)
                            .Include(o => o.Content).ThenInclude(o => o.Items)
                            .Include(o => o.Localizations).ThenInclude(o => o.Content).ThenInclude(o => o.Items)
                            .Where(o => !o.IsDeleted);
        }
        private IQueryable<Post> GetFullIncludedPosts()
        {
            return DB.Posts.IncludeAvailability()
                            .Include(o => o.Category).ThenInclude(o => o.Localizations)
                            .Include(o => o.Industry).ThenInclude(o => o.Localizations)
                            .Include(o => o.Content).ThenInclude(o => o.Items)
                            .Include(o => o.WatchesList).ThenInclude(o => o.WatchedBy)
                            .Include(o => o.Localizations).ThenInclude(o => o.Content).ThenInclude(o => o.Items)
                            .Include(o => o.MainLanguage)
                            .Where(o => !o.IsDeleted);
        }


        private IQueryable<PostCategory> GetPostCategoriesList()
        {
            return DB.PostCategories.IncludeAvailability()
                                    .Include(o => o.Localizations).ThenInclude(o => o.LanguageEntity)
                                    .Include(o => o.MainLanguage)
                                    .Where(o => !o.IsDeleted);
        }
        private IQueryable<PostIndustry> GetPostPostIndustriesList()
        {
            return DB.PostIndustries.IncludeAvailability()
                                    .Include(o => o.Localizations).ThenInclude(o => o.LanguageEntity)
                                    .Include(o => o.MainLanguage)
                                    .Where(o => !o.IsDeleted);
        }

        #endregion
    }
}

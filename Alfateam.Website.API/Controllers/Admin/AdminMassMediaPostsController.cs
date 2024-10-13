using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models.DTO;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Alfateam.Website.API.Extensions;
using Microsoft.EntityFrameworkCore;
using Alfateam.Website.API.Models.DTO.Posts;
using Alfateam.Website.API.Enums;
using Alfateam.Website.API.Models.DTOLocalization;
using Alfateam2._0.Models.Localization.Items;
using Alfateam.Website.API.Models.DTO.General;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Localization.Items.Posts;
using Alfateam.Website.API.Core;
using Alfateam.Website.API.Models;
using Alfateam.Website.API.Filters.Access;
using Alfateam.Core.Exceptions;
using Alfateam.Core.Enums;
using Alfateam.Website.API.Models.DTO.Events;
using Alfateam.Website.API.Models.DTOLocalization.Events;
using Swashbuckle.AspNetCore.Annotations;

namespace Alfateam.Website.API.Controllers.Admin
{
    public class AdminMassMediaPostsController : AbsAdminController
    {
        public AdminMassMediaPostsController(ControllerParams @params) : base(@params)
        {
        }

        #region Посты

        [HttpGet, Route("GetPosts")]
        [CheckContentAreaRights(ContentAccessModelType.MassMediaPosts, 1)]
        public async Task<IEnumerable<MassMediaPostDTO>> GetPosts(int offset, int count = 20)
        {
            var items = GetAvailablePosts().Skip(offset).Take(count);
            return new MassMediaPostDTO().CreateDTOs(items).Cast<MassMediaPostDTO>();
        }

        [HttpGet, Route("GetPost")]
        [CheckContentAreaRights(ContentAccessModelType.MassMediaPosts, 1)]
        public async Task<MassMediaPostDTO> GetPost(int id)
        {
            return (MassMediaPostDTO)DbService.TryGetOne(GetAvailablePosts(), id, new MassMediaPostDTO());
        }

        [HttpGet, Route("GetPostLocalizations")]
        [CheckContentAreaRights(ContentAccessModelType.MassMediaPosts, 1)]
        public async Task<IEnumerable<MassMediaPostLocalizationDTO>> GetPostLocalizations(int id)
        {
            var localizations = DB.MassMediaPostLocalizations.Include(o => o.LanguageEntity).Where(o => o.MassMediaPostId == id && !o.IsDeleted);
            var mainEntity = GetAvailablePosts().FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            return DbService.GetLocalizationModels(localizations, mainEntity, new MassMediaPostLocalizationDTO()).Cast<MassMediaPostLocalizationDTO>();
        }

        [HttpGet, Route("GetPostLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.MassMediaPosts, 1)]
        public async Task<MassMediaPostLocalizationDTO> GetPostLocalization(int id)
        {
            var localization = DB.MassMediaPostLocalizations.Include(o => o.LanguageEntity).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainEntity = GetAvailablePosts().FirstOrDefault(o => o.Id == localization?.MassMediaPostId && !o.IsDeleted);

            return (MassMediaPostLocalizationDTO)DbService.GetLocalizationModel(localization, mainEntity, new MassMediaPostLocalizationDTO());
        }





        [HttpPost, Route("CreatePost")]
        [CheckContentAreaRights(ContentAccessModelType.MassMediaPosts, 4)]
        [SwaggerOperation(description: "Нужно загрузить изображение через форму с именем mainImg")]
        public async Task<MassMediaPostDTO> CreatePost([FromForm(Name = "model")] MassMediaPostDTO model)
        {
            return (MassMediaPostDTO)DbService.TryCreateAvailabilityEntity(DB.MassMediaPosts, model, this.Session, async (entity) =>
            {
                await HandleMassMediaPost(entity, DBModelFillMode.Create);
            });
        }

        [HttpPost, Route("CreatePostLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.MassMediaPosts, 3)]
        public async Task<MassMediaPostLocalizationDTO> CreatePostLocalization(int itemId, MassMediaPostLocalizationDTO localization)
        {
            var mainEntity = GetAvailablePosts().FirstOrDefault(o => o.Id == itemId);
            return (MassMediaPostLocalizationDTO)DbService.TryCreateLocalizationEntity(DB.MassMediaPosts, mainEntity, localization);
        }





        [HttpPut, Route("UpdatePostMain")]
        [CheckContentAreaRights(ContentAccessModelType.MassMediaPosts, 3)]
        [SwaggerOperation(description: "Нужно загрузить изображение через форму с именем mainImg, если изменяем картинку")]
        public async Task<MassMediaPostDTO> UpdatePostMain([FromForm(Name = "model")] MassMediaPostDTO model)
        {
            var item = GetAvailablePosts().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (MassMediaPostDTO)DbService.TryUpdateEntity(DB.MassMediaPosts, model, item, async (entity) =>
            {
                await HandleMassMediaPost(entity, DBModelFillMode.Update);
            });
        }

        [HttpPut, Route("UpdatePostLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.MassMediaPosts, 3)]
        public async Task<MassMediaPostLocalizationDTO> UpdatePostLocalization(MassMediaPostLocalizationDTO model)
        {
            var localization = DB.MassMediaPostLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            var mainEntity = GetAvailablePosts().FirstOrDefault(o => o.Id == localization.MassMediaPostId && !o.IsDeleted);

            return (MassMediaPostLocalizationDTO)DbService.TryUpdateLocalizationEntity(DB.MassMediaPostLocalizations, localization, model, mainEntity);
        }





        [HttpDelete, Route("DeletePost")]
        [CheckContentAreaRights(ContentAccessModelType.MassMediaPosts, 5)]
        public async Task DeletePost(int id)
        {
            var item = GetAvailablePosts().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DbService.TryDeleteEntity(DB.MassMediaPosts, item);
        }

        [HttpDelete, Route("DeletePostLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.MassMediaPosts, 5)]
        public async Task DeletePostLocalization(int id)
        {
            var item = DB.MassMediaPostLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainModel = DB.Events.FirstOrDefault(o => o.Id == item.MassMediaPostId && !o.IsDeleted);

            DbService.TryDeleteLocalizationEntity(DB.MassMediaPostLocalizations, item, mainModel);
        }

        #endregion



        [HttpPut, Route("UpdateAvailability")]
        [CheckContentAreaRights(ContentAccessModelType.MassMediaPosts, 2)]
        public async Task<AvailabilityDTO> UpdateAvailability(AvailabilityDTO model)
        {
            bool hasThisModel = false;

            hasThisModel |= DbService.GetAvailableModels(this.Session.User, DB.MassMediaPosts.IncludeAvailability())
                                     .Any(o => o.AvailabilityId == model.Id && !o.IsDeleted);

            if (!hasThisModel)
            {
                throw new Exception403("У данного пользователя нет прав на редактирование матрицы доступности");
            }

            return DbService.TryUpdateAvailability(model, this.Session);
        }








        #region Private get available methods
        private IEnumerable<MassMediaPost> GetAvailablePosts()
        {
            return DbService.GetAvailableModels(this.Session.User, GetPostsList()).Cast<MassMediaPost>();
        }

        #endregion

        #region Private prepare methods
        private async Task HandleMassMediaPost(MassMediaPost entity, DBModelFillMode mode)
        {
            const string formFilename = "mainImg";

            if ((mode == DBModelFillMode.Update && FilesService.IsFileUploaded(formFilename))
               || mode == DBModelFillMode.Create)
            {
                entity.ImgPath = await FilesService.TryUploadFile(formFilename, FileType.Image);
            }
        }

        #endregion

        #region Private get included methods

        private IQueryable<MassMediaPost> GetPostsList()
        {
            return DB.MassMediaPosts.IncludeAvailability()
                                    .Include(o => o.MainLanguage)
                                    .Include(o => o.Localizations).ThenInclude(o => o.LanguageEntity);
        }

        #endregion



    }
}

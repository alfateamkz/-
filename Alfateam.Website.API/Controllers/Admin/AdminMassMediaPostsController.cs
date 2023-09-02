using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models.ClientModels;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Alfateam.Website.API.Extensions;
using Microsoft.EntityFrameworkCore;
using Alfateam.Website.API.Models.ClientModels.Posts;
using Alfateam.Website.API.Enums;
using Alfateam.Website.API.Models.EditModels;
using Alfateam.Website.API.Models.LocalizationEditModels;
using Alfateam2._0.Models.Localization.Items;
using Alfateam.Website.API.Models.EditModels.General;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Localization.Items.Posts;
using Alfateam.Website.API.Core;

namespace Alfateam.Website.API.Controllers.Admin
{
    public class AdminMassMediaPostsController : AbsAdminController
    {
        public AdminMassMediaPostsController(WebsiteDBContext db, IWebHostEnvironment appEnv) : base(db, appEnv)
        {

        }

        #region Посты

        [HttpGet, Route("GetPosts")]
        public async Task<RequestResult<IEnumerable<MassMediaPostClientModel>>> GetPosts(int offset, int count = 20)
        {
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<IEnumerable<MassMediaPostClientModel>>(new Func<RequestResult>[]
            {
                () => CheckContentAreaRights(session, ContentAccessModelType.MassMediaPosts, 1),
                () => {
                    var items = GetAvailableModels(session.User, GetPostsList(), offset, count);
                    var models = MassMediaPostClientModel.CreateItems(items.Cast<MassMediaPost>(), LanguageId);
                    return RequestResult<IEnumerable<MassMediaPostClientModel>>.AsSuccess(models);
                }
            });
        }

        [HttpGet, Route("GetPost")]
        public async Task<RequestResult<MassMediaPost>> GetPost(int id)
        {
            return TryGetOne(GetPostsList(), id, ContentAccessModelType.MassMediaPosts);
        }

        [HttpGet, Route("GetPostLocalization")]
        public async Task<RequestResult<MassMediaPostLocalization>> GetPostLocalization(int id)
        {
            var localization = DB.MassMediaPostLocalizations.Include(o => o.Language).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (localization == null) return RequestResult<MassMediaPostLocalization>.AsError(404, "Сущность с данным id не найдена");

            var mainEntity = GetPostsList().FirstOrDefault(o => o.Id == localization.MassMediaPostId && !o.IsDeleted);
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<MassMediaPostLocalization>(new Func<RequestResult>[]
            {
                () => RequestResult.FromBoolean(mainEntity != null, 500, "Внутренняя ошибка"),
                () => CheckContentAreaRights(session, mainEntity, ContentAccessModelType.MassMediaPosts, 1),
                () => RequestResult<MassMediaPostLocalization>.AsSuccess(localization)
            });
        }





        [HttpPost, Route("CreatePost")]
        public async Task<RequestResult<MassMediaPost>> CreatePost(MassMediaPost item)
        {
            return await TryCreate(DB.MassMediaPosts, item, ContentAccessModelType.MassMediaPosts, async () => await PreparePostBeforeCreate(item));
        }

        [HttpPost, Route("CreatePostLocalization")]
        public async Task<RequestResult<MassMediaPostLocalization>> CreatePostLocalization(int itemId,MassMediaPostLocalization localization)
        {
            var mainEntity = GetPostsList().FirstOrDefault(o => o.Id == itemId);
            return TryFinishAllRequestes<MassMediaPostLocalization>(new[]
            {
                () => CheckLocalizationModelBeforeCreate(localization, mainEntity, ContentAccessModelType.MassMediaPosts),
                () =>
                {
                    mainEntity.Localizations.Add(localization);
                    UpdateModel(DB.MassMediaPosts,mainEntity);
                    return RequestResult<MassMediaPostLocalization>.AsSuccess(localization);
                }
            });
        }





        [HttpPut, Route("UpdatePostMain")]
        public async Task<RequestResult<MassMediaPost>> UpdatePostMain(MassMediaPostEditModel model)
        {
            var post = GetPostsList().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<MassMediaPost>(new[]
            {
                () => RequestResult.FromBoolean(post != null,404, "Запись по данному id не найдена"),
                () => CheckContentAreaRights(session, post, ContentAccessModelType.MassMediaPosts, 2),
                () => RequestResult.FromBoolean(model.IsValid(), 400, "Не заполнены все необходимые поля. Сверьтесь с документацией и попробуйте еще раз"),
                () => RequestResult.FromBoolean(DB.Languages.Any(o => o.Id == model.MainLanguageId && !o.IsDeleted)  ,404, "Языка с данным id не существует"),
                () => PreparePostBeforeUpdate(post).Result,
                () => UpdateModel(DB.MassMediaPosts, model, post)
            });
        }

        [HttpPut, Route("UpdatePostLocalization")]
        public async Task<RequestResult<MassMediaPostLocalization>> UpdatePostLocalization(MassMediaPostLocalizationEditModel model)
        {
            var localization = DB.MassMediaPostLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return TryFinishAllRequestes<MassMediaPostLocalization>(new[]
            {
                () => RequestResult.FromBoolean(localization != null,404, "Локализация с данным id не найдена"),
                () => CheckLocalizationModelBeforeUpdate(GetPostsList(), model, localization.MassMediaPostId, ContentAccessModelType.MassMediaPosts),
                () => UpdateModel(DB.MassMediaPostLocalizations, model, localization)
            });
        }





        [HttpDelete, Route("DeletePost")]
        public async Task<RequestResult> DeletePost(int id)
        {
            var item = GetPostsList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(item != null,404, "Запись по данному id не найдена"),
                () => TryDelete(DB.MassMediaPosts, item, ContentAccessModelType.MassMediaPosts)
            });
        }

        [HttpDelete, Route("DeletePostLocalization")]
        public async Task<RequestResult> DeletePostLocalization(int id)
        {
            var item = DB.MassMediaPostLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(item != null,404, "Запись по данному id не найдена"),
                () => CheckLocalizationModelBeforeDelete(GetPostsList(), item.MassMediaPostId, ContentAccessModelType.MassMediaPosts),
                () => DeleteModel(DB.MassMediaPostLocalizations, item, false)
            });
        }

        #endregion

        [HttpPut, Route("UpdateAvailability")]
        public async Task<RequestResult<Availability>> UpdateAvailability(AvailabilityEditModel model)
        {
            bool hasThisModel = false;

            var user = GetSessionWithRoleInclude().User;
            hasThisModel |= GetAvailableModels(user, DB.MassMediaPosts.IncludeAvailability()).Any(o => o.AvailabilityId == model.Id && !o.IsDeleted);

            if (!hasThisModel)
            {
                return new RequestResult<Availability>().SetError(403, "У данного пользователя нет прав на редактирование матрицы доступности");
            }

            return TryUpdateAvailability(model, ContentAccessModelType.MassMediaPosts);
        }





        #region Private prepare methods

        private async Task<RequestResult> PreparePostBeforeCreate(MassMediaPost item)
        {
            var fileUploadResult = await TryUploadFile("mainImg", FileType.Image);
            if (!fileUploadResult.Success) return fileUploadResult;

            item.ImgPath = fileUploadResult.Value;
            item.ClicksCount = 0;

            return new RequestResult().SetSuccess();
        }
        private async Task<RequestResult> PreparePostBeforeUpdate(MassMediaPost item)
        {
            if (Request.Form.Files.Any(o => o.Name == "mainImg"))
            {
                var fileUploadResult = await TryUploadFile("mainImg", FileType.Image);
                if (!fileUploadResult.Success) return fileUploadResult;

                item.ImgPath = fileUploadResult.Value;
            }

            return new RequestResult().SetSuccess();
        }

        #endregion

        #region Private get included methods

        private IQueryable<MassMediaPost> GetPostsList()
        {
            return DB.MassMediaPosts.IncludeAvailability()
                                    .Include(o => o.MainLanguage)
                                    .Include(o => o.Localizations).ThenInclude(o => o.Language);
        }

        #endregion



    }
}

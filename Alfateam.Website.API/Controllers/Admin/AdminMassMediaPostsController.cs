using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models.ClientModels;
using Alfateam.Website.API.Models.Core;
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

namespace Alfateam.Website.API.Controllers.Admin
{
    public class AdminMassMediaPostsController : AbsAdminController
    {
        public AdminMassMediaPostsController(WebsiteDBContext db, IWebHostEnvironment appEnv) : base(db, appEnv)
        {

        }

        [HttpGet, Route("GetPosts")]
        public async Task<RequestResult<IEnumerable<MassMediaPostClientModel>>> GetPosts(int offset, int count = 20)
        {
            var res = new RequestResult<IEnumerable<MassMediaPostClientModel>>();

            var tryGetManyResponse = TryGetMany(GetPostsList(), ContentAccessModelType.MassMediaPosts, offset, count);
            if (!tryGetManyResponse.Success)
            {
                return res.FillFromRequestResult(tryGetManyResponse);
            }

            var models = MassMediaPostClientModel.CreateItems(tryGetManyResponse.Value.ToList(), LanguageId);
            return res.SetSuccess(models);
        }

        [HttpGet, Route("GetPost")]
        public async Task<RequestResult<MassMediaPost>> GetPost(int id)
        {
            return TryGetOne(GetPostsList(), id, ContentAccessModelType.MassMediaPosts);
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

            var checkResult = CheckLocalizationModelBeforeCreate(localization, mainEntity, ContentAccessModelType.MassMediaPosts);
            if (!checkResult.Success)
            {
                return new RequestResult<MassMediaPostLocalization>().FillFromRequestResult(checkResult);
            }

            mainEntity.Localizations.Add(localization);
            DB.MassMediaPosts.Update(mainEntity);
            DB.SaveChanges();

            return new RequestResult<MassMediaPostLocalization>().SetSuccess(localization);
        }





        [HttpPut, Route("UpdatePostMain")]
        public async Task<RequestResult<MassMediaPost>> UpdatePostMain(MassMediaPostEditModel model)
        {
            var res = new RequestResult<MassMediaPost>();

            var baseCheckResult = CheckMainModelBeforeUpdate(GetPostsList(), model, ContentAccessModelType.MassMediaPosts);
            if (!baseCheckResult.Success) return baseCheckResult;
            var item = baseCheckResult.Value;


            if (!DB.Languages.Any(o => o.Id == model.MainLanguageId && !o.IsDeleted))
            {
                return res.SetError(404, "Языка с данным id не существует");
            }

            var prepareResult = await PreparePostBeforeUpdate(item,model);
            if (!prepareResult.Success)
            {
                return res.FillFromRequestResult(prepareResult);
            }


            return UpdateModel(DB.MassMediaPosts, model, item);
        }

        [HttpPut, Route("UpdatePostLocalization")]
        public async Task<RequestResult<MassMediaPostLocalization>> UpdatePostLocalization(MassMediaPostLocalizationEditModel model)
        {
            var res = new RequestResult<MassMediaPostLocalization>();

            var localization = DB.MassMediaPostLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            if (localization == null)
            {
                return res.SetError(404, "Локализация с данным id не найдена");
            }

            var checkResult = CheckLocalizationModelBeforeUpdate(GetPostsList(), model, localization.MassMediaPostId, ContentAccessModelType.MassMediaPosts);
            if (!checkResult.Success)
            {
                return res.FillFromRequestResult(checkResult);
            }

            return UpdateModel(DB.MassMediaPostLocalizations, model, localization);
        }





        [HttpDelete, Route("DeletePost")]
        public async Task<RequestResult> DeletePost(int id)
        {
            var res = new RequestResult();

            var item = GetPostsList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (item == null)
            {
                return res.SetError(404, "Запись по данному id не найдена");
            }

            return TryDelete(DB.MassMediaPosts, item,ContentAccessModelType.MassMediaPosts);
        }

        [HttpDelete, Route("DeletePostLocalization")]
        public async Task<RequestResult> DeletePostLocalization(int id)
        {
            var res = new RequestResult();

            var item = DB.MassMediaPostLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (item == null)
            {
                return res.SetError(404, "Запись по данному id не найдена");
            }
            var checkResult = CheckLocalizationModelBeforeDelete(GetPostsList(), item.MassMediaPostId, ContentAccessModelType.MassMediaPosts);
            if (!checkResult.Success)
            {
                return checkResult;
            }

            return DeleteModel(DB.MassMediaPostLocalizations, item, false);
        }


        #region Private methods

        private IQueryable<MassMediaPost> GetPostsList()
        {
            return DB.MassMediaPosts.IncludeAvailability()
                                    .Include(o => o.MainLanguage)
                                    .Include(o => o.Localizations).ThenInclude(o => o.Language);
        }

        private async Task<RequestResult> PreparePostBeforeCreate(MassMediaPost item)
        {
            var fileUploadResult = await TryUploadFile("mainImg",FileType.Image);
            if (!fileUploadResult.Success) return fileUploadResult;

            item.ImgPath = fileUploadResult.Value;
            item.ClicksCount = 0;

            return new RequestResult().SetSuccess();
        }

        private async Task<RequestResult> PreparePostBeforeUpdate(MassMediaPost item,MassMediaPostEditModel model)
        {
            if(item.ImgPath != model.ImgPath)
            {
                var fileUploadResult = await TryUploadFile("mainImg", FileType.Image);
                if (!fileUploadResult.Success) return fileUploadResult;

                item.ImgPath = fileUploadResult.Value;
            }

            return new RequestResult().SetSuccess();
        }

        #endregion



    }
}

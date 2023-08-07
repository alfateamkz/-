using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Enums;
using Alfateam.Website.API.Extensions;
using Alfateam.Website.API.Models.ClientModels.Posts;
using Alfateam.Website.API.Models.Core;
using Alfateam.Website.API.Models.EditModels.Posts;
using Alfateam.Website.API.Models.LocalizationEditModels.Posts;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Localization.Items;
using Alfateam2._0.Models.Localization.Items.Posts;
using Alfateam2._0.Models.Posts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Alfateam.Website.API.Controllers.Admin
{
    public class AdminPostsController : AbsAdminController
    {

        //TODO: проход по свойству контента и заливка медиа

        public AdminPostsController(WebsiteDBContext db, IWebHostEnvironment appEnv) : base(db, appEnv)
        {
        }

        #region Новости

        [HttpGet, Route("GetPosts")]
        public async Task<RequestResult<IEnumerable<PostClientModel>>> GetPosts(int offset, int count = 20)
        {
            var res = new RequestResult<IEnumerable<PostClientModel>>();

            var tryGetManyResponse = TryGetMany(GetPosts(), ContentAccessModelType.Posts, offset, count);
            if (!tryGetManyResponse.Success)
            {
                return res.FillFromRequestResult(tryGetManyResponse);
            }

            var models = PostClientModel.CreateItems(tryGetManyResponse.Value.ToList(), LanguageId);
            return res.SetSuccess(models);
        }

        [HttpGet, Route("GetPost")]
        public async Task<RequestResult<Post>> GetPost(int id)
        {
            return TryGetOne(GetFullIncludedPosts(), id, ContentAccessModelType.Posts);
        }





        [HttpPost, Route("CreatePost")]
        public async Task<RequestResult<Post>> CreatePost(Post item)
        {
            return await TryCreate(DB.Posts, item, ContentAccessModelType.Posts, () => ValidateAndPreparePost(item));
        }

        [HttpPost, Route("CreatePostLocalization")]
        public async Task<RequestResult<PostLocalization>> CreatePostLocalization(int itemId, PostLocalization localization)
        {
            var mainEntity = GetPosts().FirstOrDefault(o => o.Id == itemId);

            var checkResult = CheckLocalizationModelBeforeCreate(localization, mainEntity, ContentAccessModelType.Posts);
            if (!checkResult.Success)
            {
                return new RequestResult<PostLocalization>().FillFromRequestResult(checkResult);
            }

            mainEntity.Localizations.Add(localization);
            DB.Posts.Update(mainEntity);
            DB.SaveChanges();

            return new RequestResult<PostLocalization>().SetSuccess(localization);
        }




        [HttpPut, Route("UpdatePostMain")]
        public async Task<RequestResult<Post>> UpdatePostMain(PostMainEditModel model)
        {
            var res = new RequestResult<Post>();

            var post = GetPosts().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            if (post == null)
            {
                return res.SetError(404, "Новость по данному id не найдена");
            }


            var session = GetSessionWithRoleInclude();
            var contentRightsCheck = CheckContentAreaRights(session, post, ContentAccessModelType.Posts, 2);
            if (!contentRightsCheck.Success)
            {
                res.FillFromRequestResult(contentRightsCheck);
                return res;
            }



            if (!model.IsValid())
            {
                return res.SetError(400, "Не заполнены все необходимые поля. Сверьтесь с документацией и попробуйте еще раз");
            }
            else if (!DB.PostCategories.Any(o => o.Id == model.CategoryId && !o.IsDeleted))
            {
                return res.SetError(404, "Категории с данным id не существует");
            }
            else if (!DB.PostIndustries.Any(o => o.Id == model.IndustryId && !o.IsDeleted))
            {
                return res.SetError(404, "Индустрии с данным id не существует");
            }
            else if (!DB.Languages.Any(o => o.Id == model.MainLanguageId && !o.IsDeleted))
            {
                return res.SetError(404, "Языка с данным id не существует");
            }
            else
            {
                if(post.ImgPath != model.ImgPath)
                {
                    //Загрузка главной картинки
                    var mainFileUploadResult = await TryUploadFile("mainImg", FileType.Image);
                    if (!mainFileUploadResult.Success) return res.FillFromRequestResult(mainFileUploadResult);

                    post.ImgPath = mainFileUploadResult.Value;
                }

                model.Fill(post);

                DB.Posts.Update(post);
                DB.SaveChanges();

                return res.SetSuccess(post);
            }
        }

        [HttpPut, Route("UpdatePostLocalization")]
        public async Task<RequestResult<PostLocalization>> UpdatePostLocalization(PostLocalizationEditModel model)
        {
            var res = new RequestResult<PostLocalization>();

            var localization = DB.PostLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            if (localization == null)
            {
                return res.SetError(404, "Локализация с данным id не найдена");
            }

            var checkResult = CheckLocalizationModelBeforeUpdate(GetPosts(), model, localization.PostId, ContentAccessModelType.Posts);
            if (!checkResult.Success)
            {
                return res.FillFromRequestResult(checkResult);
            }


            if (localization.ImgPath != model.ImgPath)
            {
                var localizationFileUploadResult = await TryUploadFile($"{localization.LanguageId}_Img", FileType.Image);
                if (!localizationFileUploadResult.Success) return res.FillFromRequestResult(localizationFileUploadResult);

                localization.ImgPath = localizationFileUploadResult.Value;
            }

            return UpdateModel(DB.PostLocalizations, model, localization);
        }





        [HttpDelete,Route("DeletePost")]
        public async Task<RequestResult> DeletePost(int postId)
        {
            var res = new RequestResult();

            var post = GetPosts().FirstOrDefault(o => o.Id == postId && !o.IsDeleted);
            if (post == null)
            {
                return res.SetError(404, "Новость по данному id не найдена");
            }

            return TryDelete(DB.Posts, post, ContentAccessModelType.Posts);
        }

        [HttpDelete, Route("DeletePostLocalization")]
        public async Task<RequestResult> DeletePostLocalization(int id)
        {
            var res = new RequestResult();

            var item = DB.PostLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (item == null)
            {
                return res.SetError(404, "Запись по данному id не найдена");
            }
            var checkResult = CheckLocalizationModelBeforeDelete(GetPosts(), item.PostId, ContentAccessModelType.Posts);
            if (!checkResult.Success)
            {
                return checkResult;
            }

            return DeleteModel(DB.PostLocalizations, item, false);
        }

        #endregion

        #region Категории новостей

        [HttpGet, Route("GetPostCategories")]
        public async Task<RequestResult<IEnumerable<PostCategoryClientModel>>> GetPostCategories(int offset, int count = 20)
        {
            var res = new RequestResult<IEnumerable<PostCategoryClientModel>>();

            var tryGetManyResponse = TryGetMany(GetPostCategoriesList(), ContentAccessModelType.Posts, offset, count);
            if (!tryGetManyResponse.Success)
            {
                return res.FillFromRequestResult(tryGetManyResponse);
            }

            var models = PostCategoryClientModel.CreateItems(tryGetManyResponse.Value.ToList(), LanguageId);
            return res.SetSuccess(models);
        }

        [HttpGet, Route("GetPostCategory")]
        public async Task<RequestResult<PostCategory>> GetPostCategory(int id)
        {
            return TryGetOne(GetPostCategoriesList(), id, ContentAccessModelType.Posts);
        }




        [HttpPost, Route("CreatePostCategory")]
        public async Task<RequestResult<PostCategory>> CreatePostCategory(PostCategory item)
        {
            return TryCreate(DB.PostCategories, item, ContentAccessModelType.Posts);
        }
        [HttpPost, Route("CreatePostCategoryLocalization")]
        public async Task<RequestResult<PostCategoryLocalization>> CreatePostCategoryLocalization(int itemId, PostCategoryLocalization localization)
        {
            var mainEntity = GetPostCategoriesList().FirstOrDefault(o => o.Id == itemId);

            var checkResult = CheckLocalizationModelBeforeCreate(localization, mainEntity, ContentAccessModelType.Posts);
            if (!checkResult.Success)
            {
                return new RequestResult<PostCategoryLocalization>().FillFromRequestResult(checkResult);
            }

            mainEntity.Localizations.Add(localization);
            DB.PostCategories.Update(mainEntity);
            DB.SaveChanges();

            return new RequestResult<PostCategoryLocalization>().SetSuccess(localization);
        }





        [HttpPut, Route("UpdatePostCategoryMain")]
        public async Task<RequestResult<PostCategory>> UpdatePostCategoryMain(PostCategoryMainEditModel model)
        {
            var res = new RequestResult<PostCategory>();

            var baseCheckResult = CheckMainModelBeforeUpdate(GetPostCategoriesList(), model,ContentAccessModelType.Posts);
            if (!baseCheckResult.Success) return baseCheckResult;
            var item = baseCheckResult.Value;


            if (!DB.Languages.Any(o => o.Id == model.MainLanguageId && !o.IsDeleted))
            {
                return res.SetError(404, "Языка с данным id не существует");
            }
            else
            {
                return UpdateModel(DB.PostCategories, model, item);
            }
        }


        [HttpPut, Route("UpdatePostCategoryLocalization")]
        public async Task<RequestResult<PostCategoryLocalization>> UpdatePostCategoryLocalization(PostCategoryLocalizationEditModel model)
        {
            var res = new RequestResult<PostCategoryLocalization>();

            var localization = DB.PostCategoryLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            if (localization == null)
            {
                return res.SetError(404, "Локализация с данным id не найдена");
            }

            var checkResult = CheckLocalizationModelBeforeUpdate(GetPostCategoriesList(), model, localization.PostCategoryId, ContentAccessModelType.Posts);
            if (!checkResult.Success)
            {
                return res.FillFromRequestResult(checkResult);
            }

            return UpdateModel(DB.PostCategoryLocalizations, model, localization);    
        }





        [HttpDelete, Route("DeletePostCategory")]
        public async Task<RequestResult> DeletePostCategory(int id)
        {
            var res = new RequestResult();

            var item = GetPostCategoriesList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (item == null)
            {
                return res.SetError(404, "Категория по данному id не найдена");
            }

            return TryDelete(DB.PostCategories, item, ContentAccessModelType.Posts);
        }

        [HttpDelete, Route("DeletePostCategoryLocalization")]
        public async Task<RequestResult> DeletePostCategoryLocalization(int id)
        {
            var res = new RequestResult();

            var item = DB.PostCategoryLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (item == null)
            {
                return res.SetError(404, "Запись по данному id не найдена");
            }
            var checkResult = CheckLocalizationModelBeforeDelete(GetPostCategoriesList(), item.PostCategoryId, ContentAccessModelType.Posts);
            if (!checkResult.Success)
            {
                return checkResult;
            }

            return DeleteModel(DB.PostCategoryLocalizations, item, false);
        }


        #endregion

        #region Индустрии новостей

        [HttpGet, Route("GetPostIndustries")]
        public async Task<RequestResult<IEnumerable<PostIndustryClientModel>>> GetPostIndustries(int offset, int count = 20)
        {
            var res = new RequestResult<IEnumerable<PostIndustryClientModel>>();

            var tryGetManyResponse = TryGetMany(GetPostPostIndustriesList(), ContentAccessModelType.Posts, offset, count);
            if (!tryGetManyResponse.Success)
            {
                return res.FillFromRequestResult(tryGetManyResponse);
            }

            var models = PostIndustryClientModel.CreateItems(tryGetManyResponse.Value.ToList(), LanguageId);
            return res.SetSuccess(models);
        }

        [HttpGet, Route("GetPostIndustry")]
        public async Task<RequestResult<PostIndustry>> GetPostIndustry(int id)
        {
            return TryGetOne(GetPostPostIndustriesList(), id, ContentAccessModelType.Posts);
        }





        [HttpPost, Route("CreatePostIndustry")]
        public async Task<RequestResult<PostIndustry>> CreatePostIndustry(PostIndustry item)
        {
            return TryCreate(DB.PostIndustries,item, ContentAccessModelType.Posts);    
        }
        [HttpPost, Route("CreatePostIndustryLocalization")]
        public async Task<RequestResult<PostIndustryLocalization>> CreatePostIndustryLocalization(int itemId, PostIndustryLocalization localization)
        {
            var mainEntity = GetPostPostIndustriesList().FirstOrDefault(o => o.Id == itemId);

            var checkResult = CheckLocalizationModelBeforeCreate(localization, mainEntity, ContentAccessModelType.Posts);
            if (!checkResult.Success)
            {
                return new RequestResult<PostIndustryLocalization>().FillFromRequestResult(checkResult);
            }

            mainEntity.Localizations.Add(localization);
            DB.PostIndustries.Update(mainEntity);
            DB.SaveChanges();

            return new RequestResult<PostIndustryLocalization>().SetSuccess(localization);
        }




        [HttpPut, Route("UpdatePostIndustryMain")]
        public async Task<RequestResult<PostIndustry>> UpdatePostIndustryMain(PostIndustryMainEditModel model)
        {
            var res = new RequestResult<PostIndustry>();

            var baseCheckResult = CheckMainModelBeforeUpdate(GetPostPostIndustriesList(), model, ContentAccessModelType.Posts);
            if (!baseCheckResult.Success) return baseCheckResult;
            var item = baseCheckResult.Value;


            if (!DB.Languages.Any(o => o.Id == model.MainLanguageId && !o.IsDeleted))
            {
                return res.SetError(404, "Языка с данным id не существует");
            }
            else
            {
                return UpdateModel(DB.PostIndustries, model, item);
            }
        }

        [HttpPut, Route("UpdatePostIndustryLocalization")]
        public async Task<RequestResult<PostIndustryLocalization>> UpdatePostIndustryLocalization(PostIndustryLocalizationEditModel model)
        {
            var res = new RequestResult<PostIndustryLocalization>();

            var localization = DB.PostIndustryLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            if (localization == null)
            {
                return res.SetError(404, "Локализация с данным id не найдена");
            }

            var checkResult = CheckLocalizationModelBeforeUpdate(GetPostPostIndustriesList(), model, localization.PostIndustryId, ContentAccessModelType.Posts);
            if (!checkResult.Success)
            {
                return res.FillFromRequestResult(checkResult);
            }

            return UpdateModel(DB.PostIndustryLocalizations, model, localization);
        }






        [HttpDelete, Route("DeletePostIndustry")]
        public async Task<RequestResult> DeletePostIndustry(int id)
        {
            var res = new RequestResult();

            var item = GetPostPostIndustriesList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (item == null)
            {
                return res.SetError(404, "Индустрия по данному id не найдена");
            }

            return TryDelete(DB.PostIndustries, item, ContentAccessModelType.Posts);
        }

        [HttpDelete, Route("DeletePostIndustryLocalization")]
        public async Task<RequestResult> DeletePostIndustryLocalization(int id)
        {
            var res = new RequestResult();

            var item = DB.PostIndustryLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (item == null)
            {
                return res.SetError(404, "Запись по данному id не найдена");
            }
            var checkResult = CheckLocalizationModelBeforeDelete(GetPostPostIndustriesList(), item.PostIndustryId, ContentAccessModelType.Posts);
            if (!checkResult.Success)
            {
                return checkResult;
            }

            return DeleteModel(DB.PostIndustryLocalizations, item, false);
        }


        #endregion


        #region Private methods
        public IQueryable<Post> GetPosts()
        {
            return DB.Posts.IncludeAvailability()
                            .Include(o => o.Category).ThenInclude(o => o.Localizations)
                            .Include(o => o.Industry).ThenInclude(o => o.Localizations)
                            .Include(o => o.Content).ThenInclude(o => o.Items)
                            .Include(o => o.Localizations).ThenInclude(o => o.Content).ThenInclude(o => o.Items)
                            .Where(o => !o.IsDeleted);
        }
        public IQueryable<Post> GetFullIncludedPosts()
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


        public IQueryable<PostCategory> GetPostCategoriesList()
        {
            return DB.PostCategories.IncludeAvailability()
                                    .Include(o => o.Localizations).ThenInclude(o => o.Language)
                                    .Include(o => o.MainLanguage)
                                    .Where(o => !o.IsDeleted);
        }
        public IQueryable<PostIndustry> GetPostPostIndustriesList()
        {
            return DB.PostIndustries.IncludeAvailability()
                                    .Include(o => o.Localizations).ThenInclude(o => o.Language)
                                    .Include(o => o.MainLanguage)
                                    .Where(o => !o.IsDeleted);
        }



        private async Task<RequestResult> ValidateAndPreparePost(Post item)
        {
            var res = new RequestResult();

            if (!DB.PostCategories.Any(o => o.Id == item.CategoryId && !o.IsDeleted))
            {
                return res.SetError(404, "Категории с данным id не существует");
            }
            else if (!DB.PostIndustries.Any(o => o.Id == item.IndustryId && !o.IsDeleted))
            {
                return res.SetError(404, "Индустрии с данным id не существует");
            }
            else
            {
                //Загрузка главной картинки
                var mainFileUploadResult = await TryUploadFile("mainImg", FileType.Image);
                if (!mainFileUploadResult.Success) return mainFileUploadResult;

                item.ImgPath = mainFileUploadResult.Value;
             

                //Загрузка картинки по локализациям
                foreach (var localization in item.Localizations)
                {
                    var localizationFileUploadResult = await TryUploadFile($"{localization.LanguageId}_Img", FileType.Image);
                    if (!localizationFileUploadResult.Success) return localizationFileUploadResult;

                    localization.ImgPath = localizationFileUploadResult.Value;
                }


                //Предотвращаем записывание неверных данных
                item.Watches = 0;
                item.WatchesList = new List<Watch>();
                item.Category = null;
                item.Industry = null;

                res.SetSuccess();
            }

            return res;
        }

        #endregion
    }
}

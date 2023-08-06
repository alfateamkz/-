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
using Alfateam2._0.Models.Localization.Items.Posts;
using Alfateam2._0.Models.Posts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Alfateam.Website.API.Controllers.Admin
{
    public class AdminPostsController : AbsAdminController
    {
        public AdminPostsController(WebsiteDBContext db, IWebHostEnvironment appEnv) : base(db, appEnv)
        {
        }

        #region Новости

        [HttpGet, Route("GetPosts")]
        public async Task<RequestResult<IEnumerable<PostClientModel>>> GetPosts(int offset, int count = 20)
        {
            var res = new RequestResult<IEnumerable<PostClientModel>>();


            var session = GetSessionWithRoleInclude();
            var contentRightsCheck = CheckContentAreaRights(session, ContentAccessModelType.Posts, 1);
            if (!contentRightsCheck.Success)
            {
                return res.FillFromRequestResult(contentRightsCheck);
            }
            else
            {
                var items = GetPosts();

                var availableModels = this.GetAvailableModels(session.User, items);
                availableModels = availableModels.Skip(offset).Take(count);

                var posts = PostClientModel.CreateItems(availableModels.Cast<Post>().ToList(), LanguageId);
                return res.SetSuccess(posts);
            }
        }

        [HttpGet, Route("GetPost")]
        public async Task<RequestResult<Post>> GetPost(int id)
        {
            var res = new RequestResult<Post>();

            var post = GetFullIncludedPosts().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (post == null)
            {
                return res.SetError(404, "Новость по данному id не найдена");
            }

            var session = GetSessionWithRoleInclude();
            var contentRightsCheck = CheckContentAreaRights(session, post, ContentAccessModelType.Posts, 1);
            if (!contentRightsCheck.Success)
            {
                return res.FillFromRequestResult(contentRightsCheck);
            }

            return res.SetSuccess(post);
        }





        [HttpPost, Route("CreatePost")]
        public async Task<RequestResult<Post>> CreatePost(Post item)
        {
            return await TryCreate(DB.Posts, item, () => ValidateAndPreparePost(item));
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
                var mainFile = Request.Form.Files.FirstOrDefault(o => o.Name == "mainImg");
                var mainFileCheckRes = this.CheckImageFile(mainFile);
                if (!mainFileCheckRes.Success)
                {
                    res.FillFromRequestResult(mainFileCheckRes);
                    res.Error += $"\r\nПроблема с файлом mainImg";
                    return res;
                }

                item.ImgPath = await this.UploadFile(mainFile);



                //Загрузка картинки по локализациям
                foreach (var localization in item.Localizations)
                {
                    var localizationFile = Request.Form.Files.FirstOrDefault(o => o.Name == $"{localization.LanguageId}_Img");
                    var localizationFileCheckRes = this.CheckImageFile(localizationFile);

                    if (!localizationFileCheckRes.Success)
                    {
                        res.FillFromRequestResult(localizationFileCheckRes);
                        res.Error += $"\r\nПроблема с файлом {localization.LanguageId}_Img";
                        return res;
                    }

                    localization.ImgPath = await this.UploadFile(localizationFile);
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


        [HttpPut, Route("UpdatePostMain")]
        public async Task<RequestResult<Post>> UpdatePostMain(PostMainEditModel model)
        {
            var res = new RequestResult<Post>();

            var post = DB.Posts.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
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
                    var mainFile = Request.Form.Files.FirstOrDefault(o => o.Name == "mainImg");
                    var mainFileCheckRes = this.CheckImageFile(mainFile);
                    if (!mainFileCheckRes.Success)
                    {
                        res.FillFromRequestResult(mainFileCheckRes);
                        res.Error += $"\r\nПроблема с файлом mainImg";
                        return res;
                    }

                    post.ImgPath = await this.UploadFile(mainFile);
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
            if(localization == null)
            {
                return res.SetError(404, "Локализация с данным id не найдена");
            }
            var post = DB.Posts.FirstOrDefault(o => o.Id == localization.PostId && !o.IsDeleted);
            if (post == null)
            {
                return res.SetError(400, "Внутренняя ошибка");
            }


            var session = GetSessionWithRoleInclude();
            var contentRightsCheck = CheckContentAreaRights(session, post, ContentAccessModelType.Posts, 3);
            if (!contentRightsCheck.Success)
            {
                return res.FillFromRequestResult(contentRightsCheck);
            }


            if (!model.IsValid())
            {
                return res.SetError(400, "Не заполнены все необходимые поля. Сверьтесь с документацией и попробуйте еще раз");
            }
            else
            {
                if(localization.ImgPath != model.ImgPath)
                {
                    var localizationFile = Request.Form.Files.FirstOrDefault(o => o.Name == $"{localization.LanguageId}_Img");
                    var localizationFileCheckRes = this.CheckImageFile(localizationFile);

                    if (!localizationFileCheckRes.Success)
                    {
                        res.FillFromRequestResult(localizationFileCheckRes);
                        res.Error += $"\r\nПроблема с файлом {localization.LanguageId}_Img";
                        return res;
                    }

                    localization.ImgPath = await this.UploadFile(localizationFile);
                }

                model.Fill(localization);

                DB.PostLocalizations.Update(localization);
                DB.SaveChanges();

                return res.SetSuccess(localization);
            }

        }





        [HttpDelete,Route("DeletePost")]
        public async Task<RequestResult> DeletePost(int postId)
        {
            var res = new RequestResult();

            var post = DB.Posts.FirstOrDefault(o => o.Id == postId && !o.IsDeleted);
            if (post == null)
            {
                return res.SetError(404, "Новость по данному id не найдена");
            }

            return TryDelete(DB.Posts, post);
        }

        #endregion

        #region Категории новостей

        [HttpGet, Route("GetPostCategories")]
        public async Task<RequestResult<IEnumerable<PostCategoryClientModel>>> GetPostCategories(int offset, int count = 20)
        {
            var res = new RequestResult<IEnumerable<PostCategoryClientModel>>();


            var session = GetSessionWithRoleInclude();
            var contentRightsCheck = CheckContentAreaRights(session, ContentAccessModelType.Posts, 1);
            if (!contentRightsCheck.Success)
            {
                return res.FillFromRequestResult(contentRightsCheck);
            }
            else
            {
                var items = GetPostCategoriesList().ToList();

                var availableModels = this.GetAvailableModels(session.User, items);
                availableModels = availableModels.Skip(offset).Take(count);

                var posts = PostCategoryClientModel.CreateItems(availableModels.Cast<PostCategory>().ToList(), LanguageId);
                return res.SetSuccess(posts);
            }
        }

        [HttpGet, Route("GetPostCategory")]
        public async Task<RequestResult<PostCategory>> GetPostCategory(int id)
        {
            var res = new RequestResult<PostCategory>();

            var item = GetPostCategoriesList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (item == null)
            {
                return res.SetError(404, "Запись по данному id не найдена");
            }

            var session = GetSessionWithRoleInclude();
            var contentRightsCheck = CheckContentAreaRights(session, item, ContentAccessModelType.Posts, 1);
            if (!contentRightsCheck.Success)
            {
                return res.FillFromRequestResult(contentRightsCheck);
            }

            return res.SetSuccess(item);
        }

        [HttpPost, Route("CreatePostCategory")]
        public async Task<RequestResult<PostCategory>> CreatePostCategory(PostCategory item)
        {
            return TryCreate(DB.PostCategories, item);
        }





        [HttpPut, Route("UpdatePostCategoryMain")]
        public async Task<RequestResult<PostCategory>> UpdatePostCategoryMain(PostCategoryMainEditModel model)
        {
            var res = new RequestResult<PostCategory>();

            var baseCheckResult = CheckMainModelBeforeUpdate(DB.PostCategories, model);
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

            var checkResult = CheckLocalizationModelBeforeUpdate(DB.PostCategories, model, localization.PostCategoryId);
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

            var item = DB.PostCategories.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (item == null)
            {
                return res.SetError(404, "Категория по данному id не найдена");
            }

            return TryDelete(DB.PostCategories, item);
        }
        #endregion

        #region Индустрии новостей

        [HttpGet, Route("GetPostIndustries")]
        public async Task<RequestResult<IEnumerable<PostIndustryClientModel>>> GetPostIndustries(int offset, int count = 20)
        {
            var res = new RequestResult<IEnumerable<PostIndustryClientModel>>();


            var session = GetSessionWithRoleInclude();
            var contentRightsCheck = CheckContentAreaRights(session, ContentAccessModelType.Posts, 1);
            if (!contentRightsCheck.Success)
            {
                return res.FillFromRequestResult(contentRightsCheck);
            }
            else
            {
                var items = GetPostPostIndustriesList().ToList();

                var availableModels = this.GetAvailableModels(session.User, items);
                availableModels = availableModels.Skip(offset).Take(count);

                var posts = PostIndustryClientModel.CreateItems(availableModels.Cast<PostIndustry>().ToList(), LanguageId);
                return res.SetSuccess(posts);
            }
        }

        [HttpGet, Route("GetPostIndustry")]
        public async Task<RequestResult<PostIndustry>> GetPostIndustry(int id)

        {
            var res = new RequestResult<PostIndustry>();

            var item = GetPostPostIndustriesList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (item == null)
            {
                return res.SetError(404, "Запись по данному id не найдена");
            }

            var session = GetSessionWithRoleInclude();
            var contentRightsCheck = CheckContentAreaRights(session, item, ContentAccessModelType.Posts, 1);
            if (!contentRightsCheck.Success)
            {
                return res.FillFromRequestResult(contentRightsCheck);
            }

            return res.SetSuccess(item);
        }

        [HttpPost, Route("CreatePostIndustry")]
        public async Task<RequestResult<PostIndustry>> CreatePostIndustry(PostIndustry item)
        {
            return TryCreate(DB.PostIndustries,item);    
        }





        [HttpPut, Route("UpdatePostIndustryMain")]
        public async Task<RequestResult<PostIndustry>> UpdatePostIndustryMain(PostIndustryMainEditModel model)
        {
            var res = new RequestResult<PostIndustry>();

            var baseCheckResult = CheckMainModelBeforeUpdate(DB.PostIndustries, model);
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

            var checkResult = CheckLocalizationModelBeforeUpdate(DB.PostIndustries, model, localization.PostIndustryId);
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

            var item = DB.PostIndustries.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (item == null)
            {
                return res.SetError(404, "Индустрия по данному id не найдена");
            }

            return TryDelete(DB.PostIndustries, item);
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
                            .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId));
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
                            .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId));
        }


        public IQueryable<PostCategory> GetPostCategoriesList()
        {
            return DB.PostCategories.IncludeAvailability()
                                    .Include(o => o.Localizations).ThenInclude(o => o.Language)
                                    .Include(o => o.MainLanguage)
                                    .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId));
        }
        public IQueryable<PostIndustry> GetPostPostIndustriesList()
        {
            return DB.PostIndustries.IncludeAvailability()
                                    .Include(o => o.Localizations).ThenInclude(o => o.Language)
                                    .Include(o => o.MainLanguage)
                                    .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId));
        }

        #endregion
    }
}

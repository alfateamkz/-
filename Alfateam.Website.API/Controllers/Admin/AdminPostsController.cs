using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Core;
using Alfateam.Website.API.Enums;
using Alfateam.Website.API.Extensions;
using Alfateam.Website.API.Models.DTO.Posts;
using Alfateam.Website.API.Models.DTO.General;
using Alfateam.Website.API.Models.DTO.Posts;
using Alfateam.Website.API.Models.DTOLocalization.Posts;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Localization.Items;
using Alfateam2._0.Models.Localization.Items.Events;
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
        public async Task<RequestResult<IEnumerable<PostDTO>>> GetPosts(int offset, int count = 20)
        {
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<IEnumerable<PostDTO>>(new Func<RequestResult>[]
            {
                () => CheckContentAreaRights(session, ContentAccessModelType.Posts, 1),
                () => {
                    var items = GetAvailableModels(session.User, GetPosts(), offset, count);
                    var models = PostDTO.CreateItemsWithLocalization(items.Cast<Post>(), LanguageId) as IEnumerable<PostDTO>;
                    return RequestResult<IEnumerable<PostDTO>>.AsSuccess(models);
                }
            });
        }

        [HttpGet, Route("GetPost")]
        public async Task<RequestResult<Post>> GetPost(int id)
        {
            return TryGetOne(GetFullIncludedPosts(), id, ContentAccessModelType.Posts);
        }

        [HttpGet, Route("GetPostLocalization")]
        public async Task<RequestResult<PostLocalization>> GetPostLocalization(int id)
        {
            var localization = DB.PostLocalizations.Include(o => o.LanguageEntity).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (localization == null) return RequestResult<PostLocalization>.AsError(404, "Сущность с данным id не найдена");

            var mainEntity = GetPosts().FirstOrDefault(o => o.Id == localization.PostId && !o.IsDeleted);
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<PostLocalization>(new Func<RequestResult>[]
            {
                () => RequestResult.FromBoolean(mainEntity != null, 500, "Внутренняя ошибка"),
                () => CheckContentAreaRights(session, mainEntity, ContentAccessModelType.Posts, 1),
                () => RequestResult<PostLocalization>.AsSuccess(localization)
            });
        }






        [HttpPost, Route("CreatePost")]
        public async Task<RequestResult<Post>> CreatePost(Post item)
        {
            return await TryCreate(DB.Posts, item, ContentAccessModelType.Posts, () => PreparePostMainBeforeCreate(item));
        }

        [HttpPost, Route("CreatePostLocalization")]
        public async Task<RequestResult<PostLocalization>> CreatePostLocalization(int itemId, PostLocalization localization)
        {
            var mainEntity = GetPosts().FirstOrDefault(o => o.Id == itemId);
            return TryFinishAllRequestes<PostLocalization>(new[]
            {
                () => CheckLocalizationModelBeforeCreate(localization, mainEntity, ContentAccessModelType.Posts),
                () => PreparePostLocalizationBeforeCreate(localization).Result,
                () =>
                {
                    mainEntity.Localizations.Add(localization);
                    UpdateModel(DB.Posts,mainEntity);
                    return RequestResult<PostLocalization>.AsSuccess(localization);
                }
            });
        }




        [HttpPut, Route("UpdatePostMain")]
        public async Task<RequestResult<Post>> UpdatePostMain(PostDTO model)
        {
            var post = GetPosts().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<Post>(new[]
            {
                () => RequestResult.FromBoolean(post != null,404, "Сущность по данному id не найдена"),
                () => CheckContentAreaRights(session, post, ContentAccessModelType.Posts, 2),
                () => RequestResult.FromBoolean(model.IsValid(), 400, "Не заполнены все необходимые поля. Сверьтесь с документацией и попробуйте еще раз"),
                () => RequestResult.FromBoolean(DB.PostCategories.Any(o => o.Id == model.CategoryId && !o.IsDeleted), 404, "Категории с данным id не существует"),
                () => RequestResult.FromBoolean(DB.PostIndustries.Any(o => o.Id == model.IndustryId && !o.IsDeleted), 404, "Индустрия с данным id не найдена"),
                () => RequestResult.FromBoolean(DB.Languages.Any(o => o.Id == model.MainLanguageId && !o.IsDeleted), 404,  "Языка с данным id не существует"),
                () => PreparePostMainBeforeUpdate(post, model).Result,
                () => UpdateModel(DB.Posts, model, post)
            });

        }

        [HttpPut, Route("UpdatePostLocalization")]
        public async Task<RequestResult<PostLocalization>> UpdatePostLocalization(PostLocalizationDTO model)
        {
            var localization = DB.PostLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return TryFinishAllRequestes<PostLocalization>(new[]
            {
                () => RequestResult.FromBoolean(localization != null, 404, "Локализация с данным id не найдена"),
                () => CheckLocalizationModelBeforeUpdate(GetPosts(), model, localization.PostId, ContentAccessModelType.Posts),
                () => PreparePostLocalizationBeforeUpdate(localization,model).Result,
                () => UpdateModel(DB.PostLocalizations, model, localization)
            });
        }





        [HttpDelete,Route("DeletePost")]
        public async Task<RequestResult> DeletePost(int id)
        {
            var item = GetPosts().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(item != null,404, "Категория по данному id не найдена"),
                () => TryDelete(DB.Posts, item, ContentAccessModelType.Posts)
            });
        }

        [HttpDelete, Route("DeletePostLocalization")]
        public async Task<RequestResult> DeletePostLocalization(int id)
        {
            var item = DB.PostLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(item != null,404, "Запись по данному id не найдена"),
                () => CheckLocalizationModelBeforeDelete(GetPostCategoriesList(), item.PostId, ContentAccessModelType.Posts),
                () => DeleteModel(DB.PostLocalizations, item, false)
            });
        }

        #endregion

        #region Категории новостей

        [HttpGet, Route("GetPostCategories")]
        public async Task<RequestResult<IEnumerable<PostCategoryDTO>>> GetPostCategories(int offset, int count = 20)
        {
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<IEnumerable<PostCategoryDTO>>(new Func<RequestResult>[]
            {
                () => CheckContentAreaRights(session, ContentAccessModelType.Posts, 1),
                () => {
                    var items = GetAvailableModels(session.User, GetPostCategoriesList(), offset, count);
                    var models = PostCategoryDTO.CreateItemsWithLocalization(items.Cast<PostCategory>(), LanguageId) as IEnumerable<PostCategoryDTO>;
                    return RequestResult<IEnumerable<PostCategoryDTO>>.AsSuccess(models);
                }
            });
        }

        [HttpGet, Route("GetPostCategory")]
        public async Task<RequestResult<PostCategory>> GetPostCategory(int id)
        {
            return TryGetOne(GetPostCategoriesList(), id, ContentAccessModelType.Posts);
        }
    
        [HttpGet, Route("GetPostCategoryLocalization")]
        public async Task<RequestResult<PostCategoryLocalization>> GetPostCategoryLocalization(int id)
        {
            var localization = DB.PostCategoryLocalizations.Include(o => o.LanguageEntity).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (localization == null) return RequestResult<PostCategoryLocalization>.AsError(404, "Сущность с данным id не найдена");

            var mainEntity = GetPostCategoriesList().FirstOrDefault(o => o.Id == localization.PostCategoryId && !o.IsDeleted);
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<PostCategoryLocalization>(new Func<RequestResult>[]
            {
                () => RequestResult.FromBoolean(mainEntity != null, 500, "Внутренняя ошибка"),
                () => CheckContentAreaRights(session, mainEntity, ContentAccessModelType.Posts, 1),
                () => RequestResult<PostCategoryLocalization>.AsSuccess(localization)
            });
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
            return TryFinishAllRequestes<PostCategoryLocalization>(new[]
            {
                () => CheckLocalizationModelBeforeCreate(localization, mainEntity, ContentAccessModelType.Posts),
                () =>
                {
                    mainEntity.Localizations.Add(localization);
                    UpdateModel(DB.PostCategories,mainEntity);
                    return RequestResult<PostCategoryLocalization>.AsSuccess(localization);
                }
            });
        }





        [HttpPut, Route("UpdatePostCategoryMain")]
        public async Task<RequestResult<PostCategory>> UpdatePostCategoryMain(PostCategoryDTO model)
        {
            var item = GetPostCategoriesList().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return TryFinishAllRequestes<PostCategory>(new[]
            {
                () => CheckMainModelBeforeUpdate(item, model,ContentAccessModelType.Posts),
                () => RequestResult.FromBoolean(DB.Languages.Any(o => o.Id == model.MainLanguageId && !o.IsDeleted),
                                                    404, "Языка с данным id не существует"),
                () => UpdateModel(DB.PostCategories, model, item)
            });
        }

        [HttpPut, Route("UpdatePostCategoryLocalization")]
        public async Task<RequestResult<PostCategoryLocalization>> UpdatePostCategoryLocalization(PostCategoryLocalizationDTO model)
        {
            var localization = DB.PostCategoryLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return TryFinishAllRequestes<PostCategoryLocalization>(new[]
            {
                () => RequestResult.FromBoolean(localization != null,404, "Локализация с данным id не найдена"),
                () => CheckLocalizationModelBeforeUpdate(GetPostCategoriesList(), model, localization.PostCategoryId, ContentAccessModelType.Posts),
                () => UpdateModel(DB.PostCategoryLocalizations, model, localization)
            });
        }





        [HttpDelete, Route("DeletePostCategory")]
        public async Task<RequestResult> DeletePostCategory(int id)
        {
            var item = GetPostCategoriesList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(item != null,404, "Категория по данному id не найдена"),
                () => TryDelete(DB.PostCategories, item, ContentAccessModelType.Posts)
            });
        }

        [HttpDelete, Route("DeletePostCategoryLocalization")]
        public async Task<RequestResult> DeletePostCategoryLocalization(int id)
        {
            var item = DB.PostCategoryLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(item != null,404, "Запись по данному id не найдена"),
                () => CheckLocalizationModelBeforeDelete(GetPostCategoriesList(), item.PostCategoryId, ContentAccessModelType.Posts),
                () => DeleteModel(DB.PostCategoryLocalizations, item, false)
            });
        }


        #endregion

        #region Индустрии новостей

        [HttpGet, Route("GetPostIndustries")]
        public async Task<RequestResult<IEnumerable<PostIndustryDTO>>> GetPostIndustries(int offset, int count = 20)
        {
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<IEnumerable<PostIndustryDTO>>(new Func<RequestResult>[]
            {
                () => CheckContentAreaRights(session, ContentAccessModelType.Posts, 1),
                () => {
                    var items = GetAvailableModels(session.User, GetPostCategoriesList(), offset, count);
                    var models = PostIndustryDTO.CreateItemsWithLocalization(items.Cast<PostIndustry>(), LanguageId) as IEnumerable<PostIndustryDTO>;
                    return RequestResult<IEnumerable<PostIndustryDTO>>.AsSuccess(models);
                }
            });
        }

        [HttpGet, Route("GetPostIndustry")]
        public async Task<RequestResult<PostIndustry>> GetPostIndustry(int id)
        {
            return TryGetOne(GetPostPostIndustriesList(), id, ContentAccessModelType.Posts);
        }

        [HttpGet, Route("GetPostIndustryLocalization")]
        public async Task<RequestResult<PostIndustryLocalization>> GetPostIndustryLocalization(int id)
        {
            var localization = DB.PostIndustryLocalizations.Include(o => o.LanguageEntity).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (localization == null) return RequestResult<PostIndustryLocalization>.AsError(404, "Сущность с данным id не найдена");

            var mainEntity = GetPostCategoriesList().FirstOrDefault(o => o.Id == localization.PostIndustryId && !o.IsDeleted);
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<PostIndustryLocalization>(new Func<RequestResult>[]
            {
                () => RequestResult.FromBoolean(mainEntity != null, 500, "Внутренняя ошибка"),
                () => CheckContentAreaRights(session, mainEntity, ContentAccessModelType.Posts, 1),
                () => RequestResult<PostIndustryLocalization>.AsSuccess(localization)
            });
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
            return TryFinishAllRequestes<PostIndustryLocalization>(new[]
            {
                () => CheckLocalizationModelBeforeCreate(localization, mainEntity, ContentAccessModelType.Posts),
                () =>
                {
                    mainEntity.Localizations.Add(localization);
                    UpdateModel(DB.PostIndustries,mainEntity);
                    return RequestResult<PostIndustryLocalization>.AsSuccess(localization);
                }
            });
        }




        [HttpPut, Route("UpdatePostIndustryMain")]
        public async Task<RequestResult<PostIndustry>> UpdatePostIndustryMain(PostIndustryDTO model)
        {
            var item = GetPostPostIndustriesList().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return TryFinishAllRequestes<PostIndustry>(new[]
            {
                () => CheckMainModelBeforeUpdate(item, model,ContentAccessModelType.Posts),
                () => RequestResult.FromBoolean(DB.Languages.Any(o => o.Id == model.MainLanguageId && !o.IsDeleted),
                                                    404, "Языка с данным id не существует"),
                () => UpdateModel(DB.PostIndustries, model, item)
            });
        }

        [HttpPut, Route("UpdatePostIndustryLocalization")]
        public async Task<RequestResult<PostIndustryLocalization>> UpdatePostIndustryLocalization(PostIndustryLocalizationDTO model)
        {
            var localization = DB.PostIndustryLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return TryFinishAllRequestes<PostIndustryLocalization>(new[]
            {
                () => RequestResult.FromBoolean(localization != null,404, "Локализация с данным id не найдена"),
                () => CheckLocalizationModelBeforeUpdate(GetPostCategoriesList(), model, localization.PostIndustryId, ContentAccessModelType.Posts),
                () => UpdateModel(DB.PostIndustryLocalizations, model, localization)
            });
        }






        [HttpDelete, Route("DeletePostIndustry")]
        public async Task<RequestResult> DeletePostIndustry(int id)
        {
            var item = GetPostPostIndustriesList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(item != null,404, "Категория по данному id не найдена"),
                () => TryDelete(DB.PostIndustries, item, ContentAccessModelType.Posts)
            });
        }

        [HttpDelete, Route("DeletePostIndustryLocalization")]
        public async Task<RequestResult> DeletePostIndustryLocalization(int id)
        {
            var item = DB.PostIndustryLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(item != null,404, "Запись по данному id не найдена"),
                () => CheckLocalizationModelBeforeDelete(GetPostCategoriesList(), item.PostIndustryId, ContentAccessModelType.Posts),
                () => DeleteModel(DB.PostIndustryLocalizations, item, false)
            });
        }


        #endregion


        [HttpPut, Route("UpdateAvailability")]
        public async Task<RequestResult<Availability>> UpdateAvailability(AvailabilityDTO model)
        {
            bool hasThisModel = false;

            var user = GetSessionWithRoleInclude().User;
            hasThisModel |= GetAvailableModels(user, DB.Posts.IncludeAvailability()).Any(o => o.AvailabilityId == model.Id && !o.IsDeleted);
            hasThisModel |= GetAvailableModels(user, DB.PostCategories.IncludeAvailability()).Any(o => o.AvailabilityId == model.Id && !o.IsDeleted);
            hasThisModel |= GetAvailableModels(user, DB.PostIndustries.IncludeAvailability()).Any(o => o.AvailabilityId == model.Id && !o.IsDeleted);

            if (!hasThisModel)
            {
                return new RequestResult<Availability>().SetError(403, "У данного пользователя нет прав на редактирование матрицы доступности");
            }

            return TryUpdateAvailability(model, ContentAccessModelType.Posts);
        }





        #region Private prepare methods

        private async Task<RequestResult> PreparePostMainBeforeCreate(Post item)
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
                if (!mainFileUploadResult.Success)
                {
                    return mainFileUploadResult;
                }
                item.ImgPath = mainFileUploadResult.Value;


                //Загрузка картинки по локализациям
                foreach (var localization in item.Localizations)
                {
                    var localizationPrepareResult = await PreparePostLocalizationBeforeCreate(localization);
                    if (!localizationPrepareResult.Success)
                    {
                        return localizationPrepareResult;
                    }
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
        private async Task<RequestResult> PreparePostLocalizationBeforeCreate(PostLocalization localization)
        {

            var localizationFileUploadResult = TryUploadFile($"{localization.LanguageEntityId}_img", FileType.Image).Result;
            if (!localizationFileUploadResult.Success)
            {
                return localizationFileUploadResult;
            }
            localization.ImgPath = localizationFileUploadResult.Value;


            var uploadRes = await UploadContentMedia(localization.Content);
            if (!uploadRes.Success)
            {
                return uploadRes;
            }

            return RequestResult.AsSuccess();
        }


        private async Task<RequestResult> PreparePostMainBeforeUpdate(Post post, PostDTO model)
        {
            if (Request.Form.Files.Any(o => o.Name == $"mainImg"))
            {
                //Загрузка главной картинки
                var mainFileUploadResult = await TryUploadFile("mainImg", FileType.Image);
                if (!mainFileUploadResult.Success)
                {
                    return mainFileUploadResult;
                }
                post.ImgPath = mainFileUploadResult.Value;
            }

            if (!post.Content.AreSame(model.Content))
            {
                var uploadRes = await UploadContentMedia(model.Content);
                if (!uploadRes.Success)
                {
                    return uploadRes;
                }
                post.Content = model.Content;
            }

            return RequestResult.AsSuccess();
        }
        private async Task<RequestResult> PreparePostLocalizationBeforeUpdate(PostLocalization localization, PostLocalizationDTO model)
        {
            if (Request.Form.Files.Any(o => o.Name == $"{localization.LanguageEntityId}_img"))
            {
                var localizationFileUploadResult = TryUploadFile($"{localization.LanguageEntityId}_img", FileType.Image).Result;
                if (!localizationFileUploadResult.Success)
                {
                    return localizationFileUploadResult;
                }
                localization.ImgPath = localizationFileUploadResult.Value;
            }

            if (!localization.Content.AreSame(model.Content))
            {
                var uploadRes = await UploadContentMedia(model.Content);
                if (!uploadRes.Success)
                {
                    return uploadRes;
                }
                localization.Content = model.Content;
            }


            return RequestResult.AsSuccess();
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

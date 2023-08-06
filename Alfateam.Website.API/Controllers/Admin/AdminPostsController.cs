using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Enums;
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
        public async Task<RequestResult<IEnumerable<Post>>> GetPosts(int offset, int count = 20)
        {
            var res = new RequestResult<IEnumerable<Post>>();

            var session = GetSessionWithRoleInclude();
            var checkSessionRes = CheckSession(session);
            if (!checkSessionRes.Success)
            {
                res.FillFromRequestResult(checkSessionRes);
                return res;
            }

            if(!session.User.RoleModel.PostsAccess.CanWatch && session.User.RoleModel.Role != UserRole.Owner)
            {
                res.Code = 403;
                res.Error = "У данного пользователя нет прав на просмотр";
            }
            else
            {
                var items = DB.Posts.Include(o => o.Category)
                                    .Include(o => o.Industry)
                                    .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId))
                                    .ToList();

                var availableModels = this.GetAvailableModels(session.User, items.Cast<AvailabilityModel>());
                availableModels = availableModels.Skip(offset).Take(count);

                res.Success = true;
                res.Value = availableModels.Cast<Post>();
            }

            return res;
        }



        [HttpPost, Route("CreatePost")]
        public async Task<RequestResult<Post>> CreatePost(Post item)
        {
            var res = new RequestResult<Post>();

            var session = GetSessionWithRoleInclude();
            var checkSessionRes = CheckSession(session);
            if (!checkSessionRes.Success)
            {
                res.FillFromRequestResult(checkSessionRes);
                return res;
            }

            if (!session.User.RoleModel.PostsAccess.CanCreateNew && session.User.RoleModel.Role != UserRole.Owner)
            {
                res.SetError(403, "У данного пользователя нет прав на создание записи");
            }
            else if (!item.IsValid())
            {
                res.SetError(400, "Не заполнены все необходимые поля. Сверьтесь с документацией и попробуйте еще раз");
            }
            else if (!DB.PostCategories.Any(o => o.Id == item.CategoryId && !o.IsDeleted))
            {
                res.SetError(404, "Категории с данным id не существует");
            }
            else if (!DB.PostIndustries.Any(o => o.Id == item.IndustryId && !o.IsDeleted))
            {
                res.SetError(404, "Индустрии с данным id не существует");
            }
            else if (!DB.Languages.Any(o => o.Id == item.MainLanguageId && !o.IsDeleted))
            {
                res.SetError(404, "Языка с данным id не существует");
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

                DB.Posts.Add(item);
                DB.SaveChanges();
                
                res.Value = item;
                res.Success = true;
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
                res.SetError(404, "Новость по данному id не найдена");
                return res;
            }


            var session = GetSessionWithRoleInclude();
            var baseCheckRes = CheckBaseRights(session, post);
            if (!baseCheckRes.Success)
            {
                res.FillFromRequestResult(baseCheckRes);
                return res;
            }
            if (!session.User.RoleModel.PostsAccess.CanEditCurrent && session.User.RoleModel.Role != UserRole.Owner)
            {
                res.SetError(403, "У данного пользователя нет прав на редактирование записи");
                return res;
            }

           

            if (!model.IsValid())
            {
                res.SetError(400, "Не заполнены все необходимые поля. Сверьтесь с документацией и попробуйте еще раз");
            }
            else if (!DB.PostCategories.Any(o => o.Id == model.CategoryId && !o.IsDeleted))
            {
                res.SetError(404, "Категории с данным id не существует");
            }
            else if (!DB.PostIndustries.Any(o => o.Id == model.IndustryId && !o.IsDeleted))
            {
                res.SetError(404, "Индустрии с данным id не существует");
            }
            else if (!DB.Languages.Any(o => o.Id == model.MainLanguageId && !o.IsDeleted))
            {
                res.SetError(404, "Языка с данным id не существует");
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

                res.Success = true;
                res.Value = post;
            }



            return res;
        }

        [HttpPut, Route("UpdatePostLocalization")]
        public async Task<RequestResult<PostLocalization>> UpdatePostLocalization(PostLocalizationEditModel model)
        {
            var res = new RequestResult<PostLocalization>();

            var localization = DB.PostLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            if(localization == null)
            {
                res.SetError(404, "Локализация с данным id не найдена");
                return res;
            }
            var post = DB.Posts.FirstOrDefault(o => o.Id == localization.PostId && !o.IsDeleted);
            if (post == null)
            {
                res.SetError(400, "Внутренняя ошибка");
                return res;
            }


            var session = GetSessionWithRoleInclude();
            var baseCheckRes = CheckBaseRights(session, post);
            if (!baseCheckRes.Success)
            {
                res.FillFromRequestResult(baseCheckRes);
                return res;
            }
            if (!session.User.RoleModel.PostsAccess.CanEditLocalizations && session.User.RoleModel.Role != UserRole.Owner)
            {
                res.SetError(403, "У данного пользователя нет прав на редактирование локализаций записи");
                return res;
            }

            if (!model.IsValid())
            {
                res.SetError(400, "Не заполнены все необходимые поля. Сверьтесь с документацией и попробуйте еще раз");
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

                res.Value = localization;
                res.Success = true;
            }

            return res;
        }





        [HttpDelete,Route("DeletePost")]
        public async Task<RequestResult> DeletePost(int postId)
        {
            var res = new RequestResult();

            var post = DB.Posts.FirstOrDefault(o => o.Id == postId && !o.IsDeleted);
            if (post == null)
            {
                res.Code = 404;
                res.Error = "Новость по данному id не найдена";
                return res;
            }

            

            var session = GetSessionWithRoleInclude();
            var baseCheckRes = CheckBaseRights(session, post);
            if(!baseCheckRes.Success)
            {
                res.FillFromRequestResult(baseCheckRes);
                return res;
            }


            if (!session.User.RoleModel.PostsAccess.CanDelete && session.User.RoleModel.Role != UserRole.Owner)
            {
                res.Code = 403;
                res.Error = "У данного пользователя нет прав на удаление записи";
            }
            else
            {
                post.IsDeleted = true;

                DB.Posts.Update(post);
                DB.SaveChanges();

                res.Success = true;
            }


            return res;
        }

        #endregion




    }
}

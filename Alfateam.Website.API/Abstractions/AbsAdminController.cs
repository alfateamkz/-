using Alfateam.DB;
using Alfateam.Website.API.Enums;
using Alfateam.Website.API.Models.ClientModels.Posts;
using Alfateam.Website.API.Models.Core;
using Alfateam2._0.Models;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.ContentItems;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Posts;
using Alfateam2._0.Models.Roles.Access;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Alfateam.Website.API.Abstractions
{
    public abstract class AbsAdminController : AbsController
    {
        protected AbsAdminController(WebsiteDBContext db, IWebHostEnvironment appEnv) : base(db, appEnv)
        {
            
        }

        //TODO: Рефакторинг методов создания и апдейта, слишком много входных параметров
        //TODO: В будущем: таблица файлов, удаление невостребованных(например файл был загружен на сервер, но дальше вышла ошибка и по факту моделька не сохранилась)
        

        [NonAction]
        protected Session GetSessionWithRoleInclude()
        {
            var session = DB.Sessions.Include(o => o.User).ThenInclude(o => o.RoleModel).ThenInclude(o => o.AvailableCountries)
                                     .Include(o => o.User).ThenInclude(o => o.RoleModel).ThenInclude(o => o.ForbiddenCountries)
                                     .Include(o => o.User).ThenInclude(o => o.RoleModel).ThenInclude(o => o.ContentAccessTypes)
                                     .FirstOrDefault(o => o.SessID == this.UserSessid);
            return session;
        }



        protected IEnumerable<AvailabilityModel> GetAvailableModels(User user,IEnumerable<AvailabilityModel> allModels)
        {
            var allowedModels = new List<AvailabilityModel>();

            //TODO: внимательно изучить и доработаь

            if (user.RoleModel.IsAllCountriesAccess)
            {
                //кроме запрещенных стран6
                return allModels;
            }
            else
            {
                foreach (var model in allModels)
                {
                    if (model.Availability.AvailableInAllCountries)
                    {
                        allowedModels.Add(model);
                    }
                    else
                    {
                        foreach(var country in user.RoleModel.AvailableCountries)
                        {
                            bool isAvailable = model.Availability.IsAvailable(country.Id);
                            if (isAvailable)
                            {
                                allowedModels.Add(model);
                                break;
                            }
                        }
                    }
                }
            }

            return allowedModels;
        }



        protected async Task<RequestResult> UploadContentMedia(Content content)
        {
            foreach(var item in content.Items)
            {
                if(item is AudioContentItem audio)
                {
                    var fileUploadResult = await TryUploadFile(item.Guid, FileType.Audio);
                    if (!fileUploadResult.Success) return fileUploadResult;

                    audio.AudioPath = fileUploadResult.Value;
                }
                else if (item is ImageContentItem image)
                {
                    var fileUploadResult = await TryUploadFile(item.Guid, FileType.Image);
                    if (!fileUploadResult.Success) return fileUploadResult;

                    image.ImgPath = fileUploadResult.Value;
                }
                else if (item is ImageSliderContentItem slider)
                {
                    foreach(var img in slider.Images)
                    {
                        var fileUploadResult = await TryUploadFile(item.Guid, FileType.Image);
                        if (!fileUploadResult.Success) return fileUploadResult;

                        img.ImgPath = fileUploadResult.Value;
                    }
                }
                else if (item is VideoContentItem video)
                {
                    var fileUploadResult = await TryUploadFile(item.Guid, FileType.Video);
                    if (!fileUploadResult.Success) return fileUploadResult;

                    video.VideoPath = fileUploadResult.Value;
                }
            }

            return RequestResult.AsSuccess();
        }


        #region Проверка прав

    
        protected RequestResult CheckBaseRights(Session session, AvailabilityModel model)
        {
            var res = new RequestResult();

            var checkSessionRes = CheckSession(session);
            if (!checkSessionRes.Success)
            {
                return res.FillFromRequestResult(checkSessionRes);
            }
            if (!this.CheckBasePermissions(session.User, model))
            {
                return res.SetError(403, "У данного пользователя нет доступа к записи");
            }

            return res.SetSuccess();
        }
        protected RequestResult CheckContentAreaRights(Session session, AvailabilityModel model, ContentAccessModelType type, int requiredLevel)
        {
            var checkBase = CheckBaseRights(session, model);
            if (!checkBase.Success)
            {
                return checkBase;
            }

            return SetCheckContentAreaRights(session,type, requiredLevel);
        }
        protected RequestResult CheckContentAreaRights(Session session, ContentAccessModelType type, int requiredLevel)
        {
            return SetCheckContentAreaRights(session,type, requiredLevel);
        }




        private bool IsInAdminRole(User user)
        {
            return user.RoleModel.Role == UserRole.Admin || user.RoleModel.Role == UserRole.Owner;
        }
        private bool CheckBasePermissions(User user, AvailabilityModel model/*, AdminActionType type*/)
        {
            bool success = IsInAdminRole(user);
            if (!success) return success;

            if(user.RoleModel.Role == UserRole.Owner) return true;


            //TODO: доработать пермишены

            if (!user.RoleModel.IsAllCountriesAccess)
            {
                bool isAvailable = model.Availability.IsAvailable(user.RoleModel.AvailableCountries);

                success &= isAvailable;
            }
            else
            {
                bool isAvailable = true;


                bool hasForbiddenCountry = false;
                if (model.Availability.AvailableInAllCountries)
                {
                    hasForbiddenCountry = user.RoleModel.ForbiddenCountries.Any();
                }
                else
                {
                    foreach (var country in user.RoleModel.ForbiddenCountries)
                    {
                        hasForbiddenCountry = model.Availability.AllowedCountries.Any(o => o.Id == country.Id);
                        if (hasForbiddenCountry) break;
                    }
                }

 

                if (hasForbiddenCountry)
                {
                    if (model.Availability.AvailableInAllCountries)
                    {

                    }
                }
                else
                {
                    isAvailable = true;
                }
               
               
            }
    

            return success;
        }
        private RequestResult SetCheckContentAreaRights(Session session, ContentAccessModelType type, int requiredLevel)
        {
            var res = new RequestResult();

            var userAccess = session.User.RoleModel.GetContentAccess(type);
            if (userAccess == null)
            {
                userAccess = session.User.RoleModel.GetContentAccess(ContentAccessModelType.All);
                if (userAccess == null)
                {
                    res.SetError(403, "У пользователя нет прав на данный раздел");
                    return res;
                }
            }



            if (userAccess.AccessLevel < requiredLevel && session.User.RoleModel.Role != UserRole.Owner)
            {
                switch (requiredLevel)
                {
                    case 1:
                        res.SetError(403, "У пользователя нет прав на просмотр записей");
                        break;
                    case 2:
                        res.SetError(403, "У пользователя нет прав на редактирование записей");
                        break;
                    case 3:
                        res.SetError(403, "У пользователя нет прав на редактирование локализаций записей");
                        break;
                    case 4:
                        res.SetError(403, "У пользователя нет прав на создание новых записей");
                        break;
                    case 5:
                        res.SetError(403, "У пользователя нет прав на удаление записей");
                        break;
                }
            }
            else
            {
                res.Success = true;
            }

            return res;
        }




        #endregion


        #region Обобщенные методы получения объектов
        protected RequestResult<IEnumerable<T>> TryGetMany<T>(IEnumerable<T> fromModels, ContentAccessModelType accessType, int offset,int count = 20) where T : AvailabilityModel
        {
            var res = new RequestResult<IEnumerable<T>>();


            var session = GetSessionWithRoleInclude();
            var contentRightsCheck = CheckContentAreaRights(session, accessType, 1);
            if (!contentRightsCheck.Success)
            {
                return res.FillFromRequestResult(contentRightsCheck);
            }
            else
            {
                var availableModels = this.GetAvailableModels(session.User, fromModels);
                availableModels = availableModels.Skip(offset).Take(count);

                return res.SetSuccess(availableModels.Cast<T>());
            }
        }
        protected RequestResult<T> TryGetOne<T>(IEnumerable<T> fromModels, int id, ContentAccessModelType accessType) where T: AvailabilityModel
        {
            var res = new RequestResult<T>();

            var item = fromModels.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (item == null)
            {
                return res.SetError(404, "Запись по данному id не найдена");
            }

            var session = GetSessionWithRoleInclude();
            var contentRightsCheck = CheckContentAreaRights(session, item, accessType, 1);
            if (!contentRightsCheck.Success)
            {
                return res.FillFromRequestResult(contentRightsCheck);
            }

            return res.SetSuccess(item);
        }
        #endregion

        #region Обобщенные методы создания объекта
        protected RequestResult<T> TryCreate<T>(DbSet<T> dbSet,T item, ContentAccessModelType accessType) where T : AvailabilityModel
        {
            var res = CheckBaseBeforeCreate(item, accessType);
            if (!res.Success)
            {
                return res;
            }

            dbSet.Add(item);
            DB.SaveChanges();

            return res.SetSuccess(item);
        }
        protected RequestResult<T> TryCreate<T>(DbSet<T> dbSet, T item, ContentAccessModelType accessType, Func<RequestResult> callback) where T : AvailabilityModel
        {
            var res = CheckBaseBeforeCreate(item, accessType);
            if (!res.Success)
            {
                return res;
            }

            var callbackRes = callback.Invoke();
            if (!callbackRes.Success) return res.FillFromRequestResult(callbackRes);


            dbSet.Add(item);
            DB.SaveChanges();

            return res.SetSuccess(item);
        }
        protected async Task<RequestResult<T>> TryCreate<T>(DbSet<T> dbSet, T item, ContentAccessModelType accessType, Func<Task<RequestResult>> callback) where T : AvailabilityModel
        {
            var res = CheckBaseBeforeCreate(item, accessType);
            if (!res.Success)
            {
                return res;
            }

            var callbackRes = await callback.Invoke();
            if (!callbackRes.Success) return res.FillFromRequestResult(callbackRes);


            dbSet.Add(item);
            DB.SaveChanges();

            return res.SetSuccess(item);
        }





        protected RequestResult CheckLocalizationModelBeforeCreate<T>(LocalizableModel model,
                                                                      T mainEntity,
                                                                      ContentAccessModelType accessType) where T : AvailabilityModel
        {
            if (mainEntity == null)
            {
                return new RequestResult().SetError(400, "Внутренняя ошибка");
            }


            var session = GetSessionWithRoleInclude();
            var contentRightsCheck = CheckContentAreaRights(session, mainEntity, accessType, 3);
            if (!contentRightsCheck.Success)
            {
                return new RequestResult().FillFromRequestResult(contentRightsCheck);
            }


            if (!model.IsValid())
            {
                return new RequestResult().SetError(400, "Некорректно заполнены все необходимые поля. Сверьтесь с документацией и попробуйте еще раз");
            }

            return new RequestResult().SetSuccess();
        }
        private RequestResult<T> CheckBaseBeforeCreate<T>(T item, ContentAccessModelType accessType) where T : AvailabilityModel
        {

            var session = GetSessionWithRoleInclude();
            var contentRightsCheck = CheckContentAreaRights(session, item, accessType, 4);
            if (!contentRightsCheck.Success)
            {
                return new RequestResult<T>().FillFromRequestResult(contentRightsCheck);
            }

            if (item.Id != 0)
            {
                return new RequestResult<T>().SetError(400, "Id должен быть нулевым");
            }
            else if (!item.IsValid())
            {
                return new RequestResult<T>().SetError(400, "Некорректно заполнены все необходимые поля. Сверьтесь с документацией и попробуйте еще раз");
            }
            else if (!DB.Languages.Any(o => o.Id == item.MainLanguageId && !o.IsDeleted))
            {
                return new RequestResult<T>().SetError(404, "Языка с данным id не существует");
            }

            return new RequestResult<T>().SetSuccess(item);
        }
        #endregion

        #region Обобщенные методы редактирования объекта


        protected RequestResult<T> CheckMainModelBeforeUpdate<T>(IQueryable<T> dbSet, 
                                                                 EditModel<T> model, 
                                                                 ContentAccessModelType accessType) where T : AvailabilityModel
        {

            var item = dbSet.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            if (item == null)
            {
                return new RequestResult<T>().SetError(404, "Запись по данному id не найдена");
            }

            var session = GetSessionWithRoleInclude();
            var contentRightsCheck = CheckContentAreaRights(session, item, accessType, 2);
            if (!contentRightsCheck.Success)
            {
                return new RequestResult<T>().FillFromRequestResult(contentRightsCheck);
            }


            if (model.IsValid())
            {
                return new RequestResult<T>().SetError(400, "Не заполнены все необходимые поля. Сверьтесь с документацией и попробуйте еще раз");
            }
            

            return new RequestResult<T>().SetSuccess(item);
        }
        protected RequestResult CheckLocalizationModelBeforeUpdate<T>(IQueryable<T> dbSet,
                                                                     LocalizationEditModel model, 
                                                                     int mainEntityId, 
                                                                     ContentAccessModelType accessType) where T: AvailabilityModel
        {
            var category = dbSet.FirstOrDefault(o => o.Id == mainEntityId && !o.IsDeleted);
            if (category == null)
            {
                return new RequestResult().SetError(400, "Внутренняя ошибка");
            }


            var session = GetSessionWithRoleInclude();
            var contentRightsCheck = CheckContentAreaRights(session, category, accessType, 3);
            if (!contentRightsCheck.Success)
            {
                return new RequestResult().FillFromRequestResult(contentRightsCheck);
            }


            if (!model.IsValid())
            {
                return new RequestResult().SetError(400, "Не заполнены все необходимые поля. Сверьтесь с документацией и попробуйте еще раз");
            }

            return new RequestResult().SetSuccess();
        }



        protected RequestResult<T> UpdateModel<T>(DbSet<T> dbSet, EditModel<T> model,T item) where T : AvailabilityModel
        {
            model.Fill(item);

            dbSet.Update(item);
            DB.SaveChanges();

            return new RequestResult<T>().SetSuccess(item);
        }
        protected RequestResult<T> UpdateModel<T>(DbSet<T> dbSet, LocalizationEditModel<T> model, T item) where T: AbsModel
        {
            model.Fill(item);

            dbSet.Update(item);
            DB.SaveChanges();

            return new RequestResult<T>().SetSuccess(item);
        }


        #endregion

        #region Обобщенные методы удаления объекта
        protected RequestResult TryDelete<T>(DbSet<T> dbSet, T item, ContentAccessModelType accessType) where T : AvailabilityModel
        {
            var res = new RequestResult();

            var session = GetSessionWithRoleInclude();
            var contentRightsCheck = CheckContentAreaRights(session, item, accessType, 5);
            res.FillFromRequestResult(contentRightsCheck);

            if (contentRightsCheck.Success)
            {
                item.IsDeleted = true;

                dbSet.Update(item);
                DB.SaveChanges();

                res.Success = true;
            }


            return res;
        }

        protected RequestResult CheckLocalizationModelBeforeDelete<T>(IQueryable<T> mainEntityDbSet,
                                                                     int mainEntityId,
                                                                     ContentAccessModelType accessType) where T : AvailabilityModel
        {
            var mainModel = mainEntityDbSet.FirstOrDefault(o => o.Id == mainEntityId && !o.IsDeleted);
            if (mainModel == null)
            {
                return new RequestResult().SetError(400, "Внутренняя ошибка");
            }


            var session = GetSessionWithRoleInclude();
            var contentRightsCheck = CheckContentAreaRights(session, mainModel, accessType, 5);
            if (!contentRightsCheck.Success)
            {
                return new RequestResult().FillFromRequestResult(contentRightsCheck);
            }

            return new RequestResult().SetSuccess();
        }


        protected RequestResult<T> DeleteModel<T>(DbSet<T> dbSet,T item,bool softDelete = true) where T : AbsModel
        {
            if (softDelete)
            {
                item.IsDeleted = true;
                dbSet.Update(item);       
            }
            else
            {
                dbSet.Remove(item);
            }

            DB.SaveChanges();
            return new RequestResult<T>().SetSuccess(item);
        }

        #endregion


    }
}

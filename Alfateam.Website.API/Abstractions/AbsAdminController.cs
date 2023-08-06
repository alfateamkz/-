using Alfateam.DB;
using Alfateam.Website.API.Models.Core;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Abstractions.Interfaces;
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






        #region Обобщенные методы создания объекта
        protected RequestResult<T> TryCreate<T>(DbSet<T> dbSet,T item) where T : AvailabilityModel, IValidatableModel
        {
            var res = CheckBaseBeforeCreate(item);
            if (!res.Success)
            {
                return res;
            }

            dbSet.Add(item);
            DB.SaveChanges();

            return res.SetSuccess(item);
        }
        protected RequestResult<T> TryCreate<T>(DbSet<T> dbSet, T item,Func<RequestResult> callback) where T : AvailabilityModel, IValidatableModel
        {
            var res = CheckBaseBeforeCreate(item);
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
        protected async Task<RequestResult<T>> TryCreate<T>(DbSet<T> dbSet, T item, Func<Task<RequestResult>> callback) where T : AvailabilityModel, IValidatableModel
        {
            var res = CheckBaseBeforeCreate(item);
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
        private RequestResult<T> CheckBaseBeforeCreate<T>(T item) where T : AvailabilityModel, IValidatableModel
        {

            var session = GetSessionWithRoleInclude();
            var contentRightsCheck = CheckContentAreaRights(session, item, ContentAccessModelType.Posts, 4);
            if (!contentRightsCheck.Success)
            {
                return new RequestResult<T>().FillFromRequestResult(contentRightsCheck);
            }


            if (!item.IsValid())
            {
                return new RequestResult<T>().SetError(400, "Не заполнены все необходимые поля. Сверьтесь с документацией и попробуйте еще раз");
            }
            else if (!DB.Languages.Any(o => o.Id == item.MainLanguageId && !o.IsDeleted))
            {
                return new RequestResult<T>().SetError(404, "Языка с данным id не существует");
            }

            return new RequestResult<T>().SetSuccess(item);
        }
        #endregion

        #region Обобщенные методы редактирования объекта


        protected RequestResult<T> CheckMainModelBeforeUpdate<T>(DbSet<T> dbSet, EditModel<T> model) where T : AvailabilityModel, IValidatableModel
        {

            var item = dbSet.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            if (item == null)
            {
                return new RequestResult<T>().SetError(404, "Запись по данному id не найдена");
            }

            var session = GetSessionWithRoleInclude();
            var contentRightsCheck = CheckContentAreaRights(session, item, ContentAccessModelType.Posts, 2);
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
        protected RequestResult CheckLocalizationModelBeforeUpdate<T>(IQueryable<T> dbSet, LocalizationEditModel model,  int mainEntityId) where T: AvailabilityModel
        {
            var category = dbSet.FirstOrDefault(o => o.Id == mainEntityId && !o.IsDeleted);
            if (category == null)
            {
                return new RequestResult().SetError(400, "Внутренняя ошибка");
            }


            var session = GetSessionWithRoleInclude();
            var contentRightsCheck = CheckContentAreaRights(session, category, ContentAccessModelType.Posts, 3);
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



        protected RequestResult<T> UpdateModel<T>(DbSet<T> dbSet, EditModel<T> model,T item) where T : AvailabilityModel, IValidatableModel
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
        protected RequestResult TryDelete<T>(DbSet<T> dbSet, T item) where T : AvailabilityModel
        {
            var res = new RequestResult();

            var session = GetSessionWithRoleInclude();
            var contentRightsCheck = CheckContentAreaRights(session, item, ContentAccessModelType.Posts, 5);
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
        #endregion


    }
}

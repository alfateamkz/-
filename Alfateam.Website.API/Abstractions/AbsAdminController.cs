using Alfateam.DB;
using Alfateam.Website.API.Enums;
using Alfateam.Website.API.Filters;
using Alfateam.Website.API.Models.ClientModels.Posts;
using Alfateam.Website.API.Models.Core;
using Alfateam.Website.API.Models.EditModels.General;
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
    [AdminActionsFilter]
    public abstract class AbsAdminController : AbsController
    {
        protected AbsAdminController(WebsiteDBContext db, IWebHostEnvironment appEnv) : base(db, appEnv)
        {
            
        }

        //TODO: В будущем: таблица файлов, удаление невостребованных(например файл был загружен на сервер, но дальше вышла ошибка и по факту моделька не сохранилась)

        
        public Session GetSessionWithRoleInclude()
        {
            var session = DB.Sessions.Include(o => o.User).ThenInclude(o => o.RoleModel).ThenInclude(o => o.AvailableCountries)
                                     .Include(o => o.User).ThenInclude(o => o.RoleModel).ThenInclude(o => o.ForbiddenCountries)
                                     .Include(o => o.User).ThenInclude(o => o.RoleModel).ThenInclude(o => o.ContentAccessTypes)
                                     .Include(o => o.User).ThenInclude(o => o.RoleModel).ThenInclude(o => o.ReviewsAccess)
                                     .Include(o => o.User).ThenInclude(o => o.RoleModel).ThenInclude(o => o.HRAccess)
                                     .Include(o => o.User).ThenInclude(o => o.RoleModel).ThenInclude(o => o.ShopAccess)
                                     .Include(o => o.User).ThenInclude(o => o.RoleModel).ThenInclude(o => o.OutstaffAccess)
                                     .Include(o => o.User).ThenInclude(o => o.BanInfo)
                                     .FirstOrDefault(o => o.SessID == this.UserSessid);
            return session;
        }


        //TODO: Сделать метод UpdateContentMedia и применить его по проекту

        protected async Task<RequestResult> UpdateContentMedia(Content oldContent,Content newContent)
        {
          
            throw new NotImplementedException();
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
        protected PricingMatrix CreateDefaultPricingMatrix()
        {
            var matrix = new PricingMatrix();

            foreach (var country in DB.Countries.Include(o => o.Currencies).Where(o => !o.IsDeleted))
            {
                var countryItem = new PricingMatrixItem();
                countryItem.CountryId = country.Id;
     
                foreach (var currency in country.Currencies)
                {
                    countryItem.Costs.Add(new Cost
                    {
                        CurrencyId = currency.Id,
                        Value = 0.00,
                    });
                }
                matrix.Costs.Add(countryItem);
            }


            var otherCountriesItem = new PricingMatrixItem();
            otherCountriesItem.CountryId = null;
            otherCountriesItem.Costs.Add(new Cost
            {
                CurrencyId = DB.Currencies.FirstOrDefault(o => o.Code == "USD").Id,
                Value = 0.00,
            });


            return matrix;
        }
   

        #region Проверка прав

    
        protected RequestResult CheckBaseRights(Session session, AvailabilityModel model)
        {
            return TryFinishAllRequestes(new[]
            {
               () => CheckSession(session),
               () => RequestResult.FromBoolean(CheckBasePermissions(session.User, model), 403, "У данного пользователя нет доступа к записи"),
            });
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




        protected bool IsInAdminRole(User user)
        {
            return user.RoleModel.Role != UserRole.User;
        }
        protected bool CheckBasePermissions(User user, AvailabilityModel model)
        {
            if (user == null) return false;
            if (user.RoleModel.Role == UserRole.Owner) return true;
            if (!IsInAdminRole(user)) return false;

            var allCountries = DB.Countries.Where(o => !o.IsDeleted).ToList();
            var availableModelCountries = model.Availability.GetAvailableCountries(allCountries);
            var availableUserCountries = user.RoleModel.GetAvailableCountries(allCountries);

            return availableModelCountries.Intersect(availableUserCountries).Any();
        }



        private RequestResult SetCheckContentAreaRights(Session session, ContentAccessModelType type, int requiredLevel)
        {
            var res = new RequestResult();

            if (session.User.RoleModel.Role == UserRole.User)
            {
                return res.SetError(403, "У пользователя нет доступа в администраторскую часть");
            }
            if(session.User.RoleModel.Role == UserRole.Owner 
                || session.User.RoleModel.Role == UserRole.LocalDirector)
            {
                return res.SetSuccess();
            }


            var userAccess = session.User.RoleModel.GetContentAccess(type);
            if (userAccess == null)
            {
                userAccess = session.User.RoleModel.GetContentAccess(ContentAccessModelType.All);
                if (userAccess == null)
                {
                    return res.SetError(403, "У пользователя нет прав на данный раздел");
                }
            }


            if (userAccess.AccessLevel < requiredLevel)
            {
                switch (requiredLevel)
                {
                    case 1:
                        return res.SetError(403, "У пользователя нет прав на просмотр записей");
                    case 2:
                        return res.SetError(403, "У пользователя нет прав на редактирование записей");
                    case 3:
                        return res.SetError(403, "У пользователя нет прав на редактирование локализаций записей");
                    case 4:
                        return res.SetError(403, "У пользователя нет прав на создание новых записей");
                    case 5:
                        return res.SetError(403, "У пользователя нет прав на удаление записей");
                }
            }

            return res.SetSuccess();
        }




        #endregion

        #region Availability 
        protected IEnumerable<AvailabilityModel> GetAvailableModels(User user, IEnumerable<AvailabilityModel> allModels)
        {
            var allowedModels = new List<AvailabilityModel>();

            if (user.RoleModel.Role == UserRole.Owner)
            {
                return allModels.ToList();
            }

            var allCountries = DB.Countries.Where(o => !o.IsDeleted).ToList();
            var availableUserCountries = user.RoleModel.GetAvailableCountries(allCountries);

            foreach (var model in allModels)
            {
                var availableModelCountries = model.Availability.GetAvailableCountries(allCountries);

                bool isAvailable = availableModelCountries.Intersect(availableUserCountries).Any();
                if (isAvailable)
                {
                    allowedModels.Add(model);
                }
            }
            return allowedModels;
        }
        protected IEnumerable<AvailabilityModel> GetAvailableModels(User user, IEnumerable<AvailabilityModel> allModels, int offset, int count)
        {
            return GetAvailableModels(user, allModels).Skip(offset).Take(count);
        }


        protected RequestResult CanSetAvailabilityCountries(User user, Availability availability)
        {
            var allCountries = DB.Countries.Where(o => !o.IsDeleted).ToList();
            var session = GetSessionWithRoleInclude();


            var userAvailableCountries = user.RoleModel.GetAvailableCountries(allCountries);
            var availabilityAllowedCountries = availability.GetAvailableCountries(allCountries);

            if (!availabilityAllowedCountries.Any())
            {
                return RequestResult.AsError(400, "Не указано ни одной доступной страны в модели доступности");
            }


            bool success = true;
            string errorText = "Страны, указанные в модели доступности недоступны для данного пользователя: \r\n";
            foreach (var country in availabilityAllowedCountries)
            {
                if (!userAvailableCountries.Any(o => o.Id == country.Id))
                {
                    success = false;
                    errorText += $"{country.Title} \r\n";
                }
            }

            if (!success)
            {
                return RequestResult.AsError(403, errorText);
            }

            return RequestResult.AsSuccess();
        }
        protected RequestResult<Availability> TryUpdateAvailability(AvailabilityEditModel model, ContentAccessModelType accessType)
        {
            var availability = DB.GetIncludedAvailability(model.Id);
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<Availability>(new[]
            {
                () => RequestResult.FromBoolean(availability != null, 404, "Запись по данному id не найдена"),
                () => CheckContentAreaRights(session, accessType, 2),
                () => CanSetAvailabilityCountries(session.User, availability),
                () => UpdateModel(DB.Availabilities, model, availability)
            });
        }
     
        #endregion




        #region Обобщенные методы получения объектов
        protected RequestResult<IEnumerable<T>> TryGetMany<T>(IEnumerable<T> fromModels, ContentAccessModelType accessType, int offset,int count = 20) where T : AvailabilityModel
        {
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<IEnumerable<T>>(new[]
            {
                () => CheckContentAreaRights(session, accessType, 1),
                () =>
                {
                   var availableModels = this.GetAvailableModels(session.User, fromModels, offset, count);
                   return RequestResult<IEnumerable<T>>.AsSuccess(availableModels.Cast<T>());
                }
            });
        }
        protected RequestResult<T> TryGetOne<T>(IEnumerable<T> fromModels, int id, ContentAccessModelType accessType) where T: AvailabilityModel
        {
            var item = fromModels.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes<T>(new[]
            {
                () => RequestResult.FromBoolean(item != null,404, "Запись по данному id не найдена"),
                () => CheckContentAreaRights(GetSessionWithRoleInclude(), item, accessType, 1),
                () => RequestResult<T>.AsSuccess(item)
            });
        }
        protected RequestResult<T> TryGetOne<T>(IEnumerable<T> fromModels, int id) where T : AbsModel
        {
            var item = fromModels.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (item == null)
            {
                return RequestResult<T>.AsError(404, "Запись по данному id не найдена");
            }
            return RequestResult<T>.AsSuccess(item);
        }
        #endregion

        #region Обобщенные методы создания объекта
        protected RequestResult<T> TryCreate<T>(DbSet<T> dbSet,T item, ContentAccessModelType accessType) where T : AvailabilityModel
        {
            return TryFinishAllRequestes<T>(new[]
            {
                () => CheckBaseBeforeCreate(item, accessType),
                () => CreateModel(dbSet,item)
            });
        }
        protected RequestResult<T> TryCreate<T>(DbSet<T> dbSet, T item, ContentAccessModelType accessType, Func<RequestResult> callback) where T : AvailabilityModel
        {
           return TryFinishAllRequestes<T>(new[]
           {
                () => CheckBaseBeforeCreate(item, accessType),
                () => callback.Invoke(),
                () => CreateModel(dbSet,item)
            });
        }
        protected async Task<RequestResult<T>> TryCreate<T>(DbSet<T> dbSet, T item, ContentAccessModelType accessType, Func<Task<RequestResult>> callback) where T : AvailabilityModel
        {
            return TryFinishAllRequestes<T>(new[]
            {
                () => CheckBaseBeforeCreate(item, accessType),
                () => callback.Invoke().Result,
                () => CreateModel(dbSet,item)
            });
        }





        protected RequestResult CheckLocalizationModelBeforeCreate<T>(LocalizableModel model,T mainEntity,ContentAccessModelType accessType) where T : AvailabilityModel
        {
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<T>(new[]
            {
                () => RequestResult.FromBoolean(mainEntity != null, 400, "Внутренняя ошибка"),
                () => CheckContentAreaRights(session, mainEntity, accessType, 3),
                () => RequestResult.FromBoolean(model.IsValid(), 400, "Некорректно заполнены все необходимые поля. Сверьтесь с документацией и попробуйте еще раз")
            });
        }



        private RequestResult<T> CheckBaseBeforeCreate<T>(T item, ContentAccessModelType accessType) where T : AvailabilityModel
        {
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<T>(new[]
            {
                () => CheckContentAreaRights(session, item, accessType, 4),
                () => CanSetAvailabilityCountries(session.User, item.Availability),
                () => CheckBasePropsBeforeCreate(item)
            });
        }
        protected RequestResult<T> CheckBasePropsBeforeCreate<T>(T item) where T : AbsModel
        {
            return TryFinishAllRequestes<T>(new[]
            {
                () => RequestResult.FromBoolean(item.Id == 0, 400, "Id должен быть нулевым"),
                () => RequestResult.FromBoolean(item.IsValid(), 400, "Некорректно заполнены все необходимые поля. Сверьтесь с документацией и попробуйте еще раз"),
                () =>
                {
                   var mainLangIdProp = item.GetType().GetProperties().FirstOrDefault(o => o.Name == "MainLanguageId");
                   if(mainLangIdProp != null)
                   {
                       var mainLanguageId = (int)mainLangIdProp.GetValue(item);
                       if (!DB.Languages.Any(o => o.Id == mainLanguageId && !o.IsDeleted))
                       {
                           return new RequestResult<T>().SetError(404, "Языка с данным id не существует");
                       }
                   }
                   return RequestResult<T>.AsSuccess(item);
                }
            });
        }


        protected RequestResult<T> CreateModel<T>(DbSet<T> dbSet, T item) where T : AbsModel
        {
            dbSet.Add(item);
            DB.SaveChanges();
            return RequestResult<T>.AsSuccess(item);
        }
        #endregion

        #region Обобщенные методы редактирования объекта

        protected RequestResult<T> CheckMainModelBeforeUpdate<T>(T model,EditModel<T> editModel,ContentAccessModelType accessType) where T : AvailabilityModel
        {
            return TryFinishAllRequestes<T>(new[]
            {
                () => RequestResult.FromBoolean(model != null, 400, "Запись по данному id не найдена"),
                () => CheckContentAreaRights(GetSessionWithRoleInclude(), model, accessType, 3),
                () => RequestResult.FromBoolean(editModel.IsValid(), 400, "Некорректно заполнены все необходимые поля. Сверьтесь с документацией и попробуйте еще раз")
            });
        }
        protected RequestResult<T> CheckMainModelBeforeUpdate<T>(IQueryable<T> dbSet, EditModel<T> model, ContentAccessModelType accessType) where T : AvailabilityModel
        {

            var item = dbSet.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return TryFinishAllRequestes<T>(new[]
            {
                () => RequestResult.FromBoolean(item != null, 400, "Запись по данному id не найдена"),
                () => CheckContentAreaRights(GetSessionWithRoleInclude(), item, accessType, 3),
                () => RequestResult.FromBoolean(model.IsValid(), 400, "Некорректно заполнены все необходимые поля. Сверьтесь с документацией и попробуйте еще раз")
            });
        }
        protected RequestResult CheckLocalizationModelBeforeUpdate<T>(IQueryable<T> dbSet, LocalizationEditModel model, int mainEntityId, ContentAccessModelType accessType) where T: AvailabilityModel
        {
            var category = dbSet.FirstOrDefault(o => o.Id == mainEntityId && !o.IsDeleted);
            return TryFinishAllRequestes<T>(new[]
            {
                () => RequestResult.FromBoolean(category != null, 400, "Внутренняя ошибка"),
                () => CheckContentAreaRights(GetSessionWithRoleInclude(), category, accessType, 3),
                () => RequestResult.FromBoolean(model.IsValid(), 400, "Некорректно заполнены все необходимые поля. Сверьтесь с документацией и попробуйте еще раз")
            });
        }



        protected RequestResult<T> UpdateModel<T>(DbSet<T> dbSet, EditModel<T> model,T item) where T : AbsModel
        {
            model.Fill(item);
            return UpdateModel(dbSet, item);
        }
        protected RequestResult<T> UpdateModel<T>(DbSet<T> dbSet, LocalizationEditModel<T> model, T item) where T: AbsModel
        {
            model.Fill(item);
            return UpdateModel(dbSet, item);
        }
        protected RequestResult<T> UpdateModel<T>(DbSet<T> dbSet, T item) where T : AbsModel
        {
            dbSet.Update(item);
            DB.SaveChanges();

            return new RequestResult<T>().SetSuccess(item);
        }


 


        #endregion

        #region Обобщенные методы удаления объекта
        protected RequestResult TryDelete<T>(DbSet<T> dbSet, T item, ContentAccessModelType accessType,bool softDelete = true) where T : AvailabilityModel
        {
           return TryFinishAllRequestes<T>(new[]
           {
                () => CheckContentAreaRights(GetSessionWithRoleInclude(), item, accessType, 5),
                () => DeleteModel(dbSet, item, softDelete)
           });
        }

        protected RequestResult CheckLocalizationModelBeforeDelete<T>(IQueryable<T> mainEntityDbSet,int mainEntityId,ContentAccessModelType accessType) where T : AvailabilityModel
        {
           var mainModel = mainEntityDbSet.FirstOrDefault(o => o.Id == mainEntityId && !o.IsDeleted);
           return TryFinishAllRequestes<T>(new[]
           {
               () => RequestResult.FromBoolean(mainModel != null, 400, "Внутренняя ошибка"),
               () => CheckContentAreaRights(GetSessionWithRoleInclude(), mainModel, accessType, 5),
           });
        }

        protected RequestResult CheckLocalizationBeforeDelete<T>(IQueryable<T> mainEntityDbSet,int mainEntityId, ContentAccessModelType accessType) where T : AbsModel
        {
            var mainModel = mainEntityDbSet.FirstOrDefault(o => o.Id == mainEntityId && !o.IsDeleted);
            return TryFinishAllRequestes<T>(new[]
            {
               () => RequestResult.FromBoolean(mainModel != null, 400, "Внутренняя ошибка"),
               () => CheckContentAreaRights(GetSessionWithRoleInclude(), accessType, 5),
            });
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

using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Core;
using Alfateam.Website.API.Exceptions;
using Alfateam.Website.API.Models.DTO.General;
using Alfateam.Website.API.Models.DTOLocalization.Events;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.General;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Website.API.Services
{
    public class DBService
    {
        public readonly WebsiteDBContext DB;
        public DBService(WebsiteDBContext db)
        {
            DB = db;
        }


        #region Get

        public IEnumerable<AvailabilityModel> GetAvailableModels(User user, IEnumerable<AvailabilityModel> allModels)
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
        public IEnumerable<AvailabilityModel> GetAvailableModels(User user, IEnumerable<AvailabilityModel> allModels, int offset, int count)
        {
            return GetAvailableModels(user, allModels).Skip(offset).Take(count);
        }


        public DTOModel<T> GetLocalizationModel<T>(T localization, AbsModel mainEntity, LocalizationDTOModel<T> newDTO) where T: LocalizableModel, new()
        {
            if (localization == null)
            {
                throw new Exception404("Сущность с данным id не найдена");
            }


            if (mainEntity == null)
            {
                throw new Exception500("Внутренняя ошибка");
            }

            return newDTO.CreateDTO(localization);
        }
 
        
        
        public DTOModel<T> TryGetOne<T>(IEnumerable<T> fromModels, int id, DTOModel<T> dTOModel) where T : AbsModel, new()
        {
            var dbModel = TryGetOne(fromModels, id);
            return dTOModel.CreateDTO(dbModel);
        }
        public T TryGetOne<T>(IEnumerable<T> fromModels, int id) where T : AbsModel, new()
        {
            var item = fromModels.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (item is null)
            {
                throw new Exception404("Запись по данному id не найдена");
            }

            return item;
        }

        #endregion

        #region Create

        public DTOModel<T> TryCreateEntity<T>(DbSet<T> dbSet,
                                              DTOModel<T> model,
                                              Action<T> callback = null) where T : AbsModel, new()
        {
            ValidateToCreateEntity(model);


            var dbModel = new T();
            model.FillDBModel(dbModel, DBModelFillMode.Create);

            callback?.Invoke(dbModel);

            dbSet.Add(dbModel);
            DB.SaveChanges();

            model.Id = dbModel.Id;
            return model;
        }

        public DTOModel<T> TryCreateAvailabilityEntity<T>(DbSet<T> dbSet,
                                                         AvailabilityDTOModel<T> model,
                                                         Session session,
                                                         Action<T> callback = null) where T : AvailabilityModel, new()
        {
            ValidateAvailabilityModel(session, model.Availability.CreateDBModelFromDTO());
            ValidateToCreateEntity(model);


            var dbModel = new T();
            model.FillDBModel(dbModel, DBModelFillMode.Create);

            callback?.Invoke(dbModel);

            dbSet.Add(dbModel);
            DB.SaveChanges();

            model.Id = dbModel.Id;
            return model;
        }



        public DTOModel<L> TryCreateLocalizationEntity<P, L>(DbSet<P> parentEntityDbSet, 
                                                             P parentEntity, 
                                                             DTOModel<L> model,
                                                             Action<L> callback = null) where P : AbsModel, new() 
                                                                                where L : LocalizableModel, new()
        {
            ValidateLocalizationModelToCreate(model, parentEntity);


            //Находим свойство Localizations и добавляем новую сущность
            var localizationsProp = parentEntity.GetType().GetProperties().FirstOrDefault(o => o.Name == "Localizations");
            var localizationsPropValue = localizationsProp.GetValue(parentEntity);


            var dbLocalizationModel = model.CreateDBModelFromDTO();
            callback?.Invoke(dbLocalizationModel);

            var addMethod = localizationsProp.PropertyType.GetMethod("Add");
            addMethod.Invoke(localizationsPropValue, new[] { dbLocalizationModel });


            UpdateEntity(parentEntityDbSet, parentEntity);

            return model;
        }






        public T CreateEntity<T>(DbSet<T> dbSet, T item) where T : AbsModel, new()
        {
            dbSet.Add(item);
            DB.SaveChanges();

            return item;
        }
        public T CreateEntity<T>(DbSet<T> dbSet, DTOModel<T> model) where T : AbsModel, new()
        {
            var item = new T();
            model.FillDBModel(item, DBModelFillMode.Create);

            dbSet.Add(item);
            DB.SaveChanges();

            return item;
        }



        #region Private methods

        private void CanSetAvailabilityCountries(Session session, Availability availability)
        {
            var allCountries = DB.Countries.Where(o => !o.IsDeleted).ToList();

            var userAvailableCountries = session.User.RoleModel.GetAvailableCountries(allCountries);
            var availabilityAllowedCountries = availability.GetAvailableCountries(allCountries);

            if (!availabilityAllowedCountries.Any())
            {
                throw new Exception400("Не указано ни одной доступной страны в модели доступности");
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
                throw new Exception403(errorText);
            }
        }
        private void ValidateAvailabilityModel(Session session, Availability availability)
        {
            var allCountries = DB.Countries.Where(o => !o.IsDeleted).ToList();

            var userAvailableCountries = session.User.RoleModel.GetAvailableCountries(allCountries);
            var availabilityAllowedCountries = availability.GetAvailableCountries(allCountries);

            if (!availabilityAllowedCountries.Any())
            {
                throw new Exception400("Не указано ни одной доступной страны в модели доступности. Либо укажите страны, либо отметьте, что доступно для всех стран");
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
                throw new Exception403(errorText);
            }
        }
        private void ValidateToCreateEntity<T>(DTOModel<T> item) where T : AbsModel, new()
        {
            if (item.Id != 0)
            {
                throw new Exception400("Id должен быть нулевым");
            }
            if (!item.IsValid())
            {
                throw new Exception400("Некорректно заполнены все необходимые поля. Сверьтесь с документацией и попробуйте еще раз");
            }

            var mainLangIdProp = item.GetType().GetProperties().FirstOrDefault(o => o.Name == "MainLanguageId");
            if (mainLangIdProp != null)
            {
                var mainLanguageId = (int)mainLangIdProp.GetValue(item);
                if (!DB.Languages.Any(o => o.Id == mainLanguageId && !o.IsDeleted))
                {
                    throw new Exception404("Языка с данным id не существует");
                }
            }
        }



        private void ValidateLocalizationModelToCreate<T>(DTOModel model, T mainEntity) where T : AbsModel
        {
            if (mainEntity == null)
            {
                throw new Exception400("Внутренняя ошибка");
            }
            if (!model.IsValid())
            {
                throw new Exception400("Некорректно заполнены все необходимые поля. Сверьтесь с документацией и попробуйте еще раз");
            }
        }



        #endregion

        #endregion

        #region Update


        public DTOModel<T> TryUpdateEntity<T>(DbSet<T> dbSet, 
                                              DTOModel<T> model, 
                                              T item, 
                                              Action<T> callback = null) where T : AbsModel, new()
        {
            if (item == null)
            {
                throw new Exception404("Запись по данному id не найдена");
            }

            if (!model.IsValid())
            {
                throw new Exception400("Некорректно заполнены все необходимые поля. Сверьтесь с документацией и попробуйте еще раз");
            }

            var mainLangProp = model.GetType().GetProperties().FirstOrDefault(o => o.Name == "MainLanguageId");
            if(mainLangProp != null)
            {
                var mainLangId = (int)mainLangProp.GetValue(model);
                if (!DB.Languages.Any(o => o.Id == mainLangId && !o.IsDeleted))
                {
                    throw new Exception404("Языка с данным id не существует");
                }
            }

            callback?.Invoke(item);

            UpdateEntity(dbSet, model, item);
            return model;
        }
        public DTOModel<T> TryUpdateLocalizationEntity<T>(DbSet<T> localizationsDbSet, 
                                                         T localizationEntity, 
                                                         DTOModel<T> model, 
                                                         AbsModel parentEntity,
                                                         Action<T> callback = null) where T : AbsModel, new()
        {
            if (localizationEntity is null)
            {
                throw new Exception404("Локализация с данным id не найдена");
            }

            if (parentEntity == null)
            {
                throw new Exception400("Внутренняя ошибка");
            }

            if (!model.IsValid())
            {
                throw new Exception400("Некорректно заполнены все необходимые поля. Сверьтесь с документацией и попробуйте еще раз");
            }

            callback?.Invoke(localizationEntity);

            UpdateEntity(localizationsDbSet, model, localizationEntity);
            return model;
        }
        public AvailabilityDTO TryUpdateAvailability(AvailabilityDTO model, Session session)
        {
            var availability = DB.Availabilities.FirstOrDefault(o => o.Id == model.Id);
            model.FillDBModel(availability, DBModelFillMode.Update);

            return (AvailabilityDTO)TryUpdateEntity(DB.Availabilities, model, availability, (entity) =>
            {
                CanSetAvailabilityCountries(session, availability);
            });
        }



        public T UpdateEntity<T>(DbSet<T> dbSet, DTOModel<T> model, T item) where T : AbsModel, new()
        {
            model.FillDBModel(item, DBModelFillMode.Update);

            dbSet.Update(item);
            DB.SaveChanges();

            model.CreateDTO(item);
            return item;
        }
        public void UpdateEntity<T>(DbSet<T> dbSet, T item) where T : AbsModel
        {
            dbSet.Update(item);
            DB.SaveChanges();
        }

        #endregion

        #region Delete
        public void TryDeleteEntity<T>(DbSet<T> dbSet, T item, bool softDelete = true) where T : AbsModel
        {
            if (item == null)
            {
                throw new Exception404("Сущность по данному id не найдена");
            }
            DeleteEntity(dbSet, item, softDelete);
        }
        public void TryDeleteLocalizationEntity<T>(DbSet<T> localizationsDbSet, T localizationEntity, AbsModel parentEntity) where T : LocalizableModel
        {
            if (parentEntity == null)
            {
                throw new Exception400("Внутренняя ошибка");
            }

            TryDeleteEntity(localizationsDbSet, localizationEntity);
        }
        public void DeleteEntity<T>(DbSet<T> dbSet, T item, bool softDelete = true) where T : AbsModel
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
        }


        #endregion

    }

}

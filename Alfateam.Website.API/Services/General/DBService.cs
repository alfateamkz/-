using Alfateam.Core;
using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Core;
using Alfateam.Core.Exceptions;
using Alfateam.Website.API.Models.DTO.General;
using Alfateam.Website.API.Models.DTOLocalization.Events;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.General;
using Microsoft.EntityFrameworkCore;
using Alfateam.Core.Services;

namespace Alfateam.Website.API.Services.General
{
    public class DBService : AbsDBService
    {
        public readonly WebsiteDBContext DB;
        public DBService(WebsiteDBContext db) : base(db)
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


        public DTOModelAbsGeneric<T> GetLocalizationModel<T>(T localization, AbsModel mainEntity, LocalizationDTOModel<T> newDTO) where T : LocalizableModel, new()
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
        public IEnumerable<DTOModelAbsGeneric<T>> GetLocalizationModels<T>(IEnumerable<T> localizations, AbsModel mainEntity, LocalizationDTOModel<T> newDTO) where T : LocalizableModel, new()
        {
            if (mainEntity == null)
            {
                throw new Exception500("Внутренняя ошибка");
            }

            return newDTO.CreateDTOs(localizations);
        }


        #endregion

        #region Create


        public DTOModel<T> TryCreateAvailabilityEntity<T>(DbSet<T> dbSet,
                                                         AvailabilityDTOModel<T> model,
                                                         Session session,
                                                         Action<T> callback = null) where T : AvailabilityModel, new()
        {
            model.SetDBContext(DB);
            ValidateAvailabilityModel(session, model.Availability.CreateDBModelFromDTO());
            ValidateToCreateEntity(model);




            var dbModel = model.CreateDBModelFromDTO();

            callback?.Invoke(dbModel);

            dbSet.Add(dbModel);
            DB.SaveChanges();

            model.Id = dbModel.Id;
            model.CreatedAt = dbModel.CreatedAt;
            return model;
        }



        public DTOModel<L> TryCreateLocalizationEntity<P, L>(DbSet<P> parentEntityDbSet,
                                                             P parentEntity,
                                                             DTOModel<L> model,
                                                             Action<L> callback = null) where P : AbsModel, new()
                                                                                where L : LocalizableModel, new()
        {
            model.SetDBContext(DB);
            ValidateLocalizationModelToCreate(model, parentEntity);



            //Находим свойство Localizations и добавляем новую сущность
            var localizationsProp = parentEntity.GetType().GetProperties().FirstOrDefault(o => o.Name == "Localizations");
            var localizationsPropValue = localizationsProp.GetValue(parentEntity);


            var dbLocalizationModel = model.CreateDBModelFromDTO();
            callback?.Invoke(dbLocalizationModel);

            var addMethod = localizationsProp.PropertyType.GetMethod("Add");
            addMethod.Invoke(localizationsPropValue, new[] { dbLocalizationModel });


            UpdateEntity(parentEntityDbSet, parentEntity);

            model.Id = dbLocalizationModel.Id;
            model.CreatedAt = dbLocalizationModel.CreatedAt;

            return model;
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

        private void ValidateLocalizationModelToCreate<T>(DTOModelAbs model, T mainEntity) where T : AbsModel
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

            model.SetDBContext(DB);
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
            var availability = DB.Availabilities.Include(o => o.AllowedCountries)
                                                .Include(o => o.DisallowedCountries)
                                                .FirstOrDefault(o => o.Id == model.Id);

            availability.AllowedCountries.Clear();
            availability.DisallowedCountries.Clear();

            model.SetDBContext(DB);
            model.FillDBModel(availability, DBModelFillMode.Update);

            return (AvailabilityDTO)TryUpdateEntity(DB.Availabilities, model, availability, (entity) =>
            {
                CanSetAvailabilityCountries(session, availability);
            });
        }


        #endregion

        #region Delete
        public void TryDeleteLocalizationEntity<T>(DbSet<T> localizationsDbSet, T localizationEntity, AbsModel parentEntity) where T : LocalizableModel
        {
            if (parentEntity == null)
            {
                throw new Exception400("Внутренняя ошибка");
            }

            TryDeleteEntity(localizationsDbSet, localizationEntity);
        }

        #endregion


        #region Validate methods
        public override void ValidateToCreateEntity<T>(DTOModelAbsGeneric<T> item)
        {
            base.ValidateToCreateEntity(item);

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
        public override void ValidateToUpdateEntity<T>(T item, DTOModelAbsGeneric<T> model)
        {
            base.ValidateToUpdateEntity(item, model);

            var mainLangProp = model.GetType().GetProperties().FirstOrDefault(o => o.Name == "MainLanguageId");
            if (mainLangProp != null)
            {
                var mainLangId = (int)mainLangProp.GetValue(model);
                if (!DB.Languages.Any(o => o.Id == mainLangId && !o.IsDeleted))
                {
                    throw new Exception404("Языка с данным id не существует");
                }
            }
        }

        #endregion

    }

}

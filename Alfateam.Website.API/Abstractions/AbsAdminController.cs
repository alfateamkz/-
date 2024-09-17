using Alfateam.DB;
using Alfateam.Website.API.Core;
using Alfateam.Website.API.Enums;
using Alfateam.Website.API.Exceptions;
using Alfateam.Website.API.Filters;
using Alfateam.Website.API.Models;
using Alfateam.Website.API.Models.DTO.General;
using Alfateam.Website.API.Results.CRUD;
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
        public AbsAdminController(ControllerParams @params) : base(@params)
        {
        }

        //TODO: Сделать метод UpdateContentMedia и применить его по проекту
        //TODO: В будущем: таблица файлов, удаление невостребованных(например файл был загружен на сервер, но дальше вышла ошибка и по факту моделька не сохранилась)


        public override Session Session => GetSessionWithRoleInclude();

        [NonAction]
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
        protected RequestResult CheckBaseRights(Session session, Availability availability)
        {
            return TryFinishAllRequestes(new[]
            {
               () => CheckSession(session),
               () => RequestResult.FromBoolean(CheckBasePermissions(session.User, availability), 403, "У данного пользователя нет доступа к записи"),
            });
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
        protected bool CheckBasePermissions(User user, Availability availability) 
        {
            if (user == null) return false;
            if (user.RoleModel.Role == UserRole.Owner) return true;
            if (!IsInAdminRole(user)) return false;

            var allCountries = DB.Countries.Where(o => !o.IsDeleted).ToList();
            var availableModelCountries = availability.GetAvailableCountries(allCountries);
            var availableUserCountries = user.RoleModel.GetAvailableCountries(allCountries);

            return availableModelCountries.Intersect(availableUserCountries).Any();
        }



        #endregion



    }
}

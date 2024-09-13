using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Core;
using Alfateam.Website.API.Extensions;
using Alfateam.Website.API.Helpers;
using Alfateam.Website.API.Models.DTO.General;
using Alfateam.Website.API.Models.DTO.Shop;
using Alfateam.Website.API.Models.DTO;
using Alfateam.Website.API.Models.UserModels;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.HR;
using Alfateam2._0.Models.Reviews;
using Alfateam2._0.Models.Roles;
using Alfateam2._0.Models.Shop;
using Alfateam2._0.Models.Shop.Orders;
using Alfateam2._0.Models.Shop.Wishes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Alfateam.Website.API.Controllers.Admin
{
    public class AdminUsersController : AbsAdminController
    {
        public AdminUsersController(WebsiteDBContext db, IWebHostEnvironment appEnv) : base(db, appEnv)
        {
        }



        [HttpGet,Route("GetUsers")]
        public async Task<RequestResult<IEnumerable<UserDTO>>> GetUsers(int offset, int count = 20)
        {
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<IEnumerable<UserDTO>>(new Func<RequestResult>[]
            {
                () => CheckAccess(),
                () => {

                    var users = GetAvailableUsers(GetSessionWithRoleInclude().User,offset,count);
                    var models = UserDTO.CreateItemsWithLocalization(users,LanguageId) as IEnumerable<UserDTO>;
                    return RequestResult<IEnumerable<UserDTO>>.AsSuccess(models);
                }
            });
        }




        [HttpGet, Route("GetUserMainInfo")]
        public async Task<RequestResult<User>> GetUserMainInfo(int id)
        {
            var user = GetUsersList().FirstOrDefault(o => o.Id == id);
            var admin = GetSessionWithRoleInclude()?.User;
            return TryFinishAllRequestes<User>(new Func<RequestResult>[]
            {
                () => CheckAccess(),
                () => RequestResult.FromBoolean(user != null,404,"Сущность по данному id не найдена"),
                () => RequestResult.FromBoolean(GetAvailableUsers(admin).Any(o => o.Id == id), 403, "Нет доступа"),
                () => RequestResult<User>.AsSuccess(user)
             });
        }

        [HttpGet, Route("GetUserBasket")]
        public async Task<RequestResult<ShopOrder>> GetUserBasket(int id)
        {
            var user = DB.Users.Include(o => o.Basket).ThenInclude(o => o.Items).ThenInclude(o => o.Item).ThenInclude(o => o.MainImage)
                               .Include(o => o.Basket).ThenInclude(o => o.Items).ThenInclude(o => o.SelectedModifiers).ThenInclude(o => o.Modifier)
                               .Include(o => o.Basket).ThenInclude(o => o.Items).ThenInclude(o => o.SelectedModifiers).ThenInclude(o => o.SelectedOptions).ThenInclude(o => o.Option)
                               .Include(o => o.Basket).ThenInclude(o => o.Address).ThenInclude(o => o.Country)
                               .Include(o => o.Basket).ThenInclude(o => o.Currency)
                               .Include(o => o.Basket).ThenInclude(o => o.Payments).ThenInclude(o => o.Currency)
                               .Include(o => o.Basket).ThenInclude(o => o.Return)
                               .FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var admin = GetSessionWithRoleInclude()?.User;
            return TryFinishAllRequestes<ShopOrder>(new Func<RequestResult>[]
            {
                () => CheckAccess(),
                () => RequestResult.FromBoolean(user != null,404,"Сущность по данному id не найдена"),
                () => RequestResult.FromBoolean(GetAvailableUsers(admin).Any(o => o.Id == id), 403, "Нет доступа"),
                () => RequestResult<ShopOrder>.AsSuccess(user.Basket)
             });
        }

        [HttpGet, Route("GetUserOrders")]
        public async Task<RequestResult<IEnumerable<ShopOrder>>> GetUserOrders(int id)
        {
            var user = DB.Users.Include(o => o.Orders).ThenInclude(o => o.Items).ThenInclude(o => o.Item).ThenInclude(o => o.MainImage)
                               .Include(o => o.Orders).ThenInclude(o => o.Items).ThenInclude(o => o.SelectedModifiers).ThenInclude(o => o.Modifier)
                               .Include(o => o.Orders).ThenInclude(o => o.Items).ThenInclude(o => o.SelectedModifiers).ThenInclude(o => o.SelectedOptions).ThenInclude(o => o.Option)
                               .Include(o => o.Orders).ThenInclude(o => o.Address).ThenInclude(o => o.Country)
                               .Include(o => o.Orders).ThenInclude(o => o.Currency)
                               .Include(o => o.Orders).ThenInclude(o => o.Payments).ThenInclude(o => o.Currency)
                               .Include(o => o.Orders).ThenInclude(o => o.Return)
                               .FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var admin = GetSessionWithRoleInclude()?.User;
            return TryFinishAllRequestes<IEnumerable<ShopOrder>>(new Func<RequestResult>[]
            {
                () => CheckAccess(),
                () => RequestResult.FromBoolean(user != null,404,"Сущность по данному id не найдена"),
                () => RequestResult.FromBoolean(GetAvailableUsers(admin).Any(o => o.Id == id), 403, "Нет доступа"),
                () => RequestResult<IEnumerable<ShopOrder>>.AsSuccess(user.Orders)
             });
        }
    
        [HttpGet, Route("GetUserWishlist")]
        public async Task<RequestResult<ShopWishlist>> GetUserWishlist(int id)
        {
            var user = DB.Users.Include(o => o.Wishlist).ThenInclude(o => o.Items).ThenInclude(o => o.Product).ThenInclude(o => o.MainImage)
                               .Include(o => o.Wishlist).ThenInclude(o => o.Items).ThenInclude(o => o.Product).ThenInclude(o => o.Localizations)
                               .Include(o => o.Wishlist).ThenInclude(o => o.Items).ThenInclude(o => o.Product).ThenInclude(o => o.Category).ThenInclude(o => o.Localizations)
                               .Include(o => o.Wishlist).ThenInclude(o => o.Items).ThenInclude(o => o.Product).ThenInclude(o => o.BasePricing).ThenInclude(o => o.Costs).ThenInclude(o => o.Costs).ThenInclude(o => o.Currency)
                               .Include(o => o.Wishlist).ThenInclude(o => o.Items).ThenInclude(o => o.Product).ThenInclude(o => o.BasePricing).ThenInclude(o => o.Costs).ThenInclude(o => o.Country)
                               .FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var admin = GetSessionWithRoleInclude()?.User;
            return TryFinishAllRequestes<ShopWishlist>(new Func<RequestResult>[]
            {
                () => CheckAccess(),
                () => RequestResult.FromBoolean(user != null,404,"Сущность по данному id не найдена"),
                () => RequestResult.FromBoolean(GetAvailableUsers(admin).Any(o => o.Id == id), 403, "Нет доступа"),
                () => RequestResult<ShopWishlist>.AsSuccess(user.Wishlist)
             });
        }

        [HttpGet, Route("GetUserRoleModel")]
        public async Task<RequestResult<UserRoleModel>> GetUserRoleModel(int id)
        {
            var user = DB.Users.Include(o => o.RoleModel).ThenInclude(o => o.AvailableCountries)
                               .Include(o => o.RoleModel).ThenInclude(o => o.ForbiddenCountries)
                               .Include(o => o.RoleModel).ThenInclude(o => o.ContentAccessTypes)
                               .Include(o => o.RoleModel).ThenInclude(o => o.ReviewsAccess)
                               .Include(o => o.RoleModel).ThenInclude(o => o.HRAccess)
                               .Include(o => o.RoleModel).ThenInclude(o => o.ShopAccess)
                               .Include(o => o.RoleModel).ThenInclude(o => o.OutstaffAccess)
                               .FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var admin = GetSessionWithRoleInclude()?.User;
            return TryFinishAllRequestes<UserRoleModel>(new Func<RequestResult>[]
            {
                () => CheckAccess(),
                () => RequestResult.FromBoolean(user != null,404,"Сущность по данному id не найдена"),
                () => RequestResult.FromBoolean(GetAvailableUsers(admin).Any(o => o.Id == id), 403, "Нет доступа"),
                () => RequestResult<UserRoleModel>.AsSuccess(user.RoleModel)
             });
        }

        [HttpGet, Route("GetUserReviews")]
        public async Task<RequestResult<IEnumerable<Review>>> GetUserReviews(int id)
        {
            var user = DB.Users.Include(o => o.Reviews).ThenInclude(o => o.Country)
                               .FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var admin = GetSessionWithRoleInclude()?.User;
            return TryFinishAllRequestes<IEnumerable<Review>>(new Func<RequestResult>[]
            {
                () => CheckAccess(),
                () => RequestResult.FromBoolean(user != null,404,"Сущность по данному id не найдена"),
                () => RequestResult.FromBoolean(GetAvailableUsers(admin).Any(o => o.Id == id), 403, "Нет доступа"),
                () => RequestResult<IEnumerable<Review>>.AsSuccess(user.Reviews)
             });
        }








        [HttpPost, Route("CreateUser")]
        public async Task<RequestResult<User>> CreateUser(User user)
        {

            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<User>(new Func<RequestResult>[]
            {
                () => CheckAccess(),
                () => RequestResult.FromBoolean(user.Id == 0,400,"Невозможно создать пользователя с явно заданным идентификатором"),
                () => RequestResult.FromBoolean(user.RegisteredFromCountryId != null 
                                                  ,400,"Необходимо указать id страны, из которой зарегистрирован пользователь"),
                () => RequestResult.FromBoolean(user.CountryId != null
                                                  ,400,"Необходимо указать id страны, в которой находится пользователь"),
                () => RequestResult.FromBoolean(user.RoleModel != null
                                                  ,400,"Необходимо проинициализировать роли пользователя"),
                () => RequestResult.FromBoolean(user.RoleModel.Role != UserRole.User, 403,"Нельзя создать пользователя - не админа"),
                () => {



                    if(user.RoleModel.Role == UserRole.Owner
                        && session.User.RoleModel.Role != UserRole.Owner)
                    {
                        return RequestResult.AsError(403,"Нельзя назначить роль Owner, не являясь Owner");
                    }


                    user.Wishlist = new ShopWishlist();
                    user.Basket = new ShopOrder();
      
                    if(session.User.RoleModel.Role == UserRole.Owner)
                    {
                        return CreateModel(DB.Users,user);
                    }
                    else if(session.User.RoleModel.Role == UserRole.LocalDirector)
                    {
                        var allCountries = DB.Countries.Where(o => !o.IsDeleted).ToList();
                        var adminAvailableCountries = session.User.RoleModel.GetAvailableCountries(allCountries);



                        var newUserAvailableCountries = user.RoleModel.GetAvailableCountries(allCountries);

                        bool success = true;
                        string errorText = "Данный пользователь не может установить страны: \r\n";

                        foreach(var country in newUserAvailableCountries)
                        {
                            if(!adminAvailableCountries.Any(o => o.Id == country.Id))
                            {
                                errorText += $"{country.Title} \r\n";
                            }
                        }

                        if (!success)
                        {
                            return RequestResult<User>.AsError(403,errorText);
                        }

                        return CreateModel(DB.Users,user);
                    }
                    return RequestResult<User>.AsError(500,"Внутренняя ошибка");
                }
            });
        }






        [HttpPut, Route("UpdateUser")]
        public async Task<RequestResult<User>> UpdateUser(UpdateUserModel model)
        {
            var found = DB.Users.FirstOrDefault(o => o.Id == model.Id);
            var admin = GetSessionWithRoleInclude()?.User;
            return TryFinishAllRequestes<User>(new[]
            {
                () => CheckAccess(),
                () => RequestResult.FromBoolean(found != null,404,"Сущность по данному id не найдена"),
                () => RequestResult.FromBoolean(GetAvailableUsers(admin).Any(o => o.Id == model.Id), 403, "Нет доступа"),
                () => RequestResult.FromBoolean(model.ValidateModel(),400,"Заполните необходимые данные"),
                () =>
                {
                    model.SetData(found);
                    DB.Users.Update(found);
                    DB.SaveChanges();
                    return RequestResult<User>.AsSuccess(found);
                }
            });
        }

        [HttpPut, Route("UpdateUserRoles")]
        public async Task<RequestResult<User>> UpdateUserRoles(UserRoleDTO model)
        {
            var found = DB.Users.Include(o => o.RoleModel).ThenInclude(o => o.AvailableCountries)
                                .Include(o => o.RoleModel).ThenInclude(o => o.ForbiddenCountries)
                                .Include(o => o.RoleModel).ThenInclude(o => o.ContentAccessTypes)
                                .Include(o => o.RoleModel).ThenInclude(o => o.ReviewsAccess)
                                .Include(o => o.RoleModel).ThenInclude(o => o.HRAccess)
                                .Include(o => o.RoleModel).ThenInclude(o => o.ShopAccess)
                                .Include(o => o.RoleModel).ThenInclude(o => o.OutstaffAccess)
                                .FirstOrDefault(o => o.Id == model.Id);
            var admin = GetSessionWithRoleInclude()?.User;

            return TryFinishAllRequestes<User>(new[]
            {
                () => CheckAccess(),
                () => RequestResult.FromBoolean(found != null,404,"Сущность по данному id не найдена"),
                () => RequestResult.FromBoolean(GetAvailableUsers(admin).Any(o => o.Id == model.Id), 403, "Нет доступа"),
                () => RequestResult.FromBoolean(model.IsValid(),400,"Заполните необходимые данные"),
                () =>
                {
                    model.Fill(found.RoleModel, DB.Countries.Where(o => !o.IsDeleted).ToList());
                    DB.Users.Update(found);
                    DB.SaveChanges();
                    return RequestResult<User>.AsSuccess(found);
                }
            });
        }





        [HttpPut, Route("BanUser")]
        public RequestResult BanUser(int id,BanInfo info)
        {
            var found = DB.Users.FirstOrDefault(o => o.Id == id);
            var admin = GetSessionWithRoleInclude()?.User;
            return TryFinishAllRequestes(new[]
            {
                () => CheckAccess(),
                () => RequestResult.FromBoolean(found != null,404,"Сущность по данному id не найдена"),
                () => RequestResult.FromBoolean(GetAvailableUsers(admin).Any(o => o.Id == id), 403, "Нет доступа"),
                () =>
                {
                    found.BanInfo = info;
                    return UpdateModel(DB.Users,found);
                }
            });
        }

        [HttpPut, Route("UnbanUser")]
        public RequestResult UnbanUser(int id)
        {
            var found = DB.Users.FirstOrDefault(o => o.Id == id);
            var admin = GetSessionWithRoleInclude()?.User;
            return TryFinishAllRequestes(new[]
            {
                () => CheckAccess(),
                () => RequestResult.FromBoolean(found != null,404,"Сущность по данному id не найдена"),
                () => RequestResult.FromBoolean(GetAvailableUsers(admin).Any(o => o.Id == id), 403, "Нет доступа"),
                () =>
                {
                    found.BanInfo = null;
                    found.BanInfoId = null;
                    return UpdateModel(DB.Users,found);
                }
            });
        }



        #region Private get available users
        private List<User> GetAvailableUsers(User user, int offset, int count = 20)
        {
            return GetAvailableUsers(user).Skip(offset).Take(count).ToList();
        }
        private List<User> GetAvailableUsers(User user)
        {
            IQueryable<User> allUsers = GetUsersList();
            var availableUsers = new List<User>();

            if (user.RoleModel.Role == UserRole.Owner)
            {
                return allUsers.ToList();
            }

            foreach (var item in allUsers)
            {
                if (user.RoleModel.IsAllCountriesAccess)
                {
                    bool isForbidden = false;

                    foreach (var country in user.RoleModel.ForbiddenCountries)
                    {
                        if (item.CountryId == country.Id)
                        {
                            isForbidden = true;
                            break;
                        }
                    }

                    if (!isForbidden)
                    {
                        availableUsers.Add(item);
                    }
                }
                else
                {
                    foreach (var country in user.RoleModel.AvailableCountries)
                    {
                        if (item.CountryId == country.Id)
                        {
                            availableUsers.Add(item);
                            break;
                        }
                    }

                }
            }


            return availableUsers;
        }

        #endregion

        #region Private check access methods
        private RequestResult CheckAccess()
        {
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes(new Func<RequestResult>[]
            {
                () => CheckSession(session),
                () => CheckForBan(session.User,BanType.AdminPanel),
                () => RequestResult.FromBoolean(session.User.RoleModel.Role != UserRole.User,
                        403, "У данного пользователя нет доступа в администраторскую панель"),
                () => RequestResult.FromBoolean(session.User.RoleModel.Role == UserRole.Owner || session.User.RoleModel.Role == UserRole.LocalDirector,
                       403, "У данного пользователя нет прав доступа к разделу пользователей"),
             });
        }

        #endregion

        #region Private get included methods

        private IQueryable<User> GetUsersList()
        {
            return DB.Users.Include(o => o.Country)
                           .Include(o => o.RegisteredFromCountry)
                           .Include(o => o.RoleModel)
                           .Where(o => !o.IsDeleted);
        }



        private IQueryable<User> GetUsersFullIncludedList()
        {
            return DB.Users.Include(o => o.Country)
                           .Include(o => o.RegisteredFromCountry)
                           .Include(o => o.RoleModel)
                           //Заказы
                           .Include(o => o.Orders).ThenInclude(o => o.Items).ThenInclude(o => o.Item).ThenInclude(o => o.MainImage)
                           .Include(o => o.Orders).ThenInclude(o => o.Items).ThenInclude(o => o.SelectedModifiers).ThenInclude(o => o.Modifier)
                           .Include(o => o.Orders).ThenInclude(o => o.Items).ThenInclude(o => o.SelectedModifiers).ThenInclude(o => o.SelectedOptions).ThenInclude(o => o.Option)
                           .Include(o => o.Orders).ThenInclude(o => o.Address).ThenInclude(o => o.Country)
                           .Include(o => o.Orders).ThenInclude(o => o.Currency)
                           .Include(o => o.Orders).ThenInclude(o => o.Payments).ThenInclude(o => o.Currency)
                           .Include(o => o.Orders).ThenInclude(o => o.Return)
                           //Вичлист
                           .Include(o => o.Wishlist).ThenInclude(o => o.Items).ThenInclude(o => o.Product).ThenInclude(o => o.MainImage)
                           .Include(o => o.Wishlist).ThenInclude(o => o.Items).ThenInclude(o => o.Product).ThenInclude(o => o.Localizations)
                           .Include(o => o.Wishlist).ThenInclude(o => o.Items).ThenInclude(o => o.Product).ThenInclude(o => o.Category).ThenInclude(o => o.Localizations)
                           .Include(o => o.Wishlist).ThenInclude(o => o.Items).ThenInclude(o => o.Product).ThenInclude(o => o.BasePricing).ThenInclude(o => o.Costs).ThenInclude(o => o.Costs).ThenInclude(o => o.Currency)
                           .Include(o => o.Wishlist).ThenInclude(o => o.Items).ThenInclude(o => o.Product).ThenInclude(o => o.BasePricing).ThenInclude(o => o.Costs).ThenInclude(o => o.Country)
                           .Where(o => !o.IsDeleted);
        }

        #endregion
    }
}

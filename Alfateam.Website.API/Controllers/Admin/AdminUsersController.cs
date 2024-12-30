using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Core;
using Alfateam.Website.API.Extensions;
using Alfateam.Website.API.Helpers;
using Alfateam.Website.API.Models.DTO.General;
using Alfateam.Website.API.Models.DTO.Shop;
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
using Alfateam.Website.API.Models;
using Alfateam.Core.Exceptions;
using Alfateam.Website.API.Models.DTO.Shop.Orders;
using Alfateam.Website.API.Models.DTO.Shop.Wishes;
using Alfateam.Website.API.Models.DTO.Reviews;
using Alfateam.Website.API.Models.DTO.Posts;
using Alfateam.Website.API.Filters.Access;
using Alfateam.Core.Helpers;
using Alfateam.Website.API.Models.DTO.Team;
using Alfateam2._0.Models.Team;
using Alfateam.Core;
using Alfateam.Website.API.Models.DTO.Roles;



namespace Alfateam.Website.API.Controllers.Admin
{
    public class AdminUsersController : AbsAdminController
    {
        public AdminUsersController(ControllerParams @params) : base(@params)
        {
        }



        [HttpGet, Route("GetUsersCount")]
        public async Task<int> GetUsersCount()
        {
            return GetAvailableUsers().Count();
        }


        [HttpGet,Route("GetUsers")]
        public async Task<ItemsWithTotalCount<UserDTO>> GetUsers(int offset, int count = 20)
        {
            return DbService.GetManyWithTotalCount<User, UserDTO>(GetAvailableUsers(), offset, count);
        }
        [HttpGet, Route("GetUsersFiltered")]
        public async Task<ItemsWithTotalCount<UserDTO>> GetUsersFiltered([FromQuery] SearchFilter filter)
        {
            return DbService.GetManyWithTotalCount<User, UserDTO>(GetAvailableUsers(), filter.Offset, filter.Count, (entity) =>
            {
                return entity.FIO.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
            });
        }





        [HttpGet, Route("GetUserMainInfo")]
        public async Task<UserDTO> GetUserMainInfo(int id)
        {
            return (UserDTO)DbService.TryGetOne(GetAvailableUsers(), id, new UserDTO());
        }

        [HttpGet, Route("GetUserBasket")]
        public async Task<ShopOrderDTO> GetUserBasket(int id)
        {
            var users = DB.Users.Include(o => o.Basket).ThenInclude(o => o.Items).ThenInclude(o => o.Item).ThenInclude(o => o.MainImage)
                                .Include(o => o.Basket).ThenInclude(o => o.Items).ThenInclude(o => o.SelectedModifiers).ThenInclude(o => o.Modifier)
                                .Include(o => o.Basket).ThenInclude(o => o.Items).ThenInclude(o => o.SelectedModifiers).ThenInclude(o => o.SelectedOptions).ThenInclude(o => o.Option)
                                .Include(o => o.Basket).ThenInclude(o => o.Address).ThenInclude(o => o.Country)
                                .Include(o => o.Basket).ThenInclude(o => o.Currency)
                                .Include(o => o.Basket).ThenInclude(o => o.Payments).ThenInclude(o => o.Currency)
                                .Include(o => o.Basket).ThenInclude(o => o.Return);

            var user = GetAvailableUser(users, id);
            return (ShopOrderDTO)new ShopOrderDTO().CreateDTO(user.Basket);
        }

        [HttpGet, Route("GetUserOrders")]
        public async Task<IEnumerable<ShopOrderDTO>> GetUserOrders(int id)
        {
            var users = DB.Users.Include(o => o.Orders).ThenInclude(o => o.Items).ThenInclude(o => o.Item).ThenInclude(o => o.MainImage)
                                .Include(o => o.Orders).ThenInclude(o => o.Items).ThenInclude(o => o.SelectedModifiers).ThenInclude(o => o.Modifier)
                                .Include(o => o.Orders).ThenInclude(o => o.Items).ThenInclude(o => o.SelectedModifiers).ThenInclude(o => o.SelectedOptions).ThenInclude(o => o.Option)
                                .Include(o => o.Orders).ThenInclude(o => o.Address).ThenInclude(o => o.Country)
                                .Include(o => o.Orders).ThenInclude(o => o.Currency)
                                .Include(o => o.Orders).ThenInclude(o => o.Payments).ThenInclude(o => o.Currency)
                                .Include(o => o.Orders).ThenInclude(o => o.Return);

            var user = GetAvailableUser(users, id);
            return new ShopOrderDTO().CreateDTOs(user.Orders).Cast<ShopOrderDTO>();
        }
    
        [HttpGet, Route("GetUserWishlist")]
        public async Task<ShopWishlistDTO> GetUserWishlist(int id)
        {
            var users = DB.Users.Include(o => o.Wishlist).ThenInclude(o => o.Items).ThenInclude(o => o.Product).ThenInclude(o => o.MainImage)
                                .Include(o => o.Wishlist).ThenInclude(o => o.Items).ThenInclude(o => o.Product).ThenInclude(o => o.Localizations)
                                .Include(o => o.Wishlist).ThenInclude(o => o.Items).ThenInclude(o => o.Product).ThenInclude(o => o.Category).ThenInclude(o => o.Localizations)
                                .Include(o => o.Wishlist).ThenInclude(o => o.Items).ThenInclude(o => o.Product).ThenInclude(o => o.BasePricing).ThenInclude(o => o.Costs).ThenInclude(o => o.Costs).ThenInclude(o => o.Currency)
                                .Include(o => o.Wishlist).ThenInclude(o => o.Items).ThenInclude(o => o.Product).ThenInclude(o => o.BasePricing).ThenInclude(o => o.Costs).ThenInclude(o => o.Country);

            var user = GetAvailableUser(users, id);
            return (ShopWishlistDTO)new ShopWishlistDTO().CreateDTO(user.Wishlist);
        }

        [HttpGet, Route("GetUserRoleModel")]
        public async Task<UserRoleModel> GetUserRoleModel(int id)
        {
            var users = DB.Users.Include(o => o.RoleModel).ThenInclude(o => o.AvailableCountries)
                                .Include(o => o.RoleModel).ThenInclude(o => o.ForbiddenCountries)
                                .Include(o => o.RoleModel).ThenInclude(o => o.ContentAccessTypes)
                                .Include(o => o.RoleModel).ThenInclude(o => o.ReviewsAccess)
                                .Include(o => o.RoleModel).ThenInclude(o => o.HRAccess)
                                .Include(o => o.RoleModel).ThenInclude(o => o.ShopAccess)
                                .Include(o => o.RoleModel).ThenInclude(o => o.OutstaffAccess);

            var user = GetAvailableUser(users, id);
            return user.RoleModel;
        }

        [HttpGet, Route("GetUserReviews")]
        public async Task<IEnumerable<ReviewDTO>> GetUserReviews(int id)
        {
            var users = DB.Users.Include(o => o.Reviews).ThenInclude(o => o.Country);
         
            var user = GetAvailableUser(users, id);
            return new ReviewDTO().CreateDTOs(user.Reviews).Cast<ReviewDTO>();
        }








        [HttpPost, Route("CreateUser")]
        [UsersSectionAccess]
        public async Task<UserDTO> CreateUser(RegisterUserAdminModel model)
        {
            var admin = this.Session.User;

            if(model.Role == UserRole.Owner && admin.RoleModel.Role != UserRole.Owner)
            {
                throw new Exception403("Нельзя назначить роль Owner, не являясь Owner");
            }
            else if(model.Role == UserRole.User)
            {
                throw new Exception403("Нельзя создать пользователя - не админа");
            }

            var createdUser = model.CreateDBModelFromDTO();

            createdUser.RegisteredFromCountryId = this.CountryId;
            createdUser.Password = PasswordHelper.EncryptPassword(model.Password);

            createdUser.RoleModel = UserRoleModel.CreateDefault();
            createdUser.RoleModel.IsAllCountriesAccess = admin.RoleModel.IsAllCountriesAccess;
            createdUser.RoleModel.AvailableCountries = admin.RoleModel.AvailableCountries;
            createdUser.RoleModel.ForbiddenCountries = admin.RoleModel.ForbiddenCountries;

            DB.Users.Update(createdUser);
            DB.SaveChanges();

            return (UserDTO)new UserDTO().CreateDTO(createdUser);
        }






        [HttpPut, Route("UpdateUser")]
        [UsersSectionAccess]
        public async Task UpdateUser(UpdateUserModel model)
        {
            var found = GetAvailableUsers().FirstOrDefault(o => o.Id == model.Id);
            DbService.TryUpdateEntity(DB.Users, model, found);
        }

        [HttpPut, Route("UpdateUserRoles")]
        [UsersSectionAccess]
        public async Task UpdateUserRoles(int userId, UserRoleModelDTO model)
        {
            var admin = this.Session.User;
            var editingUser = GetAvailableUser(GetUsersList(), userId);

            if (admin.RoleModel.Role == UserRole.LocalDirector)
            {
                var allCountries = DB.Countries.Where(o => !o.IsDeleted).ToList();
                var adminAvailableCountries = admin.RoleModel.GetAvailableCountries(allCountries);


                bool success = true;
                string errorText = "Данный пользователь не может установить страны: \r\n";

                foreach (var countryId in model.AvailableCountriesIds)
                {
                    if (!adminAvailableCountries.Any(o => o.Id == countryId))
                    {
                        errorText += $"{allCountries.FirstOrDefault(o => o.Id == countryId)?.Title} \r\n";
                    }
                }

                if (!success)
                {
                    throw new Exception403(errorText);
                }
            }

            var oldRoleModel = editingUser.RoleModel;

            editingUser.RoleModel = model.CreateDBModelFromDTO(DB.Countries.Where(o => !o.IsDeleted));
            editingUser.RoleModelId = 0;

            DB.UserRoleModels.Remove(oldRoleModel);
            DB.Users.Update(editingUser);
            DB.SaveChanges();
        }





        [HttpPut, Route("BanUser")]
        [UsersSectionAccess]
        public async Task<BanInfoDTO> BanUser(int id,BanInfoDTO model)
        {
            var found = GetAvailableUser(GetUsersList(), id);
            found.BanInfo = new BanInfoDTO().CreateDBModelFromDTO();

            DbService.UpdateEntity(DB.Users, found);
            model.Id = found.BanInfo.Id;

            return model;
        }

        [HttpPut, Route("UnbanUser")]
        [UsersSectionAccess]
        public async Task UnbanUser(int id)
        {
            var found = GetAvailableUser(GetUsersList(), id);

            found.BanInfo = null;
            found.BanInfoId = null;

            DbService.UpdateEntity(DB.Users, found);
        }



        #region Private get available users
        private List<User> GetAvailableUsers(int offset, int count = 20)
        {
            return GetAvailableUsers().Skip(offset).Take(count).ToList();
        }
        private List<User> GetAvailableUsers()
        {
            return GetAvailableUsers(GetUsersList());
        }
        private List<User> GetAvailableUsers(IEnumerable<User> allUsers)
        {
            var user = this.Session.User;

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



        private User GetAvailableUser(IEnumerable<User> users, int id)
        {
            var user = GetAvailableUsers(users).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (user == null)
            {
                throw new Exception404("Сущность по данному id не найдена");
            }

            return user;
        }


        #endregion

        #region Private get included methods

        private IQueryable<User> GetUsersList()
        {
            return DB.Users.Include(o => o.Country)
                           .Include(o => o.RegisteredFromCountry)
                           .Include(o => o.RoleModel).ThenInclude(o => o.AvailableCountries)
                           .Include(o => o.RoleModel).ThenInclude(o => o.ForbiddenCountries)
                           .Include(o => o.RoleModel).ThenInclude(o => o.ContentAccessTypes)
                           .Include(o => o.RoleModel).ThenInclude(o => o.ReviewsAccess)
                           .Include(o => o.RoleModel).ThenInclude(o => o.HRAccess)
                           .Include(o => o.RoleModel).ThenInclude(o => o.ShopAccess)
                           .Include(o => o.RoleModel).ThenInclude(o => o.OutstaffAccess)
                           .Where(o => !o.IsDeleted);
        }



        private IQueryable<User> GetUsersFullIncludedList()
        {
            return DB.Users.Include(o => o.Country)
                           .Include(o => o.RegisteredFromCountry)
                           .Include(o => o.RoleModel).ThenInclude(o => o.AvailableCountries)
                           .Include(o => o.RoleModel).ThenInclude(o => o.ForbiddenCountries)
                           .Include(o => o.RoleModel).ThenInclude(o => o.ContentAccessTypes)
                           .Include(o => o.RoleModel).ThenInclude(o => o.ReviewsAccess)
                           .Include(o => o.RoleModel).ThenInclude(o => o.HRAccess)
                           .Include(o => o.RoleModel).ThenInclude(o => o.ShopAccess)
                           .Include(o => o.RoleModel).ThenInclude(o => o.OutstaffAccess)
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

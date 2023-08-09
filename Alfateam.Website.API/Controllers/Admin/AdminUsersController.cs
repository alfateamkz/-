using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Extensions;
using Alfateam.Website.API.Helpers;
using Alfateam.Website.API.Models.Core;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Shop.Orders;
using Alfateam2._0.Models.Shop.Wishes;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.Website.API.Controllers.Admin
{
    public class AdminUsersController : AbsController
    {

        //TODO: роль
        public AdminUsersController(WebsiteDBContext db) : base(db)
        {
        }

        [HttpGet,Route("GetUsers")]
        public IEnumerable<User> GetUsers(int offset, int count = 20)
        {
            return DB.Users.Where(o => !o.IsDeleted).Skip(offset).Take(count).ToList();
        }

        [HttpPost, Route("CreateUser")]
        public RequestResult<User> CreateUser(User user)
        {
            var res = new RequestResult<User>();

            if(user.Id != 0)
            {
                res.Error = "Невозможно создать пользователя с явно заданным идентификатором";
            }
            if (user.RegisteredFromCountryId == null)
            {
                res.Error = "Необходимо указать id страны, из которой зарегистрирован пользователь";
            }
            if (user.Country == null)
            {
                res.Error = "Необходимо указать id страны, в которой находится пользователь";
            }
            if (user.RoleModel == null)
            {
                res.Error = "Необходимо проинициализировать роли пользователя";
            }
            else
            {
                user.Wishlist = new ShopWishlist();
                user.Basket = new ShopOrder();

                res.Success = true;
                res.Value = user;
            }


            return res;
        }


     


      


        [HttpDelete, Route("DeleteUser")]
        public RequestResult DeleteUser(int id)
        {
            var res = new RequestResult();

            var found = DB.Users.FirstOrDefault(o => o.Id == id);
            if(found == null)
            {
                res.Code = 404;
                res.Error = "Пользователь не найден";
            }
            else
            {
                found.IsDeleted = true;
                DB.Users.Update(found);
                DB.SaveChanges();

                res.Success = true;
            }

            return res;
        }

    }
}

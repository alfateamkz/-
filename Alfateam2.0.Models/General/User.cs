using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Promocodes;
using Alfateam2._0.Models.Reviews;
using Alfateam2._0.Models.Roles;
using Alfateam2._0.Models.Shop.Orders;
using Alfateam2._0.Models.Shop.Wishes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.General
{
    /// <summary>
    /// Сущность пользователя сайта
    /// </summary>
    public class User : AbsModel
    {
        public string Name { get; set; }    
        public string Surname { get; set; }
        public string? Patronymic { get; set; }
        public string? AvatarPath { get; set; }


        public string Email { get; set; }
        public string? Phone { get; set; }
        public string Password { get; set; }


        /// <summary>
        /// Причина, по которой пользователь заблокирован
        /// Если BanInfo == null, то значит пользователь не заблокирован
        /// </summary>
        public BanInfo? BanInfo { get; set; }
        public int? BanInfoId { get; set; }



        /// <summary>
        /// Id связанного пользователя в CRM системе
        /// </summary>
        public int? BindedCRMUser { get; set; }
        public UserRoleModel RoleModel { get; set; }


        public Country? Country { get; set; }
        public int? CountryId { get; set; }

        public Country? RegisteredFromCountry { get; set; }
        public int? RegisteredFromCountryId { get; set; }



        public List<Review> Reviews { get; set; } = new List<Review>();



        /// <summary>
        /// Корзина пользователя. При покупки заказ за Basket переходит в Orders  
        /// </summary>
        public ShopOrder? Basket { get; set; }
        public List<ShopOrder> Orders { get; set; } = new List<ShopOrder>();
        public ShopWishlist Wishlist { get; set; }
        public List<UsedPromocode> UsedPromocodes { get; set; } = new List<UsedPromocode>();
    }
}

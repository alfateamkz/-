using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Roles.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Roles
{
    /// <summary>
    /// Сущность роли и прав пользователя
    /// </summary>
    public class UserRoleModel : AbsModel
    {
        /// <summary>
        /// Если Role == Owner, то доступны все разделы вне зависимости от свойств ниже
        /// </summary>
        public UserRole Role { get; set; } = UserRole.User;


        /// <summary>
        ///  Имеет ли пользователь админки доступ ко всем странам, кроме ForbiddenCountries
        ///  Если false, то имеет доступ только к странам из списка AvailableCountries
        /// </summary>
        public bool IsAllCountriesAccess { get; set; }  
        /// <summary>
        /// К каким странам пользователь админки имеет доступ
        /// </summary>
        public List<Country> AvailableCountries { get; set; } = new List<Country>();
        /// <summary>
        /// К каким странам пользователь админки не имеет доступ
        /// </summary>
        public List<Country> ForbiddenCountries { get; set; } = new List<Country>();




        public HRAccessModel HRAccess { get; set; }
        public ShopAccessModel ShopAccess { get; set; }
        public OutstaffAccessModel OutstaffAccess { get; set; }
        public List<ContentAccessModel> ContentAccessTypes { get; set; } = new List<ContentAccessModel>();
        public ContentAccessModel GetContentAccess(ContentAccessModelType type)
        {
            return ContentAccessTypes.FirstOrDefault(o => o.Type == type);
        }



        public List<Country> GetAvailableCountries(List<Country> fromAll)
        {
            var countries = new List<Country>();
            if (IsAllCountriesAccess)
            {
                countries = new List<Country>(fromAll);
                foreach (var forbidden in ForbiddenCountries)
                {
                    var found = countries.FirstOrDefault(o => o.Id == forbidden.Id);
                    countries.Remove(found);
                }
            }
            else
            {
                countries = new List<Country>(AvailableCountries);
            }
            return countries;
        }



      
    }
}

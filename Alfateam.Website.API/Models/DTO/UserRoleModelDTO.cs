﻿using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Roles;
using Alfateam2._0.Models.Roles.Access;

namespace Alfateam.Website.API.Models.DTO
{
    public class UserRoleModelDTO : DTOModel<UserRoleModel>
    {
        public UserRole Role { get; set; }


        public bool IsAllCountriesAccess { get; set; }
        public List<int> AvailableCountriesIds { get; set; } = new List<int>();
        public List<int> ForbiddenCountriesIds { get; set; } = new List<int>();



        public ReviewsAccessModel ReviewsAccess { get; set; }
        public HRAccessModel HRAccess { get; set; }
        public ShopAccessModel ShopAccess { get; set; }
        public OutstaffAccessModel OutstaffAccess { get; set; }
        public List<ContentAccessModel> ContentAccessTypes { get; set; } = new List<ContentAccessModel>();





        public override void FillDBModel(UserRoleModel item, DBModelFillMode mode)
        {
            throw new NotSupportedException("Use Fill(UserRoleModel item, List<Country> allCountriesFromDB) instead");
        }



        public virtual UserRoleModel CreateDBModelFromDTO(IEnumerable<Country> allCountriesFromDB)
        {
            var newItem = new UserRoleModel();

            var types = FindAllDerivedTypes<UserRoleModel>();
            if (types.Any())
            {
                var discriminatorProp = this.GetType().GetProperties().FirstOrDefault(o => o.Name == "Discriminator");
                if (discriminatorProp != null)
                {
                    var discriminatorValue = discriminatorProp.GetValue(this);
                    var foundType = types.FirstOrDefault(o => o.Name.Equals(discriminatorValue));

                    newItem = (UserRoleModel)Activator.CreateInstance(foundType);
                }
            }

            this.Fill(newItem, allCountriesFromDB);
            //newItem.Id = 0;


            return newItem;
        }
        public void Fill(UserRoleModel item, IEnumerable<Country> allCountriesFromDB)
        {


            item.Role = Role;
            item.IsAllCountriesAccess = IsAllCountriesAccess;

            item.ReviewsAccess = ReviewsAccess;
            item.HRAccess = HRAccess;
            item.ShopAccess = ShopAccess;
            item.OutstaffAccess = OutstaffAccess;

            UpdateCountriesList(item.AvailableCountries, AvailableCountriesIds, allCountriesFromDB);
            UpdateCountriesList(item.ForbiddenCountries, ForbiddenCountriesIds, allCountriesFromDB);
        }

        private void UpdateCountriesList(List<Country> countries, List<int> editModelIds, IEnumerable<Country> allCountriesFromDB)
        {
            //Удаляем удаленные на фронте модели
            for (int i = countries.Count - 1; i >= 0; i--)
            {
                var country = countries[i];
                if (!editModelIds.Any(o => o == country.Id))
                {
                    countries.Remove(country);
                }
            }

            foreach (var id in editModelIds)
            {
                if (!countries.Any(o => o.Id == id))
                {
                    countries.Add(allCountriesFromDB.FirstOrDefault(o => o.Id == id));
                }
            }
        }
    }
}

using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Roles;
using Alfateam2._0.Models.Roles.Access;

namespace Alfateam.Website.API.Models.CreateModels
{
    public class UserRoleCreateModel : CreateModel<UserRoleModel>
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

        public override bool IsValid()
        {
            var isValid = true;

            isValid &= ReviewsAccess != null;
            isValid &= HRAccess != null;
            isValid &= ShopAccess != null;
            isValid &= OutstaffAccess != null;

            if (!IsAllCountriesAccess)
            {
                isValid &= AvailableCountriesIds.Any();
            }

            return isValid;
        }
        public override void Fill(UserRoleModel item)
        {
            throw new NotSupportedException("Use Fill(UserRoleModel item, List<Country> allCountriesFromDB) instead");
        }

        public void Fill(UserRoleModel item, List<Country> allCountriesFromDB)
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

        private void UpdateCountriesList(List<Country> countries, List<int> editModelIds, List<Country> allCountriesFromDB)
        {
            //Удаляем удаленные на фронте модели
            for(int i=countries.Count-1; i>=0; i--)
            {
                var country = countries[i];
                if(!editModelIds.Any(o => o == country.Id))
                {
                    countries.Remove(country);
                }
            }

            foreach (var id in editModelIds)
            {
                if(!countries.Any(o => o.Id == id))
                {
                    countries.Add(allCountriesFromDB.FirstOrDefault(o => o.Id == id));
                }
            }
        }
    }
}

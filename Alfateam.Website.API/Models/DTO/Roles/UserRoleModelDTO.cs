using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models.DTO.Roles.Access;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Roles;
using Alfateam2._0.Models.Roles.Access;

namespace Alfateam.Website.API.Models.DTO.Roles
{
    public class UserRoleModelDTO : DTOModel<UserRoleModel>
    {
        public UserRole Role { get; set; }


        public bool IsAllCountriesAccess { get; set; }
        public List<int> AvailableCountriesIds { get; set; } = new List<int>();
        public List<int> ForbiddenCountriesIds { get; set; } = new List<int>();



        public ReviewsAccessModelDTO ReviewsAccess { get; set; }
        public HRAccessModelDTO HRAccess { get; set; }
        public ShopAccessModelDTO ShopAccess { get; set; }
        public OutstaffAccessModelDTO OutstaffAccess { get; set; }
        public List<ContentAccessModelDTO> ContentAccessTypes { get; set; } = new List<ContentAccessModelDTO>();





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
                var discriminatorProp = GetType().GetProperties().FirstOrDefault(o => o.Name == "Discriminator");
                if (discriminatorProp != null)
                {
                    var discriminatorValue = discriminatorProp.GetValue(this);
                    var foundType = types.FirstOrDefault(o => o.Name.Equals(discriminatorValue));

                    newItem = (UserRoleModel)Activator.CreateInstance(foundType);
                }
            }

            Fill(newItem, allCountriesFromDB);
            //newItem.Id = 0;


            return newItem;
        }
        public void Fill(UserRoleModel item, IEnumerable<Country> allCountriesFromDB)
        {


            item.Role = Role;
            item.IsAllCountriesAccess = IsAllCountriesAccess;

            item.ReviewsAccess = ReviewsAccess.CreateDBModelFromDTO();
            item.HRAccess = HRAccess.CreateDBModelFromDTO();
            item.ShopAccess = ShopAccess.CreateDBModelFromDTO();
            item.OutstaffAccess = OutstaffAccess.CreateDBModelFromDTO();

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

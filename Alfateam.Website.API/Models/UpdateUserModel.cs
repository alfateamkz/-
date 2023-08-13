using Alfateam2._0.Models.General;

namespace Alfateam.Website.API.Models
{
    public class UpdateUserModel 
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }



        public int? BindedCRMUser { get; set; }



        public int? CountryId { get; set; }
        public int? RegisteredFromCountryId { get; set; }

        public bool ValidateModel()
        {
            bool isValid = true;

            isValid &= !string.IsNullOrEmpty(Name);
            isValid &= !string.IsNullOrEmpty(Surname);
            isValid &= Id > 0;

            return isValid;
        }

        public void SetData(User user)
        {
            user.Name = Name;
            user.Surname = Surname;
            user.Patronymic = Patronymic;

            user.BindedCRMUser = BindedCRMUser;

            user.CountryId = CountryId;
            user.RegisteredFromCountryId = RegisteredFromCountryId;
        }
    }
}

using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.General;

namespace Alfateam.Website.API.Models.UserModels
{
    public class RegisterUserModel : DTOModel<User>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }



        public string Email { get; set; }
        public string? Phone { get; set; }
        public string Password { get; set; }



        public int? CountryId { get; set; }
        public int? RegisteredFromCountryId { get; set; }


        public void SetData(User user)
        {
            user.Name = Name;
            user.Surname = Surname;
            user.Patronymic = Patronymic;

            user.Email = Email;
            user.Phone = Phone;
            user.Password = Password;

            user.CountryId = CountryId;
            user.RegisteredFromCountryId = RegisteredFromCountryId;
        }
    }
}

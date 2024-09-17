using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.General;

namespace Alfateam.Website.API.Models.UserModels
{
    public class RegisterUserAdminModel : DTOModel<User>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }



        public string Email { get; set; }
        public string? Phone { get; set; }
        public string Password { get; set; }



        public int? CountryId { get; set; }



        public UserRole Role { get; set; }
    }
}

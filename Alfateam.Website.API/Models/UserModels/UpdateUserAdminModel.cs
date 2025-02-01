using Alfateam2._0.Models.General;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Website.API.Models.UserModels
{
    public class UpdateUserAdminModel : DTOModel<User>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }



        public string Email { get; set; }
        public string? Phone { get; set; }
        public string Password { get; set; }
    }
}

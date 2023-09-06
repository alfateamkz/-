using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.General;

namespace Alfateam.CRM2_0.Models.CreateModels.General
{
    public class UserCreateModel : CreateModel<User>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }

        public int CountryId { get; set; }

        public string Login { get; set; }
        public string Email { get; set; }
    }
}

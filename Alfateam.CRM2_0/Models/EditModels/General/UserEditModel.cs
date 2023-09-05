using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Security;

namespace Alfateam.CRM2_0.Models.EditModels.General
{
    public class UserEditModel : EditModel<User>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }

        public int CountryId { get; set; }

        public string Login { get; set; }




        public bool IsActive { get; set; } = true;
    }
}

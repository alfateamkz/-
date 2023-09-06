using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Security;

namespace Alfateam.CRM2_0.Models.ClientModels.General
{
    public class UserClientModel : ClientModel<User>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }


        public CountryClientModel Country { get; set; }


        public string Login { get; set; }
        public string Email { get; set; }


        public bool IsActive { get; set; }
    }
}

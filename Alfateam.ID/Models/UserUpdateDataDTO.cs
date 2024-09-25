using Alfateam.ID.Models;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.ID.API.Models
{
    public class UserUpdateDataDTO : DTOModelAbs<User>
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string? Patronymic { get; set; }


        public string CountryCode { get; set; }
    }
}

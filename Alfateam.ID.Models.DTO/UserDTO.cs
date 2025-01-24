using Alfateam.Core.Attributes.DTO;
using Alfateam.ID.Models;
using Alfateam.Website.API.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alfateam.ID.Models.DTO
{
    public class UserDTO : DTOModelAbs<User>
    {
        [ForClientOnly]
        public string Guid { get; set; }

        public string Surname { get; set; }
        public string Name { get; set; }
        public string? Patronymic { get; set; }



        [ForClientOnly]
        public string FIO => $"{Surname} {Name} {Patronymic}";


        public string Email { get; set; }
        public string Phone { get; set; }

        [DTOFieldFor(DTOFieldForType.CreationOnly)]
        [HiddenFromClient]
        public string Password { get; set; }


        [ForClientOnly]
        public bool IsEmailVerified { get; set; }
        [ForClientOnly]
        public bool IsPhoneVerified { get; set; }


        public string CountryCode { get; set; }
        public string LanguageCode { get; set; }
    }
}

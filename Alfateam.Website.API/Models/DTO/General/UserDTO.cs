using Alfateam.Website.API.Abstractions;
using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Models.DTO.General;
using Alfateam2._0.Models.General;

namespace Alfateam.Website.API.Models.DTO.General
{
    public class UserDTO : DTOModel<User>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }
        public string? AvatarPath { get; set; }


        public string Email { get; set; }
        public string? Phone { get; set; }



        [ForClientOnly]
        public CountryDTO? Country { get; set; }
        [ForClientOnly]
        public CountryDTO? RegisteredFromCountry { get; set; }
    }
}

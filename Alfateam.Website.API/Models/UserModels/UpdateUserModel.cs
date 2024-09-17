using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.General;

namespace Alfateam.Website.API.Models.UserModels
{
    public class UpdateUserModel : DTOModel<User>
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }



        public int? BindedCRMUser { get; set; }



        public int? CountryId { get; set; }
    }
}

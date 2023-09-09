using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.ClientModels.General;
using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Trial;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Lawyer.Trial
{
    public class JudgeClientModel : ClientModel<Judge>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }



        public CountryClientModel Country { get; set; }
        public string City { get; set; }


        public string Position { get; set; }
        public string? Description { get; set; }
        public string? Comment { get; set; }
    }
}

using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.HR.JobVacancies;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.HR.JobVacancies
{
    public class JobVacancyExpierenceClientModel : ClientModel<JobVacancyExpierence>
    {
        public int? YearsFrom { get; set; }
        public int? YearsTo { get; set; }
    }
}

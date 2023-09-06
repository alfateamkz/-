using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.HR.JobVacancies;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.HR.JobVacancies
{
    public class JobVacancyExpierenceCreateModel : CreateModel<JobVacancyExpierence>
    {
        public int? YearsFrom { get; set; }
        public int? YearsTo { get; set; }
    }
}

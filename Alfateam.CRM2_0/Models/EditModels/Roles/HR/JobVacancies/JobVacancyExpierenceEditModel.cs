using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.HR.JobVacancies;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.HR.JobVacancies
{
    public class JobVacancyExpierenceEditModel : EditModel<JobVacancyExpierence>
    {
        public int? YearsFrom { get; set; }
        public int? YearsTo { get; set; }
    }
}

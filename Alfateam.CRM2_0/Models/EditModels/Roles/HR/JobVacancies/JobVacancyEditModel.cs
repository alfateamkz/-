using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.HR;
using Alfateam.CRM2_0.Models.Roles.HR.JobVacancies;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.HR.JobVacancies
{
    public class JobVacancyEditModel : EditModel<JobVacancy>
    {
        public JobVacancyStatus Status { get; set; } = JobVacancyStatus.Active;

        public string Title { get; set; }
        public string Description { get; set; }

        public int CurrencyId { get; set; }

        public double? SalaryFrom { get; set; }
        public double? SalaryTo { get; set; }


        public JobVacancyExpierenceEditModel Expierence { get; set; }


        public override void Fill(JobVacancy item)
        {
            base.Fill(item);
            Expierence.Fill(item.Expierence);
        }
    }
}

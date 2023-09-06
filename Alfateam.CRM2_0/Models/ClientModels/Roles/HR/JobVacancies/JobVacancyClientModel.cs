using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.ClientModels.General;
using Alfateam.CRM2_0.Models.Enums.Roles.HR;
using Alfateam.CRM2_0.Models.Roles.HR.JobVacancies;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.HR.JobVacancies
{
    public class JobVacancyClientModel : ClientModel<JobVacancy>
    {
        public JobVacancyStatus Status { get; set; } = JobVacancyStatus.Active;

        public string Title { get; set; }
        public string Description { get; set; }

        public CurrencyClientModel Currency { get; set; }


        public double? SalaryFrom { get; set; }
        public double? SalaryTo { get; set; }


        public JobVacancyExpierenceClientModel Expierence { get; set; }
    }
}

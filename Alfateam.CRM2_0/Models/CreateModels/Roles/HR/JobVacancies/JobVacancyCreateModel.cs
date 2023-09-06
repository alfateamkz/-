using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.HR;
using Alfateam.CRM2_0.Models.Roles.HR.JobVacancies;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.HR.JobVacancies
{
    public class JobVacancyCreateModel : CreateModel<JobVacancy>
    {

        public string Title { get; set; }
        public string Description { get; set; }

        public int CurrencyId { get; set; }

        public double? SalaryFrom { get; set; }
        public double? SalaryTo { get; set; }


        public JobVacancyExpierenceCreateModel Expierence { get; set; }

        public override JobVacancy Create()
        {
            var vacancy = base.Create();
            vacancy.Expierence = Expierence.Create();

            return vacancy;
        }
    }
}

using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.ContentItems;
using Alfateam2._0.Models.HR;

namespace Alfateam.Website.API.Models.EditModels.HR
{
    public class JobVacancyMainEditModel : EditModel<JobVacancy>
    {
        public string Title { get; set; }

        public int CurrencyId { get; set; }

        public double? SalaryFrom { get; set; }
        public double? SalaryTo { get; set; }


        public Content InnerContent { get; set; }


        public JobVacancyExpierence Expierence { get; set; }


        public int MainLanguageId { get; set; }
    }
}

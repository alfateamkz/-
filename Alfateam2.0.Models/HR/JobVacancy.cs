using Alfateam.Core.Helpers;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.ContentItems;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Localization.Items.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.HR
{
    /// <summary>
    /// Сущность вакансии
    /// Если SalaryFrom и SalaryTo равны null, то ЗП договорная
    /// </summary>
    public class JobVacancy : AvailabilityModel
    {
        public string Title { get; set; }

        public Currency Currency { get; set; }
        public int CurrencyId { get; set; }

        public double? SalaryFrom { get; set; }
        public double? SalaryTo { get; set; }



        public JobVacancyCategory? Category { get; set; }
        public int? CategoryId { get; set; }



        [NotMapped]
        public string Slug => $"{SlugHelper.GetLatynSlug(Title)}-{Id}";

        public Content InnerContent { get; set; }


        public JobVacancyExpierence Expierence { get; set; }


        public List<JobSummary> Summaries { get; set; } = new List<JobSummary>();


        public int Watches { get; set; }
        public List<Watch> WatchesList { get; set; } = new List<Watch>();



        public Language MainLanguage { get; set; }
        public int MainLanguageId { get; set; }
        public List<JobVacancyLocalization> Localizations { get; set; } = new List<JobVacancyLocalization>();

    }
}

using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.HR;
using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.HR.JobVacancies
{
    /// <summary>
    /// Сущность вакансии
    /// </summary>
    public class JobVacancy : AbsModel
    {
        public JobVacancyStatus Status { get; set; } = JobVacancyStatus.Active;

        public string Title { get; set; }
        public string Description { get; set; }

        public Currency Currency { get; set; }
        public int CurrencyId { get; set; }

        public double? SalaryFrom { get; set; }
        public double? SalaryTo { get; set; }


        public JobVacancyExpierence Expierence { get; set; }


        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int HRDepartmentId { get; set; }
    }
}

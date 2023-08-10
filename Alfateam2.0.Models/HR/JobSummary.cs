using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.HR
{
    /// <summary>
    /// Сущность отклика(резюме) на вакансию
    /// </summary>
    public class JobSummary : AbsModel
    {

        public JobSummaryStatus Status { get; set; } = JobSummaryStatus.Active;


        public string Name { get; set; }
        public string Surname { get; set; }
        public string AboutInfo { get; set; }
        public string? CVPath { get; set; }



        public User? CreatedBy { get; set; }
        public int? CreatedById { get; set; }
        public string CreatedByFingerprint { get; set; }


        /// <summary>
        /// Заметка HR-менеджера
        /// </summary>
        public string? Note { get; set; }


        /// <summary>
        /// Автоматическое поле
        /// Указывает на главную сущность (вакансию)
        /// </summary>
        public int JobVacancyId { get; set; }
    }
}

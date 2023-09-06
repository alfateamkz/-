using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.HR.JobVacancies
{
    /// <summary>
    /// Сущность требуемого рабочего опыта
    /// Если YearsFrom и YearsTo равны null, то опыт работы не требуется
    /// </summary>
    public class JobVacancyExpierence : AbsModel
    {
        public int? YearsFrom { get; set; }
        public int? YearsTo { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Enums
{
    /// <summary>
    /// Тип отклика(резюме) на вакансию
    /// </summary>
    public enum JobSummaryStatus
    {
        Active = 1, //Не обработано
        Candidate = 2, //Кандидат
        Interview = 3, //Собеседование
        Hired = 4, //Нанят на работу
        NotHired = 5, //Не нанят на работу(ставится после собеседования)
        Reserve = 6, //В резерве
        Rejected = 7, //Отклик отклонен HR-менеджером
    }
}
